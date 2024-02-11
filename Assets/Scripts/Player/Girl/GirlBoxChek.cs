using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlBoxChek : MonoBehaviour
{
    public GameObject girlRef;

    private void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Залезть на ящик
        if (other.tag == "ClimbBox" || other.tag == "ClimbPushBox")
        {
            girlRef.GetComponent<GirlMovement>().CanBoxClimbOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Отойти от ящика
        if (other.tag == "ClimbBox" || other.tag == "ClimbPushBox")
        {
            girlRef.GetComponent<GirlMovement>().CanBoxClimbOn = false;
        }
    }
}
