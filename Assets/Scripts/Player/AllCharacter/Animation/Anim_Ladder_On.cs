using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Ladder_On : StateMachineBehaviour
{
    //public GameObject boyRef;
    //public GameObject girlRef;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //girlRef = GameObject.FindGameObjectWithTag("Player");
        //boyRef = GameObject.FindGameObjectWithTag("PlayerBoy");
        CharactersMovement characterMovement = animator.gameObject.GetComponentInParent<CharactersMovement>();

        base.OnStateEnter(animator, stateInfo, layerIndex);
        //Стопорит передвижение персонажа
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = true;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = true;
        //boyRef.GetComponent<BoyMovement>().CantChange = true;
        //girlRef.GetComponent<GirlMovement>().CantChange = true;
    }
}
