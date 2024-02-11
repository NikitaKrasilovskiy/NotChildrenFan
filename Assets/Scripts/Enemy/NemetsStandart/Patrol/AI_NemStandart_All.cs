using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStandart_All : MonoBehaviour
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
    public bool LeftRightDirection { get { return leftRightDirection; } set { leftRightDirection = value; } }

    private int patrollState;
    private bool isDistract;
    public bool toPatrolorNot;

    private bool isSeeBoyGirl;
    public bool IsSeeBoyGirl { get { return isSeeBoyGirl; } set { isSeeBoyGirl = value; } }


    // Start is called before the first frame update
    void Start()
    {
        animatorBP = GetComponentInChildren<Animator>();
        speed = 1.2f;
        moveSpot = patrollPoint_02;
    }

    // Update is called once per frame
    void Update()
    {
        if(toPatrolorNot == false)
        {
            if (isPatroll == true && patrollState == 1 && transform.position.x != patrollPoint_02.transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
                leftRightDirection = true;
            }
            else if (isPatroll == true && patrollState == 1 && transform.position.x == patrollPoint_02.transform.position.x)
            {
                Patroll_02Start();
            }
            else if (isPatroll == true && patrollState == 2 && transform.position.x != patrollPoint_01.transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
                leftRightDirection = false;
            }
            else if (isPatroll == true && patrollState == 2 && transform.position.x == patrollPoint_01.transform.position.x)
            {
                Patroll_01Start();
            }
        }

        //Debug.Log(leftRightDirection);
    }

    public void Patroll_01Start()
    {
        if (toPatrolorNot == false)
        {
            StartCoroutine(Patrol_01());
            allTriggers.SetActive(true);
        }
    }

    private void Patroll_02Start()
    {
        if (toPatrolorNot == false)
        {
            StartCoroutine(Patrol_02());
            allTriggers.SetActive(true);
        }
    }


    public void StopPatroll()
    {
        if (toPatrolorNot == false)
        {
            animatorBP.SetBool("isWalk", false);
            patrollState = 0;
            isPatroll = false;
            isSeeBoyGirl = true;
            StartCoroutine(Patrol_01());
        }
    }

    private void StandIdle()
    {
        if (toPatrolorNot == false)
        {
            animatorBP.SetBool("isWalk", false);
            patrollState = 0;
            isPatroll = false;
            isDistract = false;
            disTrigger.SetActive(true);
        }
    }

    //Перекур в патрулировании
    IEnumerator Patrol_01()
    {
        patrollState = 0;
        isPatroll = false;
        animatorBP.SetBool("isWalk", false);
        //allTriggers.SetActive(true);
        walkTrigger.SetActive(false);
        yield return new WaitForSeconds(10f);
        if (isSeeBoyGirl == false)
        {
            allTriggers.SetActive(false);
            walkTrigger.SetActive(true);
            moveSpot = patrollPoint_02;
            patrollState = 1;
            isPatroll = true;
            animatorBP.SetBool("isWalk", true);
            if(leftRight == 1)
            {
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if(leftRight == 2)
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else if (isSeeBoyGirl == true)
        {
            Patroll_01Start();
        }
    }

    //Перекур в патрулировании и движение обратно
    IEnumerator Patrol_02()
    {
        patrollState = 0;
        isPatroll = false;
        animatorBP.SetBool("isWalk", false);
        //allTriggers.SetActive(true);
        walkTrigger.SetActive(false);
        yield return new WaitForSeconds(10f);
        if (isSeeBoyGirl == false)
        {
            allTriggers.SetActive(false);
            walkTrigger.SetActive(true);
            moveSpot = patrollPoint_01;
            patrollState = 2;
            isPatroll = true;
            animatorBP.SetBool("isWalk", true);
            if (leftRight == 1)
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
            else if (leftRight == 2)
            {
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        else if (isSeeBoyGirl == true)
        {
            Patroll_02Start();
        }
    }
}
