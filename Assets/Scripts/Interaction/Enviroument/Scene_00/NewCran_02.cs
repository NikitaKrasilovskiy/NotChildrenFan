using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCran_02 : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_02_Data scaneData;
    [SerializeField]private GameObject cranHand;
    private InterCran_02Cran _cranHand;

    public GameObject infoButRef;

    private Vector3 destinationPoint_01;
    private Vector3 destinationPoint_02;
    private Vector3 destinationPoint_03;
    private Vector3 destinationPoint_04;

    private bool cranDown;
    private bool cranUp;
    private bool boyDown;
    private bool girlUmg;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_02_Data>();
        _cranHand = cranHand.GetComponent<InterCran_02Cran>();
    }

    // Start is called before the first frame update
    void Start()
    {
        worckOnNeedItems = 2;
        destinationPoint_01 = new Vector3(-3.502358f, -2.8f, 0);
        destinationPoint_02 = new Vector3(-3.502358f, 1.46f, 0);
        destinationPoint_03 = new Vector3(-3.502358f, 0.6f, 0);
        destinationPoint_04 = new Vector3(-3.502358f, 1.46f, 0);
        worckOnNeedItems = 2;
        worckOnNeedItemsIndex_01 = 4;
        worckOnNeedItemsIndex_02 = 5;
        needItem = true;
        IndexItemImage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        UMGOnOff();

        if(cranDown == true && cranUp == false && cranHand.transform.localPosition != destinationPoint_01)
        {
            if(WorckOnPart_01 == true && WorckOnPart_02 == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_01, 2 * Time.deltaTime);                   
            }

            else if (WorckOnPart_01 == true && WorckOnPart_02 == true)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_01, 2 * Time.deltaTime);
            }
        }
        else if (cranDown == true && cranUp == false && cranHand.transform.localPosition == destinationPoint_01)
        {
            ResetCranDown();
        }
        


        else if (cranDown == false && cranUp == true && cranHand.transform.localPosition != destinationPoint_02 && WorckOnHalfPlayerReady == false)
        {
            if(WorckOnPart_01 == true && WorckOnPart_02 == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_02, 2 * Time.deltaTime);
            }
            else if (WorckOnPart_01 == true && WorckOnPart_02 == true)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_02, 2 * Time.deltaTime);
            }
        }

        else if (cranDown == false && cranUp == true && cranHand.transform.localPosition == destinationPoint_02 && WorckOnHalfPlayerReady == false)
        {
            ResetCranUp();
        }

        else if (cranDown == false && cranUp == true && cranHand.transform.localPosition != destinationPoint_03 && WorckOnHalfPlayerReady == true)
        {
            if (WorckOnPart_01 == true && WorckOnPart_02 == false)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_03, 2 * Time.deltaTime);
                _cranHand.StartCoroutineHalfWorck();
            }
            else if (WorckOnPart_01 == true && WorckOnPart_02 == true)
            {
                cranHand.transform.localPosition =
                Vector3.MoveTowards(cranHand.transform.localPosition, destinationPoint_02, 2 * Time.deltaTime);
                _cranHand.StartCoroutineWorck();
            }
        }

        else if (cranDown == false && cranUp == true && cranHand.transform.localPosition == destinationPoint_03 && WorckOnHalfPlayerReady == true)
        {
            cranDown = true;
            cranUp = false;
        }
    }

    public override void EnvirNotWorck()
    {
        scaneData._GirlAnimator.SetBool("isGift", true);
        base.EnvirNotWorck();
    }

    public override void EnvirWorckHalf()
    {
        scaneData._GirlAnimator.SetBool("isGift", true);
        base.EnvirWorckHalf();
        WorckOnHalfJobDone = true;
    }

    public override void EnvirWorck()
    {
        scaneData._GirlAnimator.SetBool("isGift", true);
        base.EnvirWorck();
    }

    public void CranHalf()
    {

    }

    public void CranDown()
    {
        cranDown = true;
        if (WorckOnPart_01 == false)
        {
            Invoke("ResetCranDown", 3);
        }
    }

    public void CranUp()
    {
        cranUp = true;
        if (WorckOnPart_01 == false)
        {
            Invoke("ResetCranUp", 3);
        }
    }

    public void ResetCranDown()
    {
        cranDown = false;
    }
    public void ResetCranUp()
    {
        cranUp = false;
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
