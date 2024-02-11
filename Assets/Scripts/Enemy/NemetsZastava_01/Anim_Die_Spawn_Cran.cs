using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Die_Spawn_Cran : StateMachineBehaviour
{
    public GameObject spawnDie;
    private Vector3 spawnPosition = new Vector3(-227.59f, -2.011439f, 0);
    private Quaternion spawnRotation = new Quaternion(0, 180, 0, 0);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        AI_NemetsCran ai_nemets_cran = animator.gameObject.GetComponentInParent<AI_NemetsCran>();
        Instantiate(spawnDie, spawnPosition, spawnRotation);
        ai_nemets_cran.DelateObj();
    }
}
