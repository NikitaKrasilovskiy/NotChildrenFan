using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private Animator animator;
    private CharactersMovement characterMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponentInParent<CharactersMovement>();
    }

    //Завершает анимацию поднятия предмета
    public void PickUpAnimationFinish()
    {
        animator.SetInteger("PickUpState", 0);
        Invoke("WalkOn", 0.25f);
    }

    public void PrepareTrowItemAnim()
    {
        animator.SetInteger("ThrowState", 1);
    }

    public void TrowStartItemAnim()
    {
        animator.SetInteger("ThrowState", 2);
    }

    public void StopThrow()
    {
        animator.SetInteger("ThrowState", 0);
        WalkOn();
    }

    //Снимает блокировку с движения персонажа
    private void WalkOn()
    {
        characterMovement.CantWalk = false;
    }
}
