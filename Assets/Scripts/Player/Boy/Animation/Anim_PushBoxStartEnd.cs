using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_PushBoxStartEnd : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("isPush", true);
        animator.gameObject.GetComponentInParent<CharactersMovement>().SwichBoolAnimationState = false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetBool("isPush", false);
    }
}
