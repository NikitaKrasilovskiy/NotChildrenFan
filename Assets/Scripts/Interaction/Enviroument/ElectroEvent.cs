using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroEvent : MonoBehaviour
{
    [SerializeField] private Scane_04_Data scaneData;

    [SerializeField] private GameObject infoButRef;
    InfoButtons _infoButtons;

    public GameObject electroshit;
    public GameObject svet_01;
    public GameObject svet_02;
    public GameObject item_01;
    //public GameObject item_02;
    private bool svetOn;
    private bool iventOnBoy;
    private bool iventOnGirl;
    private bool triggerOnOff;
    private bool boyUmg;
    private bool girlUmg;
    private bool whireOn;
    public bool WhireOn { get { return whireOn; } set { whireOn = value; } }

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_04_Data>();
        _infoButtons = infoButRef.GetComponent<InfoButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        UMGOnOff();
        ElectroEventOnOff();
        UseElectro();
    }

    private void ElectroEventOnOff()
    {
        if(triggerOnOff == true)
        {
            if (Input.GetButtonDown("Crounch") && iventOnBoy == false)
            {
                BoyElectroEventOn();
            }
            else if (Input.GetButtonDown("Crounch") && iventOnBoy == true)
            {
                BoyElectroEventOff();
            }
            else if (Input.GetButtonDown("Crounch") && iventOnGirl == false)
            {
                GirlElectroEventOn();
            }
            else if (Input.GetButtonDown("Crounch") && iventOnGirl == true)
            {
                GirlElectroEventOff();
            }
        }
    }

    private void UseElectro()
    {
        if (Input.GetButtonDown("Interaction") && iventOnBoy == false && iventOnGirl == false)
        {
            if(whireOn == false)
            {
                Debug.Log("net");
            }
            else if(whireOn == true)
            {
                if(svetOn == false)
                {
                    //svet_01.SetActive(true);
                    //svet_02.SetActive(true);
                    //item_01.SetActive(true);
                    //item_02.SetActive(true);
                    //svetOn = true;
                }
            }
        }
    }

    public void WinOnn()
    {
        svet_01.SetActive(true);
        svet_02.SetActive(true);
        item_01.SetActive(true);
        GirlElectroEventOff();
        electroshit.SetActive(false);
        svetOn = true;
        scaneData.ElectroWin();
    }

    private void BoyElectroEventOn()
    {
        iventOnBoy = true;

        scaneData._BoyEvents.PushBoxEventStart();
        scaneData.ElectroStart();
    }

    private void BoyElectroEventOff()
    {
        iventOnBoy = false;
        scaneData._BoyEvents.PushBoxEventEnd();
        scaneData.ElectroExit();
    }

    private void GirlElectroEventOn()
    {
        iventOnGirl = true;
        scaneData._BoyEvents.PushBoxEventStart();
        scaneData.ElectroStart();
    }

    private void GirlElectroEventOff()
    {
        iventOnGirl = false;
        scaneData._BoyEvents.PushBoxEventEnd();
        scaneData.ElectroExit();
    }

    private void UMGOnOff()
    {
        if(iventOnBoy == false && iventOnGirl == false)
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
            else if (girlUmg == true && boyUmg == false && scaneData._BoyMovement.ChangeActivePerson == 0)
            {
                infoButRef.SetActive(true);
                _infoButtons.SetPosGirl();
            }
            else if (girlUmg == true && boyUmg == false && scaneData._BoyMovement.ChangeActivePerson == 1)
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
        else if(iventOnBoy == true || iventOnGirl == true)
        {
            infoButRef.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlUmg = true;
            triggerOnOff = true;
            infoButRef.SetActive(true);
            _infoButtons.SetPosGirl();
        }

        if (other.tag == "PlayerBoy")
        {
            boyUmg = true;
            triggerOnOff = true;
            infoButRef.SetActive(true);
            _infoButtons.SetPosBoy();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlUmg = false;
            triggerOnOff = false;
            infoButRef.SetActive(false);
        }

        if (other.tag == "PlayerBoy")
        {
            boyUmg = false;
            triggerOnOff = false;
            infoButRef.SetActive(false);
        }
    }
}
