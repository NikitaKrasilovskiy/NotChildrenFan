using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyPickUp : MonoBehaviour
{
    private BoyMovement _boyMovement;
    private BoyEvents _boyEvents;

    //Поднимаемый предмет
    private ItemsPickUp_Class itemPickUp;
    private bool cantPickUp;
    public GameObject infoButRef;
    private bool boyUmg;

    private void Awake()
    {
        _boyMovement = gameObject.GetComponent<BoyMovement>();
        _boyEvents = gameObject.GetComponent<BoyEvents>();
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
        if (itemPickUp != null && cantPickUp == false && _boyMovement.IsPushBoxOn == false)
        {
            if (Input.GetButtonDown("Interaction") && gameObject.GetComponent<BoyThrow>().IsReadyToPickUp == false)
            {
                //Выключает передвижение персонажа
                _boyMovement.CantWalk = true;
                _boyMovement.BoyStopMovement();
                //Запускает анимацию поднимания предмета
                _boyMovement._BoyAnimator.SetBool("isPickUp", true);
                cantPickUp = true;
                Invoke("ResetCantPickUp", 2);

                //Действие в ависимости от типа предмета
                switch (itemPickUp.CurrentitemType)
                {
                    //Предмет в руки для использования
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
                    //Патроны
                    case ItemsPickUp_Class.itemsType.ammoItem:
                        Debug.Log("ammoItem");
                        SetAmmoItem();
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
        BoyUsebleItems boyUseblItems = gameObject.GetComponent<BoyUsebleItems>();
        boyUseblItems.SpriteItemInHand = itemPickUp.SpriteItem;
        boyUseblItems.UsebleItemIndex = itemPickUp.ItemIndex;
        boyUseblItems.UseblItemName = itemPickUp.ItemName;
        boyUseblItems.IsUsebleItemInHand = true;
        boyUseblItems.SetUseblItemInHand();
    }

    //Передает значения предмета для броска в скрипт броска
    public void SetThrowItem()
    {
        BoyThrow boyThrow = gameObject.GetComponent<BoyThrow>();
        boyThrow.SpriteItemInHand = itemPickUp.SpriteItem;
        boyThrow.ThrowItemIndex = itemPickUp.ItemIndex;
        boyThrow.ThrowItemName = itemPickUp.ItemName;
        boyThrow.IsItemInHand = true;
    }

    //Подбор патронов
    public void SetAmmoItem()
    {
        BoyThrow boyThrow = gameObject.GetComponent<BoyThrow>();
        if(boyThrow.AmountRockAmmo < 3)
        {
            boyThrow.AmountRockAmmo = 3;
        }
    }

    public void DestriyPickUpItem()
    {
        itemPickUp.DestroyItem();
    }

    private void UMGOnOff()
    {
        if (boyUmg == true && _boyMovement.ChangeActivePerson == 1)
        {
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosBoy();
        }
        else if (boyUmg == true && _boyMovement.ChangeActivePerson == 0)
        {
            infoButRef.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PickUpItem" || other.tag == "Ammo")
        {
            itemPickUp = other.GetComponent<ItemsPickUp_Class>();
            boyUmg = true;
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosBoy();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PickUpItem" || other.tag == "Ammo")
        {
            itemPickUp = null;
            boyUmg = false;
            infoButRef.SetActive(false);
        }
    }
}
