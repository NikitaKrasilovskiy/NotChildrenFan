﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyUsebleItems : MonoBehaviour
{
    private BoyMovement _boyMovement;
    private BoyEvents _boyEvents;

    //Массив объектов в руке
    public GameObject[] useItemsInHand;
    //Массив объектов вылетающих из руки
    public GameObject[] useblThrowItemsInHand;

    //Индекс текущего предмета в руках
    private int currentIndexItemInHand;
    //Отображение Предмета в руке
    public SpriteRenderer useblItemInHand;
    //Спрайт предмета в руке
    private Sprite spriteItemInHand;
    public Sprite SpriteItemInHand { get { return spriteItemInHand; } set { spriteItemInHand = value; } }
    //Индекс поднимемого в руку предмета
    private int usebleItemIndex;
    public int UsebleItemIndex { get { return usebleItemIndex; } set { usebleItemIndex = value; } }
    //Имя поднимаемого в руку предмета
    private string useblItemName;
    public string UseblItemName { get { return useblItemName; } set { useblItemName = value; } }
    //Есть ли в руке предмет?
    private bool isUseblItemInHand;
    public bool IsUsebleItemInHand { get { return isUseblItemInHand; } set { isUseblItemInHand = value; } }
    //Спавн одного предмета
    private bool isSpawnInHand;
    public bool IsSpawnInHand { get { return isSpawnInHand; } set { isSpawnInHand = value; } }
    //Нужно ли облачко
    private bool comixOnOff;

    private EnvirInterBoyGirl_Class enviroumentInteractionObj;

    public Transform shotPoint;
    private GameObject throwHand;
    private int launchForse = 2;
    private bool toGirl;

    private void Awake()
    {
        _boyMovement = gameObject.GetComponent<BoyMovement>();
        _boyEvents = gameObject.GetComponent<BoyEvents>();
    }

    private void Start()
    {
        throwHand = transform.Find("BowPosition").gameObject;
    }

    private void Update()
    {
        //Debug.Log(currentIndexItemInHand);
        InteractionToGirlandEnvir();
    }

    //Добавление предмета в руку с задержкой
    public void SetUseblItemInHand()
    {
        //Если в руке нет предмета устанавливает индекс предмета в руке
        if(currentIndexItemInHand == 0)
        {
            currentIndexItemInHand = usebleItemIndex;
            Invoke("InvokeSetUseblItemInHand", 0.7f);
        }
        else if (currentIndexItemInHand > 0)
        {
            //Если в руке есть предмет, сначало выкидывает старый предмет, а потом устанавливает индекс нового
            if (isSpawnInHand == false)
            {
                Invoke("SpawnItemIfItemIsHand", 0.7f);
                Invoke("ResetSpawnItems", 1.5f);
                isSpawnInHand = true;
            }
        }
    }
    //Добавление предмета в руку
    private void InvokeSetUseblItemInHand()
    {
        useblItemInHand.sprite = spriteItemInHand;
    }

    private void SpawnItemIfItemIsHand()
    {
        //Спавн предмета
        GameObject newArrow = Instantiate(useblThrowItemsInHand[currentIndexItemInHand], shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = throwHand.transform.right * launchForse;
        currentIndexItemInHand = usebleItemIndex;
        useblItemInHand.sprite = spriteItemInHand;
    }

    private void ResetSpawnItems()
    {
        isSpawnInHand = false;
    }

    private void InteractionToGirlandEnvir()
    {
        //Если есть в руках предмет для взаимодействия
        if(Input.GetButtonDown("Interaction") && _boyMovement.ChangeActivePerson == 1)
        {
            
            //Если в руке нет предмета
            if (currentIndexItemInHand == 0)
            {
                if (enviroumentInteractionObj != null)
                {
                    enviroumentInteractionObj.WorckOnNeedItemsCurrentIndex = currentIndexItemInHand;
                    //Если нужен предмет для работы
                    if (enviroumentInteractionObj.NeedItem == true)
                    {
                        if(comixOnOff == false)
                        {
                            _boyEvents.EventIndex = enviroumentInteractionObj.IndexItemImage;
                            _boyEvents.SpriteEventOn();
                        }
                        _boyMovement._BoyAnimator.SetBool("isGift", true);
                        enviroumentInteractionObj.EnvirInteraction();
                        Invoke("NullSpriteNeedItem", 5);
                    }
                    //Если не нужен предмет для работы
                    else if (enviroumentInteractionObj.NeedItem == false)
                    {
                        //gameObject.GetComponentInChildren<Animator>().SetBool("isGift", true);
                        enviroumentInteractionObj.EnvirInteraction();
                    }
                }
            }
            
            //Если в руке есть предмет
            else if (currentIndexItemInHand > 0)
            {

                //Если взаимодействует с девочкой во время ивента
                if (toGirl == true && _boyMovement._GirlEvents.EventOffOn == true)
                {
                    //Ивент 02 Если не подорожник
                    if (_boyMovement._GirlEvents.EventIndex == 2)
                    {
                        _boyMovement._BoyAnimator.SetBool("isGift", true);
                        //Если дает Лопух
                        if (currentIndexItemInHand == 1)
                        {
                            //Передает информация девочке 
                            _boyMovement._GirlEvents.EventItemIndex = 1;
                            _boyMovement._GirlEvents.Event_02End();
                            //Убирает предмет из рук
                            Invoke("NullItemInHnd", 0.3f);
                        }
                        //Если дает Мать и Мачеху
                        else if (currentIndexItemInHand == 2)
                        {
                            //Передает информация девочке 
                            _boyMovement._GirlEvents.EventItemIndex = 2;
                            _boyMovement._GirlEvents.Event_02End();
                            //Убирает предмет из рук
                            Invoke("NullItemInHnd", 0.3f);
                        }

                    }
                    //Ивент 02 Если Подорожник
                    if (currentIndexItemInHand == 3)
                    {
                        _boyMovement._BoyAnimator.SetBool("isGift", true);
                        //Передает информация девочке 
                        _boyMovement._GirlEvents.Event_02GoodEnd();
                        //Убирает предмет из рук
                        Invoke("NullItemInHnd", 0.3f);
                    }
                }
                //Если взаимодейсвует с объектом
                if (enviroumentInteractionObj != null)
                {
                    enviroumentInteractionObj.WorckOnNeedItemsCurrentIndex = currentIndexItemInHand;
                    enviroumentInteractionObj.EnvirInteraction();
                    //Запускает ивент
                    switch (enviroumentInteractionObj.WorckOnNeedItems)
                    {
                        //Если не нужен предмет
                        case 0:
                            _boyMovement._BoyAnimator.SetBool("isGift", true);
                            break;
                        //Если нужен 1 предмет для активации
                        case 1:
                            //Если предмет в руке верный
                            if (currentIndexItemInHand == enviroumentInteractionObj.WorckOnNeedItemsIndex_01)
                            {
                                _boyMovement._BoyAnimator.SetBool("isGift", true);
                                enviroumentInteractionObj.NeedItem = false;
                                Invoke("NullItemInHnd", 0.3f);
                            }
                            //Если предмет в руке не верный
                            else
                            {
                                _boyEvents.EventIndex = enviroumentInteractionObj.IndexItemImage;
                                _boyEvents.SpriteEventOn();
                                Invoke("NullSpriteNeedItem", 5);
                                Debug.Log("Нужен другой предмет");
                            }
                            break;
                        //Если нужно 2 предмета
                        case 2:
                            //Если первый предмет в руке верный
                            if (currentIndexItemInHand == enviroumentInteractionObj.WorckOnNeedItemsIndex_01)
                            {
                                _boyMovement._BoyAnimator.SetBool("isGift", true);
                                enviroumentInteractionObj.NeedItem = false;
                                Invoke("NullItemInHnd", 0.3f);
                            }
                            //Если второй предмет в руке верный
                            else if (currentIndexItemInHand == enviroumentInteractionObj.WorckOnNeedItemsIndex_02)
                            {
                                //Если первый предмет уже активирован
                                if (enviroumentInteractionObj.WorckOnPart_01 == true && enviroumentInteractionObj.WorckOnHalfJobDone == true)
                                {
                                    _boyMovement._BoyAnimator.SetBool("isGift", true);
                                    Invoke("NullItemInHnd", 0.3f);
                                }
                                else if (enviroumentInteractionObj.WorckOnPart_01 == true && enviroumentInteractionObj.WorckOnHalfJobDone == false)
                                {
                                    Debug.Log("Нужно воспользоваться объектом");
                                }
                                //Если первый предмет еще не активирован
                                else if (enviroumentInteractionObj.WorckOnPart_01 == false)
                                {
                                    _boyMovement._BoyAnimator.SetBool("isGift", true);
                                    _boyEvents.EventIndex = enviroumentInteractionObj.IndexItemImage;
                                    _boyEvents.SpriteEventOn();
                                    Invoke("NullSpriteNeedItem", 5);
                                    Debug.Log("Нужен другой предмет");
                                }
                            }
                            //Если в руке нет верного предмета
                            else if (enviroumentInteractionObj.WorckOnPart_01 == false)
                            {
                                Debug.Log("Нужен другой предмет");
                                _boyMovement._BoyAnimator.SetBool("isGift", true);
                                _boyEvents.EventIndex = enviroumentInteractionObj.IndexItemImage;
                                _boyEvents.SpriteEventOn();
                                Invoke("NullSpriteNeedItem", 5);
                            }
                            break;
                            //Взлом замка
                         case 3:
                            _boyMovement._BoyAnimator.SetBool("isGift", true);
                            break;
                    }
                }
            }          
        }
    }

    //Убирает облако с предметом
    private void NullSpriteNeedItem()
    {
        _boyEvents.EndSpriteEvent();
    }

    //Обнуляет предмет в руке
    private void NullItemInHnd()
    {
        useblItemInHand.sprite = null;
        currentIndexItemInHand = 0;
        spriteItemInHand = null;
        usebleItemIndex = 0;
        useblItemName = null;
        isUseblItemInHand = false;
    }


    //Триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        //Взаимодействие с девочкой
        if (other.tag == "Player")
        {
            CharactersMovement charactersMovement = gameObject.GetComponentInChildren<CharactersMovement>();

            if (charactersMovement.ChangeActivePerson == 1)
            {
                toGirl = true;
            }
        }

        //Взаимодействие с окружением
        if (other.tag == "EnviroumentUse")
        {
            enviroumentInteractionObj = other.GetComponent<EnvirInterBoyGirl_Class>();
            comixOnOff = enviroumentInteractionObj.ComixOn;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            toGirl = false;
        }

        if (other.tag == "EnviroumentUse")
        {
            enviroumentInteractionObj = null;
            comixOnOff = false;
        }
    }

}
