using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThrow : ThrowItem_Class
{
    public override void Start()
    {
        base.Start();
        spawnorNot = true;
        spawnInPlase = true;
        spawnTransform = new Vector3(-297.016f, -2.109f, 0);
    }

    public override void SpawhTrowItem()
    {
        base.SpawhTrowItem();
    }
}
