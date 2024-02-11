using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_02_Event_02 : MonoBehaviour
{
    [SerializeField] private Scane_02_Data scaneData;
    private bool onOff;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" && onOff == false)
        {
            scaneData._GirlEvents.Event_02();
            onOff = true;
        }
    }  
}
