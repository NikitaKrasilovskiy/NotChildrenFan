using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scane_02_Data : MonoBehaviour
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

    [SerializeField] private GameObject boyTrigger;
    [SerializeField] private GameObject boyTrigger_02;
    [SerializeField] private GameObject generalCar;
    [SerializeField] private InterCran_02Cran _cranRef;

    [SerializeField] private UMG_Canvas_All _canvas;
    public int stateGame;
    private GameObject blackScreen;
    [SerializeField] private GameObject cameraGirl;
    [SerializeField] private GameObject cameraBoy;



    private void Awake()
    {
        _boyMovement = boyRef.GetComponent<BoyMovement>();
        _girlMovement = girlRef.GetComponent<GirlMovement>();
        _girlEvents = girlRef.GetComponent<GirlEvents>();
        _boyEvents = boyRef.GetComponent<BoyEvents>();
        _girlAnimator = girlRef.GetComponentInChildren<Animator>();
        _boyAnimator = boyRef.GetComponentInChildren<Animator>();
        _boyThrow = boyRef.GetComponent<BoyThrow>();
        _cranRef = _cranRef.GetComponent<InterCran_02Cran>();
        _canvas = _canvas.GetComponent<UMG_Canvas_All>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartScreen();
        DevStart();
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
                boyRef.transform.position = new Vector3(-296.24f, -1.713435f, 0);
                girlRef.transform.position = new Vector3(-295.32f, -1.655756f, 0);
                _girlMovement.CantChange = true;
                _boyMovement.CantChange = true;
                _girlMovement.GirlStopMovement();
                _girlMovement.BoyActive();
                _girlMovement.ControlRot = true;
                _boyMovement.BoyActive();
                _girlEvents.Event_00();
                break;
            case 1:
                ///Переписать!!! после билда
                boyRef.transform.position = new Vector3(-236.66f, -1.996f, 0);
                girlRef.transform.position = new Vector3(-237.93f, -1.98232f, 0);
                _girlMovement.CantChange = false;
                _boyMovement.CantChange = false;
                _boyThrow.AmountRockAmmo = 3;
                //girlRef.GetComponent<GirlMovement>().GirlCryOn();
                _girlEvents.EventOffOn = true;
                Destroy(generalCar);
                break;
            case 2:
                boyRef.transform.position = new Vector3(-262.09f, -1.996f, 0);
                girlRef.transform.position = new Vector3(-263.36f, -1.98f, 0);
                _girlMovement.CantChange = false;
                _boyMovement.CantChange = false;
                _girlMovement.BoyActive();
                _boyMovement.BoyActive();
                //girlRef.GetComponent<GirlMovement>().GirlCryOn();
                Destroy(generalCar);
                break;
            case 3:

                break;
        }
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

    //Генерал палит пацана
    public void GeneralSeeBoyGirl()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        StartCoroutine(BoyGerlRess());
    }

    IEnumerator BoyGerlRess()
    {
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        yield return new WaitForSeconds(1f);
        girlRef.GetComponentInChildren<Animator>().SetInteger("ScaneMoveState", 0);
        girlRef.transform.position = new Vector3(-295.32f, -1.655756f, 0);
        boyRef.transform.position = new Vector3(-296.24f, -1.713435f, 0);
        generalCar.gameObject.transform.position = new Vector3(-316.61f, -1.09f, 0);
        generalCar.GetComponent<Scane_02_General>().GeneralOn = false;
        yield return new WaitForSeconds(2f);
        _GirlEvents.Event_00();
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", false);
        yield return new WaitForSeconds(4f);
        generalCar.GetComponent<Scane_02_General>().StartGeneral();
    }

    //Генерал умирает
    public void GeneralOff()
    {
        _girlEvents.runPoint_01.transform.position = new Vector3(-282.87f, -0.05002832f, 0);
        _GirlEvents.Event_000();
        Destroy(boyTrigger);
        Destroy(boyTrigger_02);
        Destroy(generalCar);
    }

    public void StartCoroutineHalfWorck()
    {
        StartCoroutine(HalfWorck());
    }

    public void StartCoroutineWorck()
    {
        StartCoroutine(ExitLvL());
    }

    //Поднимает на половину
    IEnumerator HalfWorck()
    {
        _boyMovement.CantChange = true;
        _girlMovement.CantChange = true;
        boyRef.GetComponent<Rigidbody2D>().simulated = false;
        _cranRef.ExitOn = true;
        yield return new WaitForSeconds(1.7f);
        _cranRef.ExitOn = false;
        _cranRef.ExitOnHalf = true;
        yield return new WaitForSeconds(1.7f);
        _boyMovement.CantChange = false;
        _girlMovement.CantChange = false;
        boyRef.GetComponent<Rigidbody2D>().simulated = true;
        _cranRef.ExitOnHalf = false;
    }

    //Переход на следующий уровень
    IEnumerator ExitLvL()
    {
        _cranRef.ExitOn = true;
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        _boyMovement.CantChange = true;
        _girlMovement.CantChange = true;
        //boyRef.GetComponent<BoyEvents>().BoyStopMovement();
        boyRef.GetComponent<Rigidbody2D>().simulated = false;
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("3_Demo");
    }

    public void GeneralImageOn()
    {
        _canvas.GeneralImage();
    }
}
