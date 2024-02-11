using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Ladder_Teleport : StateMachineBehaviour
{
    private Vector3 tr03;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {      
        base.OnStateEnter(animator, stateInfo, layerIndex);

        CharactersMovement characterMovement = animator.gameObject.GetComponentInParent<CharactersMovement>();

        animator.gameObject.GetComponentInParent<BoyMovement>().LadderCameraUp = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        CharactersMovement characterMovement = animator.gameObject.GetComponentInParent<CharactersMovement>();

        Transform player = animator.gameObject.transform.parent;
        var tr01 = player.position.x - +0.8f;
        var tr02 = player.position.y + +2.655f;
        tr03 = new Vector3(tr01, tr02, 0);
        animator.SetInteger("LadderState", 0);
        player.transform.position = tr03;

        animator.gameObject.GetComponentInParent<BoyMovement>().LadderCameraUp = false;
        animator.gameObject.GetComponentInParent<BoyMovement>().CameraStandart();
    }
}
