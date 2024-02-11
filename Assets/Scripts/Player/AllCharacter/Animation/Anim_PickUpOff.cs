using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_PickUpOff : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        //Стопорит передвижение персонажа
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalk = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkLeft = false;
        animator.gameObject.GetComponentInParent<CharactersMovement>().CantWalkRight = false;
        //Вызывает функцию уничтожение поднимаемого предмета
        animator.SetBool("isPickUp", false);
    }
}
