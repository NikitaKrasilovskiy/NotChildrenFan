using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_03_01 : MonoBehaviour
{
    public GameObject nemetsPatrol;
    public bool startPatrol;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && startPatrol == false)
        {
            nemetsPatrol.GetComponent<AIC_NemetsPatroll>().Patroll_01Start();
            startPatrol = true;
        }
    }
}
