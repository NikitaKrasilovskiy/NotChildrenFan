using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_Gear_04 : PickUpUseble_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 4;
        ItemName = "Шестеренка";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
