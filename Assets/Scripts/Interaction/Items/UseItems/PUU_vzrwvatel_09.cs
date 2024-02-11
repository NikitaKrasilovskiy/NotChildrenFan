﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUU_vzrwvatel_09 : ItemsPickUp_Class
{
    public GameObject scaneData;

    public virtual void Start()
    {
        CurrentitemType = itemsType.item;
        ItemIndex = 9;
    }

    public override void DestroyItem()
    {
        scaneData.GetComponent<Scane_04_Data>().PickUpItems[2] = true;
        scaneData.GetComponent<Scane_04_Data>().LoadNextLvL();
        base.DestroyItem();
    }
}