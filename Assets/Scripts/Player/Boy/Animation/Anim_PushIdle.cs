using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_PushIdle : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = true;
    }
}
