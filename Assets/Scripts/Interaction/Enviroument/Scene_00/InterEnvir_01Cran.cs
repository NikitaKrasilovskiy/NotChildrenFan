using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterEnvir_01Cran : EnvirInterBoyGirl_Class
{
    private GameObject cranHand;
    private bool worckInProgres;
    public bool WorckInProgres { get { return worckInProgres; } set { worckInProgres = value; } }
    private bool cranWorck;
    private Vector3 destinationPoint_01;
    private Vector3 destinationPoint_02;
    private Vector3 destinationPoint_03;
    private Vector3 destinationPoint_04;
    public Animator animator;
    public Animator girlAnimator; 
    private int rwchagState;
    //private float smoothing;

    private GameObject girlRef;
    public GameObject infoButRef;
    private bool girlUmg;

    private void Start()
    {
        girlRef = GameObject.FindGameObjectWithTag("Player");
        cranHand = transform.Find("Cran_Hand").gameObject;
        destinationPoint_01 = new Vector3(-3.502358f, -2.8f, 0);
        destinationPoint_02 = new Vector3(-3.502358f, 1.68f, 0);
        destinationPoint_03 = new Vector3(-3.502358f, -2.8f, -2);
        destinationPoint_04 = new Vector3(-3.502358f, 1.68f, -2);
        worckOnNeedItems = 2;
        worckOnNeedItemsIndex_01 = 4;
        worckOnNeedItemsIndex_02 = 5;
        needItem = true;
        IndexItemImage = 5;
    }

    private void Update()
    {
        UMGOnOff();

        if (worckOn == true && WorckOnHalf == false && worckInProgres == true)
        {
            if (worckOnHalfPlayerReady == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_01, 2 * Time.deltaTime);
            }
            else if (worckOnHalfPlayerReady == true)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_03, 2 * Time.deltaTime);
            }
        }
        else if(worckOn == true && WorckOnHalf == false && worckInProgres == false)
        {
            if (worckOnHalfPlayerReady == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_02, 2 * Time.deltaTime);
            }
            else if (worckOnHalfPlayerReady == true)
            {
               cranHand.transform.localPosition =
               Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_04, 2 * Time.deltaTime);
            }
        }
        else if(worckOn == false && WorckOnHalf == true && worckInProgres == true)
        {
            if(worckOnHalfPlayerReady == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_01, 2 * Time.deltaTime);
            }
            else if (worckOnHalfPlayerReady == true)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_03, 2 * Time.deltaTime);
            }
        }
        else if (worckOn == false && WorckOnHalf == true && worckInProgres == false)
        {
            if (worckOnHalfPlayerReady == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_02, 2 * Time.deltaTime);
            }
            else if (worckOnHalfPlayerReady == true)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_04, 2 * Time.deltaTime);
            }
        }
    }

    public override void EnvirWorckHalfReady()
    {
        if(cranWorck == false)
        {
            cranWorck = true;
            girlAnimator.SetInteger("RwchagState", 4);
            cranHand.GetComponent<InterEnvir_02Cran>().StartCoroutineHalfWorck();
            base.EnvirWorckHalfReady();
        }
    }

    public override void EnvirWorckHalf()
    {
        if (worckOnNeedItemsCurrentIndex == worckOnNeedItemsIndex_02 && worckOnPart_01 == true && worckOnHalfJobDone == true)
        {

        }
        //Опускается
        else if (worckInProgres == false && WorckOnHalfPlayerReady == false && cranWorck == false)
        {
            cranWorck = true;

            if (rwchagState == 0)
            {
                girlAnimator.SetInteger("RwchagState", 1);
                Invoke("ResetWorckOn", 0.7f);
            }
            else if(rwchagState == 2)
            {
                girlAnimator.SetInteger("RwchagState", 3);
                Invoke("RwchagUp", 0.6f);
                Invoke("ResetWorckOn", 1.3f);
            }
        }
        //Поднимается
        else if (worckInProgres == true && WorckOnHalfPlayerReady == false && cranWorck == false)
        {
            cranWorck = true;

            if (rwchagState == 1)
            {
                girlAnimator.SetInteger("RwchagState", 2);
                Invoke("RwchagDown", 0.6f);
                Invoke("ResetWorckOff", 1.3f);
            }
        }

        else if (worckInProgres == false && WorckOnHalfPlayerReady == true && cranWorck == false)
        {
                      
        }

        else if (worckInProgres == true && WorckOnHalfPlayerReady == true && cranWorck == false)
        {
            Invoke("RwchagDown_02", 0.6f);
            Invoke("ResetcranWorck", 3);
        }
        base.EnvirWorckHalf();
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
        if (worckInProgres == false && cranWorck == false)
        {
            cranWorck = true;

            if (rwchagState == 0)
            {
                girlAnimator.SetInteger("RwchagState", 1);
                Invoke("ResetWorckOn", 0.7f);
            }
            else if (rwchagState == 2)
            {
                girlAnimator.SetInteger("RwchagState", 3);
                Invoke("RwchagUp", 0.6f);
                Invoke("ResetWorckOn", 1.3f);
            }
        }
        else if(worckInProgres == true && cranWorck == false)
        {
            cranWorck = true;

            if (WorckOnHalfPlayerReady == true)
            {
                cranHand.GetComponent<InterEnvir_02Cran>().StartCoroutineWorck();
            }
            if (rwchagState == 1)
            {
                girlAnimator.SetInteger("RwchagState", 2);
                Invoke("RwchagDown", 0.6f);
                Invoke("ResetWorckOff", 1.3f);
            }
        }
        base.EnvirWorck();
    }



    private void ResetWorckOn()
    {
        worckInProgres = true;
        if(rwchagState == 0)
        {
            animator.SetInteger("AnimState", 1);
            rwchagState = 1;
        }
        else if(rwchagState == 2)
        {
            rwchagState = 1;
        }
        Invoke("ResetcranWorck", 2);
    }

    private void ResetWorckOff()
    {
        worckInProgres = false;
        if(rwchagState == 1)
        {
            rwchagState = 2;
        }
        Invoke("ResetcranWorck", 2);
    }

    private void ResetcranWorck()
    {
        cranWorck = false;
    }

    private void UMGOnOff()
    {
        if (girlUmg == true && girlRef.GetComponent<GirlMovement>().ChangeActivePerson == 0)
        {
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
        }
        else if (girlUmg == true && girlRef.GetComponent<GirlMovement>().ChangeActivePerson == 1)
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
