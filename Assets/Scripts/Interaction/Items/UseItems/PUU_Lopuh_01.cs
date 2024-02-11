using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_Lopuh_01 : PickUpUseble_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 1;
        ItemName = "Лопух";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
