using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.Rendering.Universal;

public class Scane_04_Data : MonoBehaviour
{
    [SerializeField] private GameObject boyRef;
    public GameObject BoyRef { get { return boyRef; } set { boyRef = value; } }
    [SerializeField] private GameObject boyAnimPref;
    public GameObject BoyAnimPref { get { return boyAnimPref; } set { boyAnimPref = value; } }
    private Animator _boyAnimator;
    public Animator _BoyAnimator { get { return _boyAnimator; } set { _boyAnimator = value; } }
    private BoyMovement _boyMovement;
    public BoyMovement _BoyMovement { get { return _boyMovement; } set { _boyMovement = value; } }
    private BoyEvents _boyEvents;
    public BoyEvents _BoyEvents { get { return _boyEvents; } set { _boyEvents = value; } }
    private BoyThrow _boyThrow;
    public BoyThrow _BoyThrow { get { return _boyThrow; } set { _boyThrow = value; } }

    [SerializeField] private GameObject girlRef;
    public GameObject GirlRef { get { return girlRef; } set { girlRef = value; } }
    private Animator _girlAnimator;
    public Animator _GirlAnimator { get { return _girlAnimator; } set { _girlAnimator = value; } }
    private GirlMovement _girlMovement;
    public GirlMovement _GirlMovement { get { return _girlMovement; } set { _girlMovement = value; } }
    private GirlEvents _girlEvents;
    public GirlEvents _GirlEvents { get { return _girlEvents; } set { _girlEvents = value; } }

    private GameObject blackScreen;
    [SerializeField] private GameObject cameraGirl;
    [SerializeField] private GameObject cameraBoy;
    [SerializeField] private ElectroPlayer electroPlayer;
    public int stateGame;

    [SerializeField] private GameObject paytnashkiScane;
    [SerializeField] private GameObject paytnashkiBox;
    [SerializeField] private GameObject paytriggerZone;
    [SerializeField] private GameObject boxEventRef;
    [SerializeField] private GameObject electroShit;
    [SerializeField] private GameObject paytnaskiCollision;

    [SerializeField] private GameObject door_01;
    [SerializeField] private GameObject shitok;
    [SerializeField] private GameObject redLight;
    //[SerializeField] private Light2D redLamp; 

    private bool[] pickUpItems;
    public bool[] PickUpItems { get { return pickUpItems; } set { pickUpItems = value; } }
    private int[] whireSave;
    public int[] WhireSave { get { return whireSave; } set { whireSave = value; } }
    private bool paytnashkiOn;
    public bool PaytnashkiOn { get { return paytnashkiOn; } set { paytnashkiOn = value; } }

    private void Awake()
    {
        _boyMovement = boyRef.GetComponent<BoyMovement>();
        _girlMovement = girlRef.GetComponent<GirlMovement>();
        _girlEvents = girlRef.GetComponent<GirlEvents>();
        _boyEvents = boyRef.GetComponent<BoyEvents>();
        _girlAnimator = girlRef.GetComponentInChildren<Animator>();
        _boyAnimator = boyRef.GetComponentInChildren<Animator>();
        _boyThrow = boyRef.GetComponent<BoyThrow>();
    }

    // Start is called before the first frame update
    void Start()
    {       
        DevStart();
        whireSave = new int[6];
        pickUpItems = new bool[3];
        StartScreen();
    }

    private void Update()
    {
        if (_girlMovement.ChangeActivePerson == 0)
        {
            cameraBoy.SetActive(false);
            cameraGirl.SetActive(true);
        }
        else if (_girlMovement.ChangeActivePerson == 1)
        {
            cameraBoy.SetActive(true);
            cameraGirl.SetActive(false);
        }
    }

    private void DevStart()
    {
        switch (stateGame)
        {
            case 0:
                boyRef.transform.position = new Vector3(-255.51f, -1.93f, 0);
                girlRef.transform.position = new Vector3(-256.67f, -1.93f, 0);
                _boyThrow.AmountRockAmmo = 3;
                _girlMovement.CantChange = false;
                _boyMovement.CantChange = false;
                _girlMovement.BoyActive();
                _boyMovement.BoyActive();
                _boyMovement.IsCanGirlCall = true;
                _girlMovement.IsCanBoyCall = true;
                break;
            case 1:
                boyRef.transform.position = new Vector3(-238.78f, -1.93f, 0);
                girlRef.transform.position = new Vector3(-240.01f, -1.93f, 0);
                _boyThrow.AmountRockAmmo = 3;
                _girlMovement.CantChange = false;
                _boyMovement.CantChange = false;
                //PaytnashkiWin_02();
                break;
            case 2:
                boyRef.transform.position = new Vector3(-255.51f, -1.93f, 0);
                girlRef.transform.position = new Vector3(-256.67f, -1.93f, 0);
                _boyThrow.AmountRockAmmo = 3;
                _girlMovement.CantChange = false;
                _boyMovement.CantChange = false;
                openDoors();
                //PaytnashkiWin_02();
                break;
            case 3:

                break;
        }
    }

