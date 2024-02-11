using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_isFallFalse : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetInteger("isFall", 0);
    }
}
