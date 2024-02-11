using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_Data_06 : MonoBehaviour
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
    //public GameObject boyRef;
    //public GameObject girlRef;
    public GameObject cameraGirl;
    public GameObject cameraBoy;
    public int stateGame;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        DevStart();
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
                boyRef.transform.position = new Vector3(-179.041f, -1.93f, 0);
                girlRef.transform.position = new Vector3(-180.33f, -1.93f, 0);
                _girlMovement.ControlRot = true;
                _boyThrow.AmountRockAmmo = 3;
                _girlMovement.CantChange = true;
                _boyMovement.CantChange = true;
                _girlMovement.BoyActive();
                _boyMovement.BoyActive();
                RunToGrand();
                break;
            case 1:
               
                break;
            case 2:
                
                break;
            case 3:

                break;
        }
    }

    private void RunToGrand()
    {
        _girlEvents.GirlRunToPosition = -159.56f;
        _girlEvents.GirlRunToPositionEventState = 1;
        _girlEvents.Event_07();
    }

    public void LoadNextLvL()
    {
        StartCoroutine(nextLvL());
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

    public void FinishScreen()
    {
        StartCoroutine(FinishComponent());
    }

    IEnumerator FinishComponent()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        _boyMovement.CantChange = true;
        _girlMovement.CantChange = true;
        _boyMovement.BoyStopMovement();
        _girlMovement.GirlStopMovement();
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        yield return new WaitForSeconds(1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy" || other.tag == "Player")
        {
            girlRef.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            FinishScreen();
        }
    }
}
