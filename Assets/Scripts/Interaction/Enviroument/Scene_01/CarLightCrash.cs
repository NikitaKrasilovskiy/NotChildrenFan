using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLightCrash : Enviroument_Interaction_Ammo_Class
{
    [SerializeField] private GameObject nemetsDistr;
    [SerializeField] private GameObject nemetsPatrol_02;
    [SerializeField] private GameObject nemetsPatrol_03;
    [SerializeField] private GameObject nemetsPatrol;
    [SerializeField] private int carlightState;

    public override void InteractionAmmo()
    {
        base.InteractionAmmo();
        nemetsDistr.GetComponent<AI_Nemets_Distr>().DistrFara();
        
        if(carlightState == 0)
        {
            nemetsPatrol_02.GetComponent<AI_NemStandart_All_Triggers>().LeftLight = true;
            nemetsPatrol_03.GetComponent<AI_NemStandart_All_Triggers>().LeftLight = true;
            nemetsPatrol.GetComponent<AI_NemStandart_All_Triggers>().LeftLight = true;
        }
        if (carlightState == 1)
        {
            Debug.Log("33333");
            nemetsPatrol_02.GetComponent<AI_NemStandart_All_Triggers>().RightLight = true;
            nemetsPatrol_03.GetComponent<AI_NemStandart_All_Triggers>().RightLight = true;
            nemetsPatrol.GetComponent<AI_NemStandart_All_Triggers>().RightLight = true;
        }

        Destroy(gameObject);
    }
}
