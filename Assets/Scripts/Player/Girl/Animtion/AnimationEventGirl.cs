using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventGirl : MonoBehaviour
{
    //public GameObject girlRef;
    [SerializeField] private GirlUsebleItems girlUsebleItems;
    [SerializeField] private GirlEvents girlEvents;

    private void Start()
    {
        girlUsebleItems = girlUsebleItems.GetComponent<GirlUsebleItems>();
        girlEvents = girlEvents.GetComponent<GirlEvents>();
    }

    public void UseEnvirItem()
    {
        girlUsebleItems.EnviroumentInteractionObj.EnvirInteraction();
    }

    public void GirlPadaet()
    {
        girlEvents.PodorognikImage();
    }
}
