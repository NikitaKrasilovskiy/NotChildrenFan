using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_MatMach_02 : PickUpUseble_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 2;
        ItemName = "Мать и Мачеха";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
