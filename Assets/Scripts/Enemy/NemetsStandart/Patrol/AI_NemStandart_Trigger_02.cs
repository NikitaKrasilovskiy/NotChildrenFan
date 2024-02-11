using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStandart_Trigger_02 : AI_NemStandart_All_Triggers
{
    public override void BoyTrigger_02On()
    {
        base.BoyTrigger_02On();
    }

    public override void GirlTrigger_02On()
    {
        base.GirlTrigger_02On();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            BoyTrigger_02On();
        }
        if (other.tag == "Player")
        {
            GirlTrigger_02On();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
       
    }
}
