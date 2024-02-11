using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scane_05_Data : MonoBehaviour
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
    private BoyUsebleItems _boyUseItem;
    public BoyUsebleItems _BoyUseItem { get { return _boyUseItem; } set { _boyUseItem = value; } }

    [SerializeField] private GameObject girlRef;
    public GameObject GirlRef { get { return girlRef; } set { girlRef = value; } }
    private Animator _girlAnimator;
    public Animator _GirlAnimator { get { return _girlAnimator; } set { _girlAnimator = value; } }
    private GirlMovement _girlMovement;
    public GirlMovement _GirlMovement { get { return _girlMovement; } set { _girlMovement = value; } }
    private GirlEvents _girlEvents;
    public GirlEvents _GirlEvents { get { return _girlEvents; } set { _girlEvents = value; } }
    private GirlUsebleItems _girlUseItem;
    public GirlUsebleItems _GirlUseItem { get { return _girlUseItem; } set { _girlUseItem = value; } }

    private GameObject blackScreen;
    [SerializeField] private GameObject cameraGirl;
    [SerializeField] private GameObject cameraBoy;
    [SerializeField] private UMG_Canvas_All _canvasRef;
    [SerializeField] private GameObject _canvasDinamit;
    public int stateGame;

    [SerializeField] private GameObject itemsBoom;
    [SerializeField] private Sprite girlDinamit;
    [SerializeField] private Sprite boyClook;
    [SerializeField] private GameObject clock;
    public GameObject dinamit_01;
    public GameObject dinamit_02;
    public GameObject dinamit_03;
    public bool[] dinamitOn;
    private int timerTime;
    [SerializeField] private Text timerText;

    private void Awake()
    {
        _boyMovement = boyRef.GetComponent<BoyMovement>();
        _girlMovement = girlRef.GetComponent<GirlMovement>();
        _girlEvents = girlRef.GetComponent<GirlEvents>();
        _boyEvents = boyRef.GetComponent<BoyEvents>();
        _girlAnimator = girlRef.GetComponentInChildren<Animator>();
        _boyAnimator = boyRef.GetComponentInChildren<Animator>();
        _boyUseItem = boyRef.GetComponent<BoyUsebleItems>();
        _boyThrow = boyRef.GetComponent<BoyThrow>();
        _girlUseItem = girlRef.GetComponent<GirlUsebleItems>();
        _canvasRef = _canvasRef.GetComponent<UMG_Canvas_All>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DevStart();
        dinamitOn = new bool[3];
        StartScreen();
        timerTime = 45;
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
                boyRef.transform.position = new Vector3(-294.59f, 0.25f, 2);
                girlRef.transform.position = new Vector3(-296.43f, 0.25f, 2);
                boyRef.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                _girlMovement.CantChange = true;
                _boyThrow.AmountRockAmmo = 3;
                _boyMovement.CantChange = true;
                _girlMovement.GirlStopMovement();
                _boyMovement.BoyStopMovement();
                _girlMovement.BoyActive();
                _boyMovement.BoyActive();
                _girlMovement.ControlRot = true;
                break;
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:

                break;
        }
    }

    public void RPSWin()
    {
        itemsBoom.SetActive(false);
        _boyUseItem.useblItemInHand.sprite = boyClook;
        _girlUseItem.useblItemInHand.sprite = girlDinamit;
        _boyUseItem.useblItemInHand.transform.localScale = new Vector3(1, 1, 1);
        _girlUseItem.useblItemInHand.transform.localScale = new Vector3(1, 1, 1);
        _girlEvents.GirlRunToPosition = -273.84f;
        _girlEvents.GirlRunToPositionEvent = true;
        _girlEvents.Event_07();
    }

    private void DinamitTimer()
    {
        timerTime  -= 1;

        if(timerTime > 0)
        {
            Invoke("DinamitTimer", 1);
        }
        else if(timerTime == 0)
        {
            SceneManager.LoadScene("5_Demo");
        }
    }

    public void Dinamit_01On()
    {
        _girlEvents.GirlRunToPosition = -231.37f;
        _girlEvents.GirlRunToPositionEventState = 1;
        _girlEvents.GirlRunToPositionEvent = true;
        _canvasDinamit.SetActive(true);
        clock.GetComponent<Animator>().SetBool("ClockOn", true);
        _girlEvents.Event_07();
        DinamitTimer();
    }

    public void Dinamit_02On()
    {
        _girlEvents.GirlRunToPosition = -185.67f;
        _girlEvents.GirlRunToPositionEventState = 2;
        _girlEvents.GirlRunToPositionEvent = true;
        _girlEvents.Event_07();
    }

    public void Dinamit_03On()
    {
        if(dinamitOn[0] == true && dinamitOn[1] == true && dinamitOn[2] == true)
        {
            StartCoroutine(nextLvL());
        }
    }

    public void OnGirl()
    {
        _girlUseItem.useblItemInHand.sprite = null;
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
        SceneManager.LoadScene("6_Demo");
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
        _canvasRef.RPSBoyChose();
        _canvasRef.RpsBoyGirlWin = 1;
    }
}
