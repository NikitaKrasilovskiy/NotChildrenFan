using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Die_Spawn : StateMachineBehaviour
{
    public GameObject spawnDie;
    private Vector3 spawnPosition = new Vector3(-264.97f, -2.015f, 0);
    private Quaternion spawnRotation = new Quaternion(0, 180, 0, 0);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        AI_NemetsZastava_01 aI_NemetsZastava_01 = animator.gameObject.GetComponentInParent<AI_NemetsZastava_01>();
        Instantiate(spawnDie, spawnPosition, spawnRotation);
        aI_NemetsZastava_01.DelateObj();
    }
}
