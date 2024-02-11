using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimWalkOff : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //Стопорит передвижение персонажа
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = true;
    }
}
