using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_02_StartCall : MonoBehaviour
{
    public GameObject boyRef;
    public GameObject girlRef;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            boyRef.GetComponent<BoyMovement>().IsCanGirlCall = true;
            girlRef.GetComponent<GirlMovement>().IsCanBoyCall = true;
        }
    }
}
