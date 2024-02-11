using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageDoor : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_03_Data scaneData;

    [SerializeField] private GameObject infoButRef;
    InfoButtons _infoButtons;

    private GameObject doorLeft;
    private GameObject doorRight;
    [SerializeField] public GameObject zamokOn;
    [SerializeField] public GameObject nemets;
    [SerializeField] public GameObject savePoint_02;
    [SerializeField] public GameObject savePoint_03;
    [SerializeField] public GameObject light_01;
    [SerializeField] public GameObject light_02;
    [SerializeField] public GameObject brick;
    private bool boyUmg;
    private bool girlUmg;
    private bool doorNotOpen;
    public bool DoorNotOpen { get { return doorNotOpen; } set { doorNotOpen = value; } }
    private bool firstUse;
    //public GameObject infoButRef;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_03_Data>();
        _infoButtons = infoButRef.GetComponent<InfoButtons>();
    }

    // Start is called before the first frame update
    void Start()
    {
        doorLeft = transform.Find("DoorLeft").gameObject;
        doorRight = transform.Find("DoorRight").gameObject;
        IndexItemImage = 6;
        worckOnNeedItemsIndex_01 = 6;
        worckOnNeedItems = 1;
        needItem = true;
        comixOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        UMGOnOff();
    }

    public override void EnvirNotWorck()
    {
        if(doorNotOpen == false)
        {
            //Когда используется в первый раз призывает замок на машину и второго немца
            if(firstUse == false)
            {
                firstUse = true;
                zamokOn.GetComponent<EnvirLockCar_02>().OnOff = true;
                nemets.transform.position = new Vector3(-300f, -2.303f, 0);
                savePoint_02.SetActive(false);
                savePoint_03.SetActive(true);
                light_01.SetActive(false);
                light_02.SetActive(true);
                brick.SetActive(true);
            }

            doorNotOpen = true;
            NotOpen();
        }
        base.EnvirNotWorck();
    }

    public override void EnvirWorck()
    {
        doorLeft.GetComponent<Animator>().SetInteger("doorAnimState", 2);
        doorRight.GetComponent<Animator>().SetInteger("doorAnimState", 2);

        if(scaneData.BoyDoorOn == true && scaneData.GirlDoorOn == true)
        {
            scaneData.GoNextLvL();
        }
        base.EnvirWorck();
    }

    public void NotOpen()
    {
        doorLeft.GetComponent<Animator>().SetInteger("doorAnimState", 1);
        doorRight.GetComponent<Animator>().SetInteger("doorAnimState", 1);
    }

    private void UMGOnOff()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlUmg = true;
            infoButRef.SetActive(true);
            _infoButtons.SetPosGirl();
        }

        if (other.tag == "PlayerBoy")
        {
            boyUmg = true;
            infoButRef.SetActive(true);
            _infoButtons.SetPosBoy();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlUmg = false;
            infoButRef.SetActive(false);
        }

        if (other.tag == "PlayerBoy")
        {
            boyUmg = false;
            infoButRef.SetActive(false);
        }
    }
}
