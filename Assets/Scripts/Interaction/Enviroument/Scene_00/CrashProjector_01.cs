using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashProjector_01 : Enviroument_Interaction_Ammo_Class
{
    public override void InteractionAmmo()
    {
        base.InteractionAmmo();
        spawnPosition = new Vector3(-265.018f, 3.04f, 1f);
        spawnRotation = new Quaternion(0, 0, 0, 0);
        Instantiate(spawnGameObj, spawnPosition, spawnRotation);
        Destroy(gameObject);
    }
}
