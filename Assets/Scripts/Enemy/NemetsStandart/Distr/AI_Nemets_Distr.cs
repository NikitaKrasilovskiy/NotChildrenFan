using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Nemets_Distr : MonoBehaviour
{
    public GameObject allTriggers;
    public GameObject walkTrigger;
    public GameObject disTrigger;
    //1 смотрит в лево
    //2 смотрит в право
    public int leftRight;
    private Animator animatorBP;
    private bool isPatroll;
    public bool IsPatroll { get { return isPatroll; } set { isPatroll = value; } }
    private Transform moveSpot;
    public Transform patrollPoint_01;
    public Transform patrollPoint_02;
    private float speed;
    private bool leftRightDirection;
    private int patrollState;
    private bool isDistract;
    private bool isDistrFara;

    private bool isSeeBoyGirl;
    public bool IsSeeBoyGirl { get { return isSeeBoyGirl; } set { isSeeBoyGirl = value; } }


    // Start is called before the first frame update
    void Start()
    {
        animatorBP = GetComponentInChildren<Animator>();
        speed = 1.2f;
        moveSpot = patrollPoint_01;
    }

    // Update is called once per frame
    void Update()
    {   
        if(isDistrFara == true && transform.position.x != patrollPoint_01.transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }
        else if (isDistrFara == true && transform.position.x == patrollPoint_01.transform.position.x)
        {
            StopFara();
        }


        if (isDistract == true && patrollState == 1 && transform.position.x != patrollPoint_02.transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }
        else if (isDistract == true && patrollState == 1 && transform.position.x == patrollPoint_02.transform.position.x)
        {
            StartDist_03();
        }
        else if (isDistract == true && patrollState == 2 && transform.position.x != patrollPoint_01.transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }
        else if (isDistract == true && patrollState == 2 && transform.position.x == patrollPoint_01.transform.position.x)
        {
            StandIdle();
        }
    }

    public void Patroll_01Start()
    {       
        allTriggers.SetActive(true);
    }

    private void Patroll_02Start()
    {        
        allTriggers.SetActive(true);
    }


    public void StopPatroll()
    {
        animatorBP.SetBool("isWalk", false);
        isPatroll = false;
        isSeeBoyGirl = true;
        isDistract = false;
        Invoke("PlayDistrPatrol", 2);

    }

    private void PlayDistrPatrol()
    {
        isDistract = true;
        animatorBP.SetBool("isWalk", true);
    }

    private void StandIdle()
    {
        animatorBP.SetBool("isWalk", false);
        patrollState = 0;
        isPatroll = false;
        isDistract = false;
        disTrigger.SetActive(true);
        allTriggers.SetActive(true);
        walkTrigger.SetActive(false);
    }

    public void StartDist()
    {
        StartCoroutine(PatrolDistr_02());
    }

    public void StartDist_03()
    {
        StartCoroutine(PatrolDistr_03());
    }

    public void StopFara()
    {
        animatorBP.SetBool("isWalk", false);
        patrollState = 0;
        isDistrFara = false;
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        allTriggers.SetActive(true);
        walkTrigger.SetActive(false);
    }

    public void DistrFara()
    {
        StartCoroutine(PatrolDistr_01());
    }

    //Фара отходит
    IEnumerator PatrolDistr_01()
    {
        patrollState = 0;
        animatorBP.SetInteger("SeeBoyState", 1);
        transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        yield return new WaitForSeconds(1f);
        animatorBP.SetInteger("SeeBoyState", 0);
        isDistrFara = true;
        allTriggers.SetActive(false);
        walkTrigger.SetActive(true);
        animatorBP.SetBool("isWalk", true);       
    }

    //Патруль отвлечение
    IEnumerator PatrolDistr_02()
    {
        moveSpot = patrollPoint_02;
        animatorBP.SetInteger("SeeBoyState", 1);
        transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        allTriggers.SetActive(true);
        walkTrigger.SetActive(false);
        yield return new WaitForSeconds(1f);
        animatorBP.SetInteger("SeeBoyState", 0);
        patrollState = 1;
        isDistract = true;
        allTriggers.SetActive(false);
        walkTrigger.SetActive(true);
        animatorBP.SetBool("isWalk", true);
    }

    //Патруль отвлечение
    IEnumerator PatrolDistr_03()
    {
        patrollState = 0;
        moveSpot = patrollPoint_01;
        animatorBP.SetBool("isWalk", false);
        isDistract = false;
        yield return new WaitForSeconds(20f);
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        patrollState = 2;
        isDistract = true;
        allTriggers.SetActive(false);
        walkTrigger.SetActive(true);
        animatorBP.SetBool("isWalk", true);
    }
}
