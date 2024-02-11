using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThrow_01 : PickUpThrow_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 1;
        ItemName = "Сумка";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
