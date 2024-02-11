using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Ammo_01 : PickUp_Ammo_Class
{
    public GameObject spawnAmmo;

    public override void Start()
    {
        base.Start();
        ItemIndex = 1;
        ItemName = "Камни";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }

    public override void DestroyItem()
    {
        Instantiate(spawnAmmo, this.transform.position, this.transform.rotation);
        base.DestroyItem();
    }
}
