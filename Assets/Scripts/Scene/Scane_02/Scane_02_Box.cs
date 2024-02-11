using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_02_Box : MonoBehaviour
{
    public GameObject generalCar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            generalCar.GetComponent<Scane_02_General>().SeeBoy = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            generalCar.GetComponent<Scane_02_General>().SeeBoy = false;
        }
    }
}
