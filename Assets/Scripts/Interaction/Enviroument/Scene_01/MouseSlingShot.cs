using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSlingShot : Enviroument_Interaction_Ammo_Class
{
    public GameObject parentGO;

    public override void InteractionAmmo()
    {
        base.InteractionAmmo();

        parentGO.GetComponent<InterEnvir_03Mouse>().BoyGirlEndEvent();
        spawnPosition = new Vector3(-284.427f, -2.079f, 0f);
        spawnRotation = new Quaternion(0, 0, 0, 0);
        Instantiate(spawnGameObj, spawnPosition, spawnRotation);
        Destroy(parentGO);
    }
}
