using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlPickUp : MonoBehaviour
{
    private GirlMovement _girlMovement;

    //Поднимаемый предмет
    private ItemsPickUp_Class itemPickUp;
    private bool cantPickUp;
    public GameObject infoButRef;
    private bool girlUmg;
    private bool umgOn;

    private void Awake()
    {
        _girlMovement = gameObject.GetComponent<GirlMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PickUpItem();  
        UMGOnOff();
    }


    public void PickUpItem()
    {
        //Поднятие предмета (если соприкасается с предметом)
        if (itemPickUp != null && _girlMovement.IsCry == false && cantPickUp == false)
        {         
            if (Input.GetButtonDown("Interaction") && gameObject.GetComponent<GirlThrow>().IsReadyToPickUp == false)
            {
                //Выключает передвижение персонажа
                _girlMovement.CantWalk = true;
                _girlMovement.CantWalkLeft = true;
                _girlMovement.CantWalkRight = true;
                //Запускает анимацию поднимания предмета
                gameObject.GetComponentInChildren<Animator>().SetBool("isPickUp", true);
                cantPickUp = true;
                Invoke("ResetCantPickUp", 2);

                //Действие в ависимости от типа предмета
                switch (itemPickUp.CurrentitemType)
                {
                    //Предмет в инвентарь
                    case ItemsPickUp_Class.itemsType.usibleItem:
                        Debug.Log("useItem");
                        SetUsebleItem();
                        break;
                    //Предмет для броска
                    case ItemsPickUp_Class.itemsType.throwItem:
                        Debug.Log("throwItem");
                        SetThrowItem();
                        break;
                    //Предмет записка в журнал
                    case ItemsPickUp_Class.itemsType.noteItem:
                        Debug.Log("noteItem");
                        break;
                    case ItemsPickUp_Class.itemsType.item:
                        Debug.Log("item");
                        SetItem();
                        break;
                }               
            }
        }
    }

    //Сбрасывает блокировку на подбор предметов
    private void ResetCantPickUp()
    {
        cantPickUp = false;
    }

    //Подбор предметов
    public void SetItem()
    {
        if (itemPickUp.ItemIndex == 7)
        {
            Debug.Log("Dinamit");
        }
        if (itemPickUp.ItemIndex == 8)
        {
            Debug.Log("Katushka");
        }
        if (itemPickUp.ItemIndex == 9)
        {
            Debug.Log("Vzrwvatel");
        }
    }

    //Передает значения предмета для использования в скрипт использования
    public void SetUsebleItem()
    {
        GirlUsebleItems girlUseblItems = gameObject.GetComponent<GirlUsebleItems>();
        girlUseblItems.SpriteItemInHand = itemPickUp.SpriteItem;
        girlUseblItems.UsebleItemIndex = itemPickUp.ItemIndex;
        girlUseblItems.UseblItemName = itemPickUp.ItemName;
        girlUseblItems.IsUsebleItemInHand = true;
        girlUseblItems.SetUseblItemInHand();
    }

    //Передает значения предмета для броска в скрипт броска
    public void SetThrowItem()
    {
        GirlThrow girlThrow = gameObject.GetComponent<GirlThrow>();
        girlThrow.SpriteItemInHand = itemPickUp.SpriteItem;
        girlThrow.ThrowItemIndex = itemPickUp.ItemIndex;
        girlThrow.ThrowItemName = itemPickUp.ItemName;
        girlThrow.IsItemInHand = true;
    }

    public void DestriyPickUpItem()
    {
        itemPickUp.DestroyItem();
    }

    private void UMGOnOff()
    {
        if (girlUmg == true && _girlMovement.ChangeActivePerson == 0 && umgOn == false)
        {
            umgOn = true;
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
        }
        else if (girlUmg == true && _girlMovement.ChangeActivePerson == 1)
        {
            umgOn = false;
            infoButRef.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PickUpItem")
        {
            itemPickUp = other.GetComponent<ItemsPickUp_Class>();
            girlUmg = true;
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PickUpItem")
        {
            girlUmg = false;
            infoButRef.SetActive(false);
            itemPickUp = null;
        }
    }
}
