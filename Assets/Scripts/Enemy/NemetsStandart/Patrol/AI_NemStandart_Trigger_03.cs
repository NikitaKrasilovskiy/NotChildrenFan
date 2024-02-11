using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStandart_Trigger_03 : AI_NemStandart_All_Triggers
{
    public override void BoyTrigger_02On()
    {
        base.BoyTrigger_03On();
    }

    public override void GirlTrigger_02On()
    {
        base.GirlTrigger_03On();
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
}
