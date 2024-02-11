using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBoyGirl : MonoBehaviour
{
    [SerializeField] private Scane_03_Data scaneData;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_03_Data>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            scaneData.GirlDoorOn = true;
        }
        if (other.tag == "PlayerBoy")
        {
            scaneData.BoyDoorOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            scaneData.GirlDoorOn = false;
        }
        if (other.tag == "PlayerBoy")
        {
            scaneData.BoyDoorOn = false;
        }
    }
}
