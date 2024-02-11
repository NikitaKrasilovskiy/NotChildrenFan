using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_moon : StateMachineBehaviour
{  
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = false;
        animator.gameObject.GetComponentInParent<BoyEvents>().BoyDance = false;
        animator.SetBool("isMoon", false);
    }
}
