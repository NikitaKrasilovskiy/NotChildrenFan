﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Die : StateMachineBehaviour
{  
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetBool("isDie", false);
    }
}
