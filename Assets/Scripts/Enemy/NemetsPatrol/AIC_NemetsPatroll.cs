using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIC_NemetsPatroll : MonoBehaviour
{
    private Animator animatorBP;
    private bool isPatroll;
    private Transform moveSpot;
    public Transform patrollPoint_01;
    public Transform patrollPoint_02;
    private float speed;
    private bool leftRightDirection;
    private int patrollState;


    // Start is called before the first frame update
    void Start()
    {
        animatorBP = GetComponentInChildren<Animator>();
        speed = 1.2f;
        moveSpot = patrollPoint_02;
        Patroll_01Start();
    }


    // Update is called once per frame
    void Update()
    {
        if(isPatroll == true && patrollState == 1 && transform.position != patrollPoint_02.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }
        else if(isPatroll == true && patrollState == 1 && transform.position == patrollPoint_02.transform.position)
        {
            StartCoroutine(Patrol_02());
        }
        else if (isPatroll == true && patrollState == 2 && transform.position != patrollPoint_01.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }
        else if (isPatroll == true && patrollState == 2 && transform.position == patrollPoint_01.transform.position)
        {
            StartCoroutine(Patrol_03());
        }
    }




    public void Patroll_01Start()
    {
        StartCoroutine(Patrol_01());
    }

    //Начинает патрулирование когда девочка первый раз входит в тригер
    IEnumerator Patrol_01()
    {
        patrollState = 1;
        animatorBP.SetBool("isWalk", false);
        yield return new WaitForSeconds(10f);
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        animatorBP.SetBool("isWalk", true);
        isPatroll = true;
    }

    //Перекур в патрулировании и движение обратно
    IEnumerator Patrol_02()
    {
        patrollState = 0;
        isPatroll = false;
        animatorBP.SetBool("isWalk", false);
        yield return new WaitForSeconds(10f);
        moveSpot = patrollPoint_01;
        patrollState = 2;
        isPatroll = true;
        transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        animatorBP.SetBool("isWalk", true);
    }

    //Перекур в патрулировании
    IEnumerator Patrol_03()
    {
        patrollState = 0;
        isPatroll = false;
        animatorBP.SetBool("isWalk", false);
        yield return new WaitForSeconds(10f);
        moveSpot = patrollPoint_02;
        patrollState = 1;
        isPatroll = true;
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        animatorBP.SetBool("isWalk", true);
    }
}