    public void LoadNextLvL()
    {
        if(pickUpItems[0] == true && pickUpItems[1] == true)
        {
            StartCoroutine(nextLvL());
        }
    }

    IEnumerator nextLvL()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        _boyMovement.CantChange = true;
        _girlMovement.CantChange = true;
        _boyMovement.BoyStopMovement();
        _girlMovement.GirlStopMovement();
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("5_Demo");
    }

    public void openDoors()
    {
        door_01.SetActive(false);
        shitok.GetComponent<Scane_04ShitokInfo>().onOff = true;
    }

    //Запускает пятнашки
    public void PaytnashkiStart()
    {
        StartCoroutine(Paytnashki());
    }

    IEnumerator Paytnashki()
    {
        paytnashkiOn = true;
        _boyMovement.CantChange = true;
        _girlMovement.CantChange = true;
        _boyMovement.BoyStopMovement();
        _girlMovement.GirlStopMovement();
        yield return new WaitForSeconds(1f);
        paytnashkiScane.SetActive(true);
        paytnashkiBox.SetActive(true);
        paytriggerZone.SetActive(true);
    }

    //Выключает пятнашки
    public void PaytnashkiFinish()
    {
        paytnashkiOn = false;
        _boyMovement.CantChange = false;
        _girlMovement.CantChange = false;
        _boyMovement.BoyStartMovement();
        _girlMovement.GirlStartMovement();
        paytnashkiScane.SetActive(false);
        paytnashkiBox.SetActive(false);
        paytriggerZone.SetActive(false);
    }

    //Выbграл пятнашки
    public void PaytnashkiWin()
    {
        _boyMovement.PushBoxExit();
        Invoke("PaytnashkiWin_02", 1.5f);
    }

    private void PaytnashkiWin_02()
    {
        paytnashkiOn = false;
        paytnashkiScane.SetActive(false);
        paytnashkiBox.SetActive(false);
        paytriggerZone.SetActive(false);
        boxEventRef.SetActive(false);
        paytnaskiCollision.SetActive(false);
        _girlMovement.CantChange = false;
        _boyMovement.CantChange = false;
        _boyMovement.BoyStartMovement();
        _girlMovement.GirlStartMovement();
    }

    //Запускает електрошит ивент
    public void ElectroStart()
    {
        StartCoroutine(ElektroShit());
    }

    IEnumerator ElektroShit()
    {
        yield return new WaitForSeconds(0.5f);
        electroShit.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    //Выключает електрошит
    public void ElectroExit()
    {
        electroShit.SetActive(false);
    }

    //Выключает електрошит
    public void ElectroWin()
    {
        electroShit.SetActive(false);
        redLight.SetActive(true);
        RedLampLightPlus();
    }

    private void RedLampLightPlus()
    {
        //if(redLamp.GetComponent<Light2D>().intensity < 1)
        //{
        //    redLamp.GetComponent<Light2D>().intensity += 0.2f;
        //    Invoke("RedLampLightPlus", 0.1f);
        //}
        //else if(redLamp.GetComponent<Light2D>().intensity == 1)
        //{
        //    redLamp.GetComponent<Light2D>().intensity -= 0.2f;
        //    Invoke("RedLampLightMinus", 0.1f);
        //}
    }

    private void RedLampLightMinus()
    {
        //if (redLamp.GetComponent<Light2D>().intensity > 0)
        //{
        //    redLamp.GetComponent<Light2D>().intensity -= 0.2f;
        //    Invoke("RedLampLightMinus", 0.1f);
        //}
        //else if (redLamp.GetComponent<Light2D>().intensity < 0)
        //{
        //    redLamp.GetComponent<Light2D>().intensity += 0.2f;
        //    Invoke("RedLampLightPlus", 0.1f);
        //}
    }

    public void StartScreen()
    {
        StartCoroutine(StartComponent());
    }

    IEnumerator StartComponent()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", false);
        yield return new WaitForSeconds(1f);
    }
}
