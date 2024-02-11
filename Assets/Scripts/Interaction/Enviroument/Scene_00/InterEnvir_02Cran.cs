using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterEnvir_02Cran : EnvirInterBoyGirl_Class
{


    public GameObject boyRef;
    public GameObject girlRef;
    private GameObject blackScreen;
    public InterEnvir_01Cran cran_01;
    private bool boyOn;
    private bool boyOnHalf;
    private bool exitOn;
    private bool exitOnHalf;
    private Vector3 destinationPoint;
    public GameObject infoButRef;
    private bool boyUmg;

    // Start is called before the first frame update
    void Start()
    {
        worckOnNeedItems = 0;
        destinationPoint = new Vector3(-3.502358f, 1.68f, 0);
    }

    private void Update()
    {
        if(exitOn == true)
        {
            boyRef.transform.position = Vector3.MoveTowards(boyRef.transform.position, new Vector3(boyRef.transform.position.x, 1.4f, 0), 1.5f * Time.deltaTime);
        }
        else if(exitOnHalf == true)
        {
            boyRef.transform.position = Vector3.MoveTowards(boyRef.transform.position, new Vector3(boyRef.transform.position.x, -1.995004f, 0), 1.5f * Time.deltaTime);
        }

        UMGOnOff();
    }

    public override void EnvirWorck()
    {
       if(boyOn == true && cran_01.WorckOnHalfPlayerReady == false)
       {
            cran_01.WorckOnHalfPlayerReady = true;
            boyRef.GetComponent<BoyMovement>().BoyStopMovement();
            boyRef.GetComponentInChildren<Animator>().SetBool("isCran", true);
            //Debug.Log("Висит на кране");
       }
       else if(boyOn == true && cran_01.WorckOnHalfPlayerReady == true)
       {
            cran_01.WorckOnHalfPlayerReady = false;
            boyRef.GetComponent<BoyMovement>().BoyStartMovement();
            boyRef.GetComponentInChildren<Animator>().SetBool("isCran", false);
            //Debug.Log("Не Висит на кране");
        }
    }

    public void StartCoroutineHalfWorck()
    {
        StartCoroutine(HalfWorck());
    }

    public void StartCoroutineWorck()
    {
        StartCoroutine(ExitLvL());
    }

    //Поднимает на половину
    IEnumerator HalfWorck()
    {
        yield return new WaitForSeconds(1f);
        boyRef.GetComponent<BoyMovement>().CantChange = true;
        girlRef.GetComponent<GirlMovement>().CantChange = true;
        boyRef.GetComponent<Rigidbody2D>().simulated = false;
        exitOn = true;
        cran_01.WorckInProgres = false;
        yield return new WaitForSeconds(1.3f);
        cran_01.WorckInProgres = true;
        exitOn = false;
        exitOnHalf = true;
        yield return new WaitForSeconds(1.3f);       
        boyRef.GetComponent<BoyMovement>().CantChange = false;
        girlRef.GetComponent<GirlMovement>().CantChange = false;
        boyRef.GetComponent<Rigidbody2D>().simulated = true;
        cran_01.WorckOnHalfJobDone = true;
    }

    //Переход на следующий уровень
    IEnumerator ExitLvL()
    {
        yield return new WaitForSeconds(1f);
        exitOn = true;
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        boyRef.GetComponent<BoyMovement>().CantChange = true;
        girlRef.GetComponent<GirlMovement>().CantChange = true;
        //boyRef.GetComponent<BoyEvents>().BoyStopMovement();
        boyRef.GetComponent<Rigidbody2D>().simulated = false;
        cran_01.WorckInProgres = false;
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("3_Demo");
    }

    private void UMGOnOff()
    {
        if (cran_01.WorckOnHalfPlayerReady == false)
        {
            if (boyUmg == true && boyRef.GetComponent<BoyMovement>().ChangeActivePerson == 1)
            {
                infoButRef.SetActive(true);
                infoButRef.GetComponent<InfoButtons>().SetPosBoy();
            }
            else if (boyUmg == true && boyRef.GetComponent<BoyMovement>().ChangeActivePerson == 0)
            {
                infoButRef.SetActive(false);
            }
        }
        else if(cran_01.WorckOnHalfPlayerReady == true)
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
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
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
