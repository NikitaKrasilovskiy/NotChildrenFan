using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyBoxCheck : MonoBehaviour
{
    public GameObject boxRef;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Залезть на ящик
        if (other.tag == "ClimbBox" || other.tag == "ClimbPushBox")
        {
            boxRef.GetComponent<BoyMovement>().CanBoxClimbOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Отойти от ящика
        if (other.tag == "ClimbBox" || other.tag == "ClimbPushBox")
        {
            boxRef.GetComponent<BoyMovement>().CanBoxClimbOn = false;
        }
    }
}
