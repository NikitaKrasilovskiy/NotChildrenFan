using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemStandart_All_Triggers : MonoBehaviour
{
    [SerializeField] private Scane_03_Data scaneData;
    [SerializeField] private Scane_04_Data scaneData_02;
    [SerializeField] private GameObject nemetsStandart;

    private AI_NemStandart_All _nemetsStandart;
    protected bool lightOn;
    protected bool leftLight;
    public bool LeftLight { get { return leftLight; } set { leftLight = value; } }
    protected bool rightLight;
    public bool RightLight { get { return rightLight; } set { rightLight = value; } }
    public bool lvlManage;

    //Немец
    private Animator animatorAI;

    public bool isCryorNot;

    private void Awake()
    {      
        _nemetsStandart = nemetsStandart.GetComponent<AI_NemStandart_All>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInParent<Animator>();

        if (lvlManage == false)
        {
            scaneData = scaneData.GetComponent<Scane_03_Data>();
        }
        else if (lvlManage == true)
        {
            scaneData_02 = scaneData_02.GetComponent<Scane_04_Data>();
        }
    }

    private void Update()
    {
        
    }

    //Вход в первый тригер (Присматривается)
    public virtual void FirstSeeBoyGirl()
    {
        if(_nemetsStandart.LeftRightDirection == false && leftLight == false)
        {
            animatorAI.SetInteger("SeeBoyState", 1);
            _nemetsStandart.IsSeeBoyGirl = true;
        }
        else if (_nemetsStandart.LeftRightDirection == true && rightLight == false)
        {
            animatorAI.SetInteger("SeeBoyState", 1);
            _nemetsStandart.IsSeeBoyGirl = true;
        }
    }
    //Выход из первого триггера
    public virtual void BoyGirlExit()
    {
        animatorAI.SetInteger("SeeBoyState", 0);
        _nemetsStandart.IsSeeBoyGirl = false;
    }

    //Вход во второй тригер парень
    public virtual void BoyTrigger_02On()
    {
        if (_nemetsStandart.LeftRightDirection == false && leftLight == false)
        {
            _nemetsStandart.StopPatroll();
            animatorAI.SetInteger("SeeBoyState", 2);
            Invoke("BoyDead", 0.5f);
        }
        else if (_nemetsStandart.LeftRightDirection == true && rightLight == false)
        {
            _nemetsStandart.StopPatroll();
            animatorAI.SetInteger("SeeBoyState", 2);
            Invoke("BoyDead", 0.5f);
        }
    }

    //Вход во второй тригер девочка
    public virtual void GirlTrigger_02On()
    {
        if (_nemetsStandart.LeftRightDirection == false && leftLight == false)
        {
            //Если нельзя воздействовать плачем
            if (isCryorNot == false)
            {
                _nemetsStandart.StopPatroll();
                animatorAI.SetInteger("SeeBoyState", 2);
                Invoke("GirlDead", 0.5f);
            }
        }
        else if (_nemetsStandart.LeftRightDirection == true && rightLight == false)
        {
            //Если нельзя воздействовать плачем
            if (isCryorNot == false)
            {
                _nemetsStandart.StopPatroll();
                animatorAI.SetInteger("SeeBoyState", 2);
                Invoke("GirlDead", 0.5f);
            }
        }
    }

    //Пацан входит в третий тригер
    //Вход во второй тригер парень
    public virtual void BoyTrigger_03On()
    {
        _nemetsStandart.StopPatroll();
        animatorAI.SetInteger("SeeBoyState", 2);
        Invoke("BoyDead", 0.5f);
    }

    //Девочка входит в третий тригер
    public virtual void GirlTrigger_03On()
    {
        //Если нельзя воздействовать плачем
        if (isCryorNot == false)
        {
            _nemetsStandart.StopPatroll();
            animatorAI.SetInteger("SeeBoyState", 2);
            Invoke("GirlDead", 0.5f);
        }
        //Если нельзя воздействовать плачем
        if (isCryorNot == false)
        {
            _nemetsStandart.StopPatroll();
            animatorAI.SetInteger("SeeBoyState", 2);
            Invoke("GirlDead", 0.5f);
        }
    }

    //Пацан умирает
    private void BoyDead()
    {
        if(lvlManage == false)
        {
            if (scaneData._BoyEvents.BoyDead == false)
            {
                scaneData._BoyEvents.BoyDead = true;
                scaneData._BoyEvents.BoyDieEvent();
                BoyGirlExit();
            }
        }
        else if (lvlManage == true)
        {
            if (scaneData_02._BoyEvents.BoyDead == false)
            {
                scaneData_02._BoyEvents.BoyDead = true;
                scaneData_02._BoyEvents.BoyDieEvent();
                BoyGirlExit();
            }
        }

    }
    //Девочка умирает
    private void GirlDead()
    {
        if (lvlManage == false)
        {
            if (scaneData._BoyEvents.BoyDead == false)
            {
                scaneData._GirlEvents.GirlDead = true;
                scaneData._GirlEvents.GirlDieEvent();
                BoyGirlExit();
            }
        }
        else if (lvlManage == true)
        {
            if (scaneData_02._BoyEvents.BoyDead == false)
            {
                scaneData_02._GirlEvents.GirlDead = true;
                scaneData_02._GirlEvents.GirlDieEvent();
                BoyGirlExit();
            }
        }       
    }
}
