using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStDistr_Trigger_01 : AI_NemStDistr_AllTrigger
{
    public override void FirstSeeBoyGirl()
    {
        base.FirstSeeBoyGirl();
    }

    public override void BoyGirlExit()
    {
        base.BoyGirlExit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBoy")
        {
            FirstSeeBoyGirl();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBoy")
        {
            BoyGirlExit();
        }
    }
}
