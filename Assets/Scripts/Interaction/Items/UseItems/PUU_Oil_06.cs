using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_Oil_06 : PickUpUseble_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 6;
        ItemName = "Масленка";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
