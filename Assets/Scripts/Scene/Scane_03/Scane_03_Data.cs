using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scane_03_Data : MonoBehaviour
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

    [SerializeField] public GameObject cameraGirl;
    [SerializeField] public GameObject cameraBoy;

    public GameObject mouse;
    [SerializeField] private UMG_Canvas_All _canvasRef;
    [SerializeField] private GameObject event_04;
    [SerializeField] private GameObject nemets_01;
    [SerializeField] private GameObject savePoint_02;

    private bool boyDoorOn;
    public bool BoyDoorOn { get { return boyDoorOn; } set { boyDoorOn = value; } }
    private bool girlDoorOn;
    public bool GirlDoorOn { get { return girlDoorOn; } set { girlDoorOn = value; } }

    private bool rpsOrnot;
    public int stateGame;
    private GameObject blackScreen;

    private void Awake()
    {
        _boyMovement = boyRef.GetComponent<BoyMovement>();
        _girlMovement = girlRef.GetComponent<GirlMovement>();
        _girlEvents = girlRef.GetComponent<GirlEvents>();
        _boyEvents = boyRef.GetComponent<BoyEvents>();
        _boyThrow = boyRef.GetComponent<BoyThrow>();
        _girlAnimator = girlRef.GetComponentInChildren<Animator>();
        _boyAnimator = boyRef.GetComponentInChildren<Animator>();
        _canvasRef = _canvasRef.GetComponent<UMG_Canvas_All>();
    }

    // Start is called before the first frame update
    void Start()
    {       
        DevStart();
        StartScreen();
    }

    private void Update()
    {
        if(_girlMovement.ChangeActivePerson == 0)
        {
            cameraBoy.SetActive(false);
            cameraGirl.SetActive(true);
        }
        else if(_girlMovement.ChangeActivePerson == 1)
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
                boyRef.transform.position = new Vector3(-302.71f, -1.713435f, 0);
                girlRef.transform.position = new Vector3(-303.87f, -1.655756f, 0);
                boyRef.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                _girlMovement.CantChange = true;
                _boyThrow.AmountRockAmmo = 3;
                _boyMovement.CantChange = true;
                _girlMovement.GirlStopMovement();
                _boyMovement.BoyStopMovement();
                _girlMovement.GirlActive();
                _boyMovement.GirlActive();
                break;
            case 1:
                ///Переписать!!! после билда
                boyRef.transform.position = new Vector3(-255.51f, -1.713435f, 0);
                girlRef.transform.position = new Vector3(-256.67f, -1.655756f, 0);
                _boyThrow.AmountRockAmmo = 3;
                _girlMovement.CantChange = false;
                _boyMovement.CantChange = false;
                _boyEvents.CurentSavePosition = savePoint_02.transform.position;
                _girlEvents.CurentSavePosition = savePoint_02.transform.position;
                nemets_01.GetComponent<AI_NemStandart_All>().Patroll_01Start();
                mouse.SetActive(false);
                event_04.SetActive(false);
                rpsOrnot = true;
                break;
            case 2:

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
        yield return new WaitForSeconds(0.5f);
        if(rpsOrnot == false)
        {
            _canvasRef.RPSGirlChose();
            _canvasRef.RpsBoyGirlWin = 2;
        }
    }

    //Девочка убегает
    private void GirlEndRun()
    {
        if (_girlEvents.EventAdd[6] == true)
        {
            _girlEvents.Event_06_01();
            event_04.SetActive(false);
            _boyMovement.IsCanGirlCall = true;
            _girlMovement.IsCanBoyCall = true;
        }
    }

    public void GoNextLvL()
    {
        StartCoroutine(NextLvL());
    }

    //Поднимает на половину
    IEnumerator NextLvL()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        _BoyMovement.CantChange = true;
        _GirlMovement.CantChange = true;
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("4_Demo");
    }

    public void MapImageOn()
    {
        _canvasRef.MapIvent();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("GirlEndRun", 0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
