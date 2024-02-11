using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStandart_Trigger_01 : AI_NemStandart_All_Triggers
{
    private void Update()
    {

    }

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
