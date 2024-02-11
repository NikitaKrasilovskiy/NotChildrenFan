using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_02_event_01 : MonoBehaviour
{
    [SerializeField] private Scane_02_Data scaneData;
    private bool onOff;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "PlayerBoy" && onOff == false)
        {
            onOff = true;
            scaneData._BoyEvents.Event_01();
        }
    }
}
