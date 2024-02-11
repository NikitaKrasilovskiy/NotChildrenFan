using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirLockCar_01 : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_03_Data scaneData;
    [SerializeField] private GameObject infoButRef;
    InfoButtons _infoButtons;
    public GameObject lockSistem;
    [SerializeField] private GameObject carsDoorsOpen;
    [SerializeField] private GameObject carsDoorsClouse;


    protected int lockAmount3;
    public int LockAmount3 { get { return lockAmount3; } set { lockAmount3 = value; } }
    //1 - девочка
    //2 - мальчик
    private int boyGirl;

    private bool girlUmg;
    private bool boyUmg;
    private bool openLockB;
    public bool OpenLockB { get { return openLockB; } set { openLockB = value; } }

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_03_Data>();
        _infoButtons = infoButRef.GetComponent<InfoButtons>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //КОЛИЧЕСВО ЗАТВОРОВ
        LockAmount = new bool[2];
        LockAmount3 = lockAmount.Length;

        worckOnNeedItems = 3;
    }

    private void Update()
    {
        UMGOnOff();
    }

    //Если пацан появляется облако что заперто
    //Если девочка появляется взлом замка
    public override void StartEnvirLockWorck()
    {
        if (boyGirl == 1)
        {

            scaneData._BoyEvents.EventIndex = 0;
            scaneData._BoyEvents.SpriteEventOn();
            scaneData._BoyMovement.TryClouseDoor();
            lockOnOff = true;
        }
        else if (boyGirl == 2)
        {
            scaneData._GirlEvents.GirlLockOn();
            lockSistem.SetActive(true);
            lockSistem.GetComponent<Lock_Class>().StartLock = true;
            lockOnOff = true;
        }
    }

    public override void EnvirWorck()
    {
        
    }

    //ДОБАВИТЬ В ЗАВИСИМОСТИ ОТ КОЛИЧЕСТВА ЗАТВОРОВ!
    public override void LockWorck()
    {
        if(LockAmount[0] == false && LockAmount2 == true)
        {
            LockAmount[0] = true;
            lockSistem.GetComponent<Lock_Class>().OpenZatvor_01();
        }
        else if (LockAmount[0] == true)
        {
            if(LockAmount2 == true)
            {
                LockAmount[1] = true;
                lockSistem.GetComponent<Lock_Class>().OpenZatvor_02();
            }
            if(LockAmountRed == true)
            {
                LockAmount[0] = false;
                lockSistem.GetComponent<Lock_Class>().ZatvorReset();
            }
        }
    }

    public void OpenLock()
    {
        scaneData._GirlEvents.GirlLockOff();
        carsDoorsOpen.SetActive(true);
        carsDoorsClouse.SetActive(false);
        scaneData.MapImageOn();
    }

    private void UMGOnOff()
    {
        if (lockOnOff == false && openLockB == false)
        {
            if (boyUmg == true && girlUmg == false && scaneData._BoyMovement.ChangeActivePerson == 1)
            {
                infoButRef.SetActive(true);
                _infoButtons.SetPosBoy();
            }
            else if (boyUmg == true && girlUmg == false && scaneData._BoyMovement.ChangeActivePerson == 0)
            {
                infoButRef.SetActive(false);
            }
            else if (girlUmg == true && scaneData._GirlMovement.ChangeActivePerson == 0)
            {
                infoButRef.SetActive(true);
                _infoButtons.SetPosGirl();
            }
            else if (girlUmg == true && scaneData._GirlMovement.ChangeActivePerson == 1)
            {
                infoButRef.SetActive(false);
            }
            else if (girlUmg == true && boyUmg == true && scaneData._BoyMovement.ChangeActivePerson == 1)
            {
                infoButRef.SetActive(true);
                _infoButtons.SetPosBoy();
            }
            else if (girlUmg == true && boyUmg == true && scaneData._BoyMovement.ChangeActivePerson == 0)
            {
                infoButRef.SetActive(true);
                _infoButtons.SetPosGirl();
            }

        }
        else if (lockOnOff == true)
        {
            infoButRef.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && openLockB == false)
        {
            boyGirl = 2;
            girlUmg = true;
            infoButRef.SetActive(true);
            _infoButtons.SetPosGirl();
        }
        else if(other.tag == "PlayerBoy" && openLockB == false)
        {
            boyGirl = 1;
            boyUmg = true;
            infoButRef.SetActive(true);
            _infoButtons.SetPosBoy();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            boyGirl = 0;
            scaneData._GirlEvents.GirlLockOff();
            lockOnOff = false;
            girlUmg = false;
            lockSistem.GetComponent<Lock_01>().ZatvorReset();
            lockSistem.SetActive(false);
            infoButRef.SetActive(false);
        }
        else if (other.tag == "PlayerBoy")
        {
            boyGirl = 0;
            boyUmg = false;
            infoButRef.SetActive(false);
            lockOnOff = false;
        }
    }
}
