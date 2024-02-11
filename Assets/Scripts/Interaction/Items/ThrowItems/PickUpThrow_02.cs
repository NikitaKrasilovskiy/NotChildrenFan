using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThrow_02 : PickUpThrow_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 2;
        ItemName = "Кирпич";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
