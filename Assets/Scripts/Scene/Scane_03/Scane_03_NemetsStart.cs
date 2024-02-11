using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_03_NemetsStart : MonoBehaviour
{
    public GameObject nemetsStart;
    private bool startOrNot;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           if(startOrNot == false)
           {
                nemetsStart.GetComponent<AI_NemStandart_All>().Patroll_01Start();
                startOrNot = true;
           }
        }       
    }
}
