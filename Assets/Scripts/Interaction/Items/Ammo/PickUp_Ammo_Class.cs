using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Ammo_Class : ItemsPickUp_Class
{
    public virtual void Start()
    {
        CurrentitemType = itemsType.ammoItem;
    }
}
