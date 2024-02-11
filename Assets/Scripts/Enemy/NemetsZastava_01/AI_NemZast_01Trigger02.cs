using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemZast_01Trigger02 : MonoBehaviour
{
    private Animator animatorAI;
    public BoyMovement boyMovement;
    public BoyThrow boyThrow;
    public BoyEvents boyEvents;
    public GameObject boy;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInParent<Animator>();
        //boy = GameObject.FindGameObjectWithTag("PlayerBoy");
        //boyMovement = boy.gameObject.GetComponent<BoyMovement>();
        //boyThrow = boy.gameObject.GetComponent<BoyThrow>();
        //boyEvents = boy.gameObject.GetComponent<BoyEvents>();
    }
    private void Update()
    {
        //Physics2D.IgnoreLayerCollision(12, 13);
    }
    private void TEESSRR()
    {
        if(boyEvents != null)
        {
            if(boyEvents.EventAdd[1] == false)
            {
                if (boyMovement != null && boyThrow != null)
                {
                    boyMovement.GetComponent<BoyMovement>().CantWalkRight = true;
                    boyThrow.GetComponent<BoyThrow>().IsCanShot = true;
                }
            }
            else if(boyEvents.EventAdd[1] == true)
            {
                boyEvents.GetComponent<BoyEvents>().BoyDieEvent();
            }
        }
        animatorAI.SetInteger("SeeBoyState", 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            Invoke("TEESSRR", 0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            boyMovement.GetComponent<BoyMovement>().CantWalkRight = false;
            boyThrow.GetComponent<BoyThrow>().IsCanShot = false;
        }
    }
}
