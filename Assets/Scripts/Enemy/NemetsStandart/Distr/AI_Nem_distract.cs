using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Nem_distract : AI_NemStDistr_AllTrigger
{
    public override void DistrItem()
    {
        base.DistrItem();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ThrowItem")
        {
            DistrItem();
        }
    }   
}
