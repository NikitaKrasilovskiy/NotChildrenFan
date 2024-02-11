using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirInterBoyGirl_Class : MonoBehaviour
{
    //Работает или нет
    protected bool worckOn;
    public bool WorckOn { get { return worckOn; } set { worckOn = value; } }
    //Нужно ли показать в облаке какой предмет необходим
    protected bool needItem;
    public bool NeedItem { get { return needItem; } set { needItem = value; } }
    //Работает на половину
    protected bool worckOnHalf;
    public bool WorckOnHalf { get { return worckOnHalf; } set { worckOnHalf = value; } }
    //Работает на половину и им воспользовались
    protected bool worckOnHalfJobDone;
    public bool WorckOnHalfJobDone { get { return worckOnHalfJobDone; } set { worckOnHalfJobDone = value; } }
    //Работает на половину второй персонаж готов
    protected bool worckOnHalfPlayerReady;
    public bool WorckOnHalfPlayerReady { get { return worckOnHalfPlayerReady; } set { worckOnHalfPlayerReady = value; } }
    protected bool item_02Inter;
    //Индекс картинки предметов для работы
    protected int indexItemImage;
    public int IndexItemImage { get { return indexItemImage; } set { indexItemImage = value; } }
    //Показывать облочко или нет
    protected bool comixOn;
    public bool ComixOn { get { return comixOn; } set { comixOn = value; } }
    //Режим работы объекта
    //0 - ненужен предмет для работы (просто работает)
    //1 - нужен один предмет для работы
    //2 - нужно два предмета для работы
    //3 - замок
    protected int worckOnNeedItems;
    public int WorckOnNeedItems { get { return worckOnNeedItems; } set { worckOnNeedItems = value; } }

    //Индекс предметов для работы
    protected int worckOnNeedItemsIndex_01;
    public int WorckOnNeedItemsIndex_01 { get { return worckOnNeedItemsIndex_01; } set { worckOnNeedItemsIndex_01 = value; } }
    protected int worckOnNeedItemsIndex_02;
    public int WorckOnNeedItemsIndex_02 { get { return worckOnNeedItemsIndex_02; } set { worckOnNeedItemsIndex_02 = value; } }
    protected int worckOnNeedItemsCurrentIndex;
    public int WorckOnNeedItemsCurrentIndex { get { return worckOnNeedItemsCurrentIndex; } set { worckOnNeedItemsCurrentIndex = value; } }
    //Включение предметов необходимых для работы
    protected bool worckOnPart_01;
    public bool WorckOnPart_01 { get { return worckOnPart_01; } set { worckOnPart_01 = value; } }
    protected bool worckOnPart_02;
    public bool WorckOnPart_02 { get { return worckOnPart_02; } set { worckOnPart_02 = value; } }
    //Замок включен
    protected bool lockOnOff;
    public bool LockOnOff { get { return lockOnOff; } set { lockOnOff = value; } }
    protected bool lockOpen;
    public bool LockOpen { get { return lockOpen; } set { lockOpen = value; } }
    //Количесвто тычек в замке
    //public List<bool> lockAmount;
    //public List<bool> LockAmount { get { return lockAmount; } set { lockAmount = value; } }
    //Количесвто тычек в замке
    protected bool[] lockAmount;
    public bool[] LockAmount { get { return lockAmount; } set { lockAmount = value; } }
    protected bool lockAmount2;
    public bool LockAmount2 { get { return lockAmount2; } set { lockAmount2 = value; } }
    protected bool lockAmountRed;
    public bool LockAmountRed { get { return lockAmountRed; } set { lockAmountRed = value; } }



    public virtual void EnvirInteraction()
    {
        //Если нужен один предмет
        if(worckOnNeedItems == 1)
        {
            //Если не активирован предметом
            if(worckOnPart_01 == false)
            {
                EnvirNotWorck();
            }
            //Если активирован предметом
            else if(worckOnPart_01 == true)
            {
                EnvirWorck();
            }
        }
        //Если нужно 2 предмета
        else if (worckOnNeedItems == 2)
        {
            //Если не активирован предметом
            if (worckOnPart_01 == false && worckOnPart_02 == false)
            {
                EnvirNotWorck();
            }
            //Если активирован предметом 01
            else if (worckOnPart_01 == true && worckOnPart_02 == false)
            {
                worckOnHalf = true;
                worckOn = false;
                EnvirWorckHalf();
            }
            //Если активирован обоими предметами
            else if (worckOnPart_01 == true && worckOnPart_02 == true)
            {
                worckOnHalf = false;
                worckOn = true;
                EnvirWorck();
            }
        }
        //Если не нужен предмет для активации
        else if (worckOnNeedItems == 0)
        {
            EnvirWorck();
        }
        //Если Замок
        else if (worckOnNeedItems == 3)
        {
            if(lockOnOff == false && lockOpen == false)
            {
                StartEnvirLockWorck();               
            }
            else if(lockOnOff == true && lockAmount.Length > 0 && lockOpen == false)
            {
                LockWorck();
            }
            else if(lockOpen == true)
            {
                EnvirWorck();
            }
        }
    }

    //Объект не работает
    public virtual void EnvirNotWorck()
    {
        //Если один предмет
        if(worckOnNeedItems == 1)
        {
            //Если предмет в руке верный активирует объект
            if (worckOnNeedItemsCurrentIndex == worckOnNeedItemsIndex_01)
            {
                worckOnPart_01 = true;
            }
        }
        //Если два предмета
        else if (worckOnNeedItems == 2)
        {
            //Если первый нужный предмет верный активирует объект на половину
            if(worckOnNeedItemsCurrentIndex == worckOnNeedItemsIndex_01)
            {
                Invoke("Part_01On", 1);               
            }
        }
    }
    //простое взаимодействие
    public virtual void EnvirWorck()
    {

    }
    //Включение системы замка
    public virtual void StartEnvirLockWorck()
    {

    }
    //Открытие тычки и переход к следующей
    public virtual void LockWorck()
    {

    }
    //Работает на половину
    public virtual void EnvirWorckHalf()
    {
        //Если второй предмет в руке верный и первый предмет уже активирован, активирует второй предмет
        if(worckOnNeedItemsCurrentIndex == worckOnNeedItemsIndex_02 && worckOnPart_01 == true)
        {
            Invoke("Part_02On", 1);
        }
        else if(worckOnPart_01 == true && worckOnHalfPlayerReady == true)
        {
            EnvirWorckHalfReady();
        }
    }

    private void ResetItem_02Inter()
    {
        item_02Inter = true;
    }

    public virtual void EnvirWorckHalfReady()
    {
       
    }

    private void Part_01On()
    {
        worckOnPart_01 = true;
    }

    private void Part_02On()
    {
        worckOnPart_02 = true;
    }
}
