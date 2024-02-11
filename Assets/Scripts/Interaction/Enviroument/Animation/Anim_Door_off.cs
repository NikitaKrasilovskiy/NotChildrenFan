using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Door_off : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetInteger("doorAnimState", 0);
        animator.gameObject.GetComponentInParent<GarageDoor>().DoorNotOpen = false;
    }
}
