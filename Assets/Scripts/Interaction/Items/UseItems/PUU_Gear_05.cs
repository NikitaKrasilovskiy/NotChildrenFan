using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_Gear_05 : PickUpUseble_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 5;
        ItemName = "Шестеренка";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
