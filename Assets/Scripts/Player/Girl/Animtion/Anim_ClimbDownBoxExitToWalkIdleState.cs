using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_ClimbDownBoxExitToWalkIdleState : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        CharactersMovement characterMovement = animator.gameObject.GetComponentInParent<CharactersMovement>();

        animator.SetInteger("ClimbState", 0);
        characterMovement.CantWalk = false;      
    }
}
