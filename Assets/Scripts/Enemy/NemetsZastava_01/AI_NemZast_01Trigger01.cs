using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemZast_01Trigger01 : MonoBehaviour
{
    private Animator animatorAI;
    private bool boyOnTrigger;
    public BoyThrow boyThrow;
    public GameObject boy;
    public GameObject girl;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInParent<Animator>();
        //boy = GameObject.FindGameObjectWithTag("PlayerBoy");
        //girl = GameObject.FindGameObjectWithTag("Player");
        //boyThrow = boy.gameObject.GetComponent<BoyThrow>();
    }

    private void TEESSRR()
    {
        if(boyThrow != null)
        {
            boyThrow.GetComponent<BoyThrow>().IsCanShot = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            animatorAI.SetInteger("SeeBoyState", 1);
            boyOnTrigger = true;
            Invoke("TEESSRR", 0.3f);
        }
        else if(other.tag == "Player")
        {
            if(boyOnTrigger == false)
            {
                animatorAI.SetInteger("SeeBoyState", 1);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            animatorAI.SetInteger("SeeBoyState", 0);
            boyThrow.GetComponent<BoyThrow>().IsCanShot = false;
            boyOnTrigger = false;
        }
        else if(other.tag == "Player")
        {
            if (boyOnTrigger == false)
            {
                animatorAI.SetInteger("SeeBoyState", 0);
            }
        }
    }

}
