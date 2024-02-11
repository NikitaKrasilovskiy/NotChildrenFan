using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroTriggerZone : MonoBehaviour
{
    public int zoneIndex;
    private ElectroPlayer playerLight;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {

        }

        if (other.tag == "Respawn")
        {
            playerLight = other.GetComponent<ElectroPlayer>();
            playerLight.zoneIndex = zoneIndex;
        }
    }
}
