using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCran_01 : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_02_Data scaneData;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject cranRef;
    private NewCran_02 _cranRef;

    private int rwchagState;
    public GameObject infoButRef;
    private bool girlUmg;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_02_Data>();
        _cranRef = cranRef.GetComponent<NewCran_02>();
    }

    private void Start()
    {           
        worckOnNeedItems = 0;      
    }

    private void Update()
    {
        UMGOnOff();      
    }


    private void RwchagDown()
    {
        animator.SetInteger("AnimState", 2);
    }

    private void RwchagDown_02()
    {
        animator.SetInteger("AnimState", 4);
    }

    private void RwchagUp()
    {
        animator.SetInteger("AnimState", 3);
    }

    public override void EnvirWorck()
    {
        scaneData.GirlRef.transform.position = new Vector3(-232.3645f, 0.1449997f, 2);
        scaneData.GirlRef.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        if (rwchagState == 0)
        {
            //Вниз
            scaneData._GirlAnimator.SetInteger("RwchagState", 1);
            Invoke("ResetWorckOn", 0.7f);
        }
        if (rwchagState == 1)
        {
            //Вверх
            scaneData._GirlAnimator.SetInteger("RwchagState", 2);
            Invoke("RwchagDown", 0.6f);
            Invoke("ResetWorckOff", 1.3f);
        }
        else if (rwchagState == 2)
        {
            //Вниз
            scaneData._GirlAnimator.SetInteger("RwchagState", 3);
            Invoke("RwchagUp", 0.6f);
            Invoke("ResetWorckOn", 1.3f);
        }      
        base.EnvirWorck();
    }



    private void ResetWorckOn()
    {
        if (rwchagState == 0)
        {
            animator.SetInteger("AnimState", 1);
            rwchagState = 1;
            _cranRef.CranDown();
        }
        else if (rwchagState == 2)
        {
            rwchagState = 1;
            _cranRef.CranDown();
        }
    }

    private void ResetWorckOff()
    {
        if (rwchagState == 1)
        {
            rwchagState = 2;
            _cranRef.CranUp();
            if(WorckOnHalfPlayerReady == true)
            {
                Invoke("ResetcranWorck", 2);
            }
        }
    }

    private void ResetcranWorck()
    {
        animator.SetInteger("AnimState", 3);
        Invoke("ResetWorckOn", 1.3f);
    }

    private void UMGOnOff()
    {
        if (girlUmg == true && scaneData._GirlMovement.ChangeActivePerson == 0)
        {
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
        }
        else if (girlUmg == true && scaneData._GirlMovement.ChangeActivePerson == 1)
        {
            infoButRef.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlUmg = true;
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlUmg = false;
            infoButRef.SetActive(false);
        }
    }
}
