using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAnim_RwchagOff : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        //Вызывает функцию уничтожение поднимаемого предмета
        animator.SetInteger("AnimState", 0);
    }
}
