using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_Class : MonoBehaviour
{

    //СИСТЕМА РАБОТЫ ОТМЫЧКИ НЕ ЗАВИСИТ ОТ КОЛИЧЕСВА ЗАТВОРОВ
    private GameObject lockMove;
    public Rigidbody2D otmRigidbody2d;
    protected bool startLock;
    public bool StartLock { get { return startLock; } set { startLock = value; } }

    // Start is called before the first frame update
    public virtual void Start()
    {
        lockMove = transform.Find("otm").gameObject;
    }

    public virtual void Update()
    {
        if(lockMove.transform.localPosition.y < -1.74f)
        {
            otmRigidbody2d.velocity = new Vector3(otmRigidbody2d.velocity.x, 0f, 0f);
            otmRigidbody2d.simulated = false;
        }
        LockOnMove();
    }
    
    //Движение отмычки
    private void LockOnMove()
    {
        //Если включен режим взлома
        if(StartLock == true)
        {
            //Движение ввкрх
            if (Input.GetAxisRaw("Vertical") > 0 && lockMove.transform.localPosition.y < -0.3f)
            {
                otmRigidbody2d.velocity = new Vector3(otmRigidbody2d.velocity.x, 1, 0f); 
                otmRigidbody2d.simulated = true;
            } 
            else if (Input.GetAxisRaw("Vertical") > 0 && lockMove.transform.localPosition.y > -0.3f)
            {
                otmRigidbody2d.velocity = new Vector3(otmRigidbody2d.velocity.x, 0, 0f);
            }
            //Движение вниз
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                
            }
            else if (Input.GetAxisRaw("Vertical") == 0)
            {
                otmRigidbody2d.velocity = new Vector3(otmRigidbody2d.velocity.x, -1, 0f);
            }
        }
    }

    public virtual void ZatvorReset()
    {
        
    }

    public virtual void OpenZatvor_01()
    {

    }
    public virtual void OpenZatvor_02()
    {

    }
    public virtual void OpenZatvor_03()
    {

    }
    public virtual void OpenZatvor_04()
    {

    }
    public virtual void OpenZatvor_05()
    {

    }


    public virtual void LockOn()
    {

    }
}
