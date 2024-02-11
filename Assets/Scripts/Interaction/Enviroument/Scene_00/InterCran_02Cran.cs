using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterCran_02Cran : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_02_Data scaneData;
    [SerializeField] private NewCran_02 cran_01;
    [SerializeField] private NewCran_01 cran_02;

    private bool boyOn;
    private bool exitOn;
    public bool ExitOn { get { return exitOn; } set { exitOn = value; } }
    private bool exitOnHalf;
    public bool ExitOnHalf { get { return exitOnHalf; } set { exitOnHalf = value; } }
    private Vector3 destinationPoint;
    public GameObject infoButRef;
    private bool boyUmg;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_02_Data>();
    }

    // Start is called before the first frame update
    void Start()
    {
        worckOnNeedItems = 0;
        destinationPoint = new Vector3(-3.502358f, 1.68f, 0);
    }

    private void Update()
    {
        if (exitOn == true)
        {
            scaneData.BoyRef.transform.position = Vector3.MoveTowards(scaneData.BoyRef.transform.position, new Vector3(scaneData.BoyRef.transform.position.x, 1f, 2), 1.5f * Time.deltaTime);
        }
        else if (exitOnHalf == true)
        {
            scaneData.BoyRef.transform.position = Vector3.MoveTowards(scaneData.BoyRef.transform.position, new Vector3(scaneData.BoyRef.transform.position.x, -1.995f, 2), 1.5f * Time.deltaTime);
        }
        UMGOnOff();
    }

    public override void EnvirWorck()
    {
        if (boyOn == true && cran_01.WorckOnHalfPlayerReady == false)
        {
            scaneData._BoyMovement.BoyStopMovement();
            scaneData._BoyAnimator.SetBool("isCran", true);
            Invoke("BoyOnCran", 0.5f);
            //Debug.Log("Висит на кране");
        }
        else if (boyOn == false && cran_01.WorckOnHalfPlayerReady == true || boyOn == true && cran_01.WorckOnHalfPlayerReady == true)
        {
            cran_01.WorckOnHalfPlayerReady = false;
            cran_02.WorckOnHalfPlayerReady = false;
            scaneData._BoyMovement.BoyStartMovement();
            scaneData._BoyAnimator.SetBool("isCran", false);

            BoyOffCran();
            //Debug.Log("Не Висит на кране");
        }
    }

    private void BoyOnCran()
    {
        if(scaneData._BoyMovement.HorizontalOrientation == 1)
        {
            scaneData.BoyRef.gameObject.transform.position = new Vector3(-237.456f, -1.995096f, 2);
            scaneData.BoyAnimPref.transform.localPosition = new Vector3(4.3f, -4.5f, 1f);
        }
        if (scaneData._BoyMovement.HorizontalOrientation == 0)
        {
            scaneData.BoyRef.gameObject.transform.position = new Vector3(-237.931f, -1.995096f, 2);
            scaneData.BoyAnimPref.transform.localPosition = new Vector3(4.4f, -5.04f, 1f);
        }
        scaneData.BoyAnimPref.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        cran_01.WorckOnHalfPlayerReady = true;
        cran_02.WorckOnHalfPlayerReady = true;
        scaneData._BoyMovement.ControlRot = true;
    }

    private void BoyOffCran()
    {
        scaneData.BoyRef.gameObject.transform.position = new Vector3(scaneData.BoyRef.gameObject.transform.position.x, scaneData.BoyRef.gameObject.transform.position.y, 0);
        scaneData.BoyAnimPref.transform.localScale = new Vector3(1f, 1f, 1f);
        scaneData.BoyAnimPref.transform.localPosition = new Vector3(1.35f, -0.5f, 0f);
        scaneData._BoyMovement.ControlRot = false;
    }

    public void StartCoroutineHalfWorck()
    {
        scaneData.StartCoroutineHalfWorck();
    }

    public void StartCoroutineWorck()
    {
        scaneData.StartCoroutineWorck();
    }

    private void UMGOnOff()
    {
        if (cran_01.WorckOnHalfPlayerReady == false)
        {
            if (boyUmg == true && scaneData._BoyMovement.ChangeActivePerson == 1)
            {
                infoButRef.SetActive(true);
                infoButRef.GetComponent<InfoButtons>().SetPosBoy();
            }
            else if (boyUmg == true && scaneData._BoyMovement.ChangeActivePerson == 0)
            {
                infoButRef.SetActive(false);
            }
        }
        else if (cran_01.WorckOnHalfPlayerReady == true)
        {
            infoButRef.SetActive(false);
        }
    }

    //Триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        //Взаимодействие с пацаном
        if (other.tag == "PlayerBoy")
        {
            boyOn = true;
            boyUmg = true;
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosBoy();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            boyOn = false;
            boyUmg = false;
            infoButRef.SetActive(false);
        }
    }
}
