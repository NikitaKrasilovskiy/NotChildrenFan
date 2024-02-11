using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterEnvir_02Cran1 : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_04_Data scaneData;

    [SerializeField] public Animator animator;   
    private GameObject cranHand;
    [SerializeField] private GameObject crashCran;
    private bool cranOn;
    public GameObject infoButRef;
    private bool girlUmg;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_04_Data>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cranHand = transform.Find("Cran_Hand").gameObject;
        worckOnNeedItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UMGOnOff();
    }

    public override void EnvirWorck()
    {
        if(cranOn == false)
        {
            cranOn = true;
            Invoke("RwchagDown", 0.6f);
            animator.SetInteger("AnimState", 1);
        }
    }

    private void UMGOnOff()
    {       
        if(cranOn == false)
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
        else
        {
            infoButRef.SetActive(false);
        }
    }

    private void RwchagDown()
    {
        cranHand.SetActive(false);
        crashCran.SetActive(true);
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
