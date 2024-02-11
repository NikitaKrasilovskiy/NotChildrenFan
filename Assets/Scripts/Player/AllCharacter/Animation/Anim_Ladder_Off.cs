using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Ladder_Off : StateMachineBehaviour
{
    //public GameObject boyRef;
    //public GameObject girlRef;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        //girlRef = GameObject.FindGameObjectWithTag("Player");
        //boyRef = GameObject.FindGameObjectWithTag("PlayerBoy");
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().IsLadder = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().IsLadderUp = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().LaddersOff();
        //boyRef.GetComponent<BoyMovement>().CantChange = false;
        //girlRef.GetComponent<GirlMovement>().CantChange = false;
    }
}
