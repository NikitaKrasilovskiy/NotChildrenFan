using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemZast_01Trigger03 : MonoBehaviour
{
    private Animator animatorAI;
    private GirlMovement girlMovement;
    private GirlEvents girlEvents;
    private GameObject trigger_01;
    private GameObject trigger_02;
    public GameObject trigger_03;
    public GameObject ammoRef;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInParent<Animator>();
        trigger_01 = transform.Find("Trigger_01").gameObject;
        trigger_02 = transform.Find("Trigger_02").gameObject;
        //trigger_03 = transform.Find("Trigger_03").gameObject;
    }
  
    //Если девочка плачет отключает тригеры обнаружения
    private void isGirlCry()
    {
        if (girlMovement != null && girlMovement.IsCry == true)
        {
            animatorAI.SetInteger("GirlCry", 1);
            trigger_01.SetActive(false);
            trigger_02.SetActive(false);
            trigger_03.SetActive(false);
            ammoRef.SetActive(true);

            if (girlEvents != null)
            {
                girlEvents.Event_03();
            }
        }
    }

    public void GirlEvent03End()
    {
        if (girlEvents != null)
        {
            girlEvents.Event_03End();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            girlMovement = other.GetComponent<GirlMovement>();
            girlEvents = other.GetComponent<GirlEvents>();
            Invoke("isGirlCry", 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animatorAI.SetInteger("GirlCry", 0);
            trigger_01.SetActive(true);
            trigger_02.SetActive(true);
            trigger_03.SetActive(true);
        }
    }
}
