using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersZone15 : MonoBehaviour
{
    public int zoneIndex;
    private Box15 boxRef;
    private PlayerCont15 playerLight;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            boxRef = other.GetComponent<Box15>();
            boxRef.BoxTriggerPosition = zoneIndex;
        }

        if (other.tag == "Respawn")
        {
            playerLight = other.GetComponent<PlayerCont15>();
            playerLight.zoneIndex = zoneIndex;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            //boxRef.MoveBoxOn2 = false;
        }
    }
}
