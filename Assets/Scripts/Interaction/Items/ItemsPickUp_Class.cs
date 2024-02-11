using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickUp_Class : MonoBehaviour
{
    //Общий Класс предметов для подбора
    //Чилдрены - PickUpThrow_Class - предметы которые можно бросать


    //Индекс предмета
    protected int itemIndex;
    public int ItemIndex { get { return itemIndex; } set { itemIndex = value; } }
    //Имя предмета
    protected string itemName;
    public string ItemName { get { return itemName; } set { itemName = value; } }
    //СпрайтПредмета
    protected Sprite spriteItem;
    public Sprite SpriteItem { get { return spriteItem; } set { spriteItem = value; } }

    //Тип предмета (используемый для инвентаря, бросать, записка)
    public enum itemsType {usibleItem, throwItem, noteItem, ammoItem, item}
    private itemsType itemType;
    public itemsType CurrentitemType {get {return itemType;} set {itemType = value;}}

    //Выполняет действие при поднятии в зависимости от типа поднимаемого объекта
    public virtual void PickUpInteraction()
    {
        StartCoroutine("destroyItem");
    }

    IEnumerator destroyItem()
    {
        yield return new WaitForSeconds(0.5f);
        //spriteRender.enabled = false;
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    //Уничтожает объект после поднятия
    public virtual void DestroyItem()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBoy")
        {

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBoy")
        {            

        }       
    }
}
