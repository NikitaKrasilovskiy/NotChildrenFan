using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemetsZastava_01 : MonoBehaviour
{
    private Animator animatorAI;
    public GameObject trigger_03;


    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInChildren<Animator>();
        //trigger_03 = transform.Find("Trigger_03").gameObject;
    }

    public void DelateObj()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InterEnviroument")
        {
            trigger_03.GetComponent<AI_NemZast_01Trigger03>().GirlEvent03End();
            animatorAI.SetBool("isDie", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            //animatorAI.SetInteger("SeeBoyState", 0);
        }
    }
}
