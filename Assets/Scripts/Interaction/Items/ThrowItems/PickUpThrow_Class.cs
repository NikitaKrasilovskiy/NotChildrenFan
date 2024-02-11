using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThrow_Class : ItemsPickUp_Class
{
    public virtual void Start()
    {
        CurrentitemType = itemsType.throwItem;
    }
}
