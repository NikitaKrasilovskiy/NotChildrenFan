using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_Podorognik_03 : PickUpUseble_Class
{
    public override void Start()
    {
        base.Start();
        ItemIndex = 3;
        ItemName = "Подорожник";
        SpriteItem = GetComponent<SpriteRenderer>().sprite;
    }
}
