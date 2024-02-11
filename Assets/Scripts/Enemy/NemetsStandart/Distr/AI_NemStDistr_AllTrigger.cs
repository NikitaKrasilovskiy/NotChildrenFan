using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStDistr_AllTrigger : MonoBehaviour
{
    public GameObject nemetsStandart;
    //Референс на пацана и девочку
    public GameObject boy;
    public GameObject girl;
    //private BoyThrow boyThrow;
    //private GirlThrow girlThrow;
    private BoyEvents boyEvents;
    //private GirlEvents girlEvents;
    //Немец
    private Animator animatorAI;

    public bool isCryorNot;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInParent<Animator>();
        //Находит пацана и девочку
        //boy = GameObject.FindGameObjectWithTag("PlayerBoy");
        //girl = GameObject.FindGameObjectWithTag("Player");
        //референсф на компоненты пацана и девочки
        //boyThrow = boy.GetComponent<BoyThrow>();
        //girlThrow = girl.GetComponent<GirlThrow>();
        //boyEvents = boy.GetComponent<BoyEvents>();
        //girlEvents = girl.GetComponent<GirlEvents>();
        //Тригеры
    }

    //Вход в первый тригер (Присматривается)
    public virtual void FirstSeeBoyGirl()
    {
        animatorAI.SetInteger("SeeBoyState", 1);
        nemetsStandart.GetComponent<AI_Nemets_Distr>().IsSeeBoyGirl = true;
    }
    //Выход из первого триггера
    public virtual void BoyGirlExit()
    {
        animatorAI.SetInteger("SeeBoyState", 0);
        animatorAI.SetBool("isWalk", false);
        nemetsStandart.GetComponent<AI_Nemets_Distr>().IsSeeBoyGirl = false;
    }

    //Вход во второй тригер парень
    public virtual void BoyTrigger_02On()
    {
        if (nemetsStandart.GetComponent<AI_Nemets_Distr>().IsPatroll == true)
        {
            nemetsStandart.GetComponent<AI_Nemets_Distr>().StopPatroll();
        }
        animatorAI.SetInteger("SeeBoyState", 2);
        Invoke("BoyDead", 0.5f);
    }

    //Вход во второй тригер девочка
    public virtual void GirlTrigger_02On()
    {
        //Если нельзя воздействовать плачем
        if (isCryorNot == false)
        {
            if(nemetsStandart.GetComponent<AI_Nemets_Distr>().IsPatroll == true)
            {
                nemetsStandart.GetComponent<AI_Nemets_Distr>().StopPatroll();
            }
            animatorAI.SetInteger("SeeBoyState", 2);
            Invoke("GirlDead", 0.5f);
        }
        //Если можно воздействовать плачем
        else if (isCryorNot == true)
        {

        }
    }
    //Пацан умирает
    private void BoyDead()
    {
        if (boy.GetComponent<BoyEvents>().BoyDead == false)
        {
            boy.GetComponent<BoyEvents>().BoyDead = true;
            boy.GetComponent<BoyEvents>().BoyDieEvent();
            BoyGirlExit();
        }
    }
    //Девочка умирает
    private void GirlDead()
    {
        if (girl.GetComponent<GirlEvents>().GirlDead == false)
        {
            girl.GetComponent<GirlEvents>().GirlDead = true;
            girl.GetComponent<GirlEvents>().GirlDieEvent();
            BoyGirlExit();
        }
    }

    public virtual void DistrItem()
    {
        nemetsStandart.GetComponent<AI_Nemets_Distr>().StartDist();
    }
}
