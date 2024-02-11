using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemZast_01Trigger04 : MonoBehaviour
{
    private Animator animatorAI;
    private BoyThrow boyThrow;
    private BoyEvents boyEvents;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInParent<Animator>();
    }

    private void TEESSRR()
    {
        if (boyEvents != null)
        {          
            if (boyEvents.EventAdd[1] == true)
            {
                if(boyEvents.BoyDead == false)
                {
                    boyEvents.BoyDead = true;
                    boyEvents.BoyDieEvent();
                    Invoke("AfterBoyDeadCryGirlAnim", 2);
                }
            }
        }
        animatorAI.SetInteger("SeeBoyState", 3);
    }


    private void AfterBoyDeadCryGirlAnim()
    {
        animatorAI.SetInteger("SeeBoyState", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            boyEvents = other.gameObject.GetComponent<BoyEvents>();
            Invoke("TEESSRR", 0.3f);
        }
    }
}
