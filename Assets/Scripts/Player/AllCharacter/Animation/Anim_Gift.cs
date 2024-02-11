using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Gift : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //Стопорит передвижение персонажа
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetBool("isGift", false);
        animator.SetBool("isJumpTo", false);
        animator.SetBool("isClimb", false);
        animator.SetBool("isOpenCar", false);
        //Стопорит передвижение персонажа
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = false;
    }
}
