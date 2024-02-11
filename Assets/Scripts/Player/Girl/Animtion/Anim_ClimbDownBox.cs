using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_ClimbDownBox : StateMachineBehaviour
{
    private Vector3 tr03;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        CharactersMovement characterMovement = animator.gameObject.GetComponentInParent<CharactersMovement>();
        GirlMovement girlMovement = animator.gameObject.GetComponentInParent<GirlMovement>();

        if (characterMovement.HorizontalOrientation == 1)
        {
            Transform girl = animator.gameObject.transform.parent;
            var tr01 = girl.position.x - +0.6f;
            var tr02 = girl.position.y - +1f;
            tr03 = new Vector3(tr01, tr02, 0);
            //Телепортирует с ящика
            girl.transform.position = tr03;
            characterMovement.IsOnBox = false;
        }
        else if (characterMovement.HorizontalOrientation == 0)
        {
            Transform girl = animator.gameObject.transform.parent;
            var tr01 = girl.position.x + +0.6f;
            var tr02 = girl.position.y - +1f;
            tr03 = new Vector3(tr01, tr02, 0);
            //Телепортирует с ящика
            girl.transform.position = tr03;
            characterMovement.IsOnBox = false;
        }

    }


}
