using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_01 : Lock_Class
{
    public GameObject Carlock_01;
    private GameObject zatvorUp_01;
    private GameObject zatvorUp_02;
    private GameObject zatvorDown_01;
    private GameObject zatvorDown_02;
    private GameObject prugina_01;
    private GameObject prugina_02;
    private GameObject lockMoveL;
    private GameObject redLine;
    private GameObject greenLine;
    private GameObject fakeLock;
    //private loсkTrigerRed 


    public override void Start()
    {
        zatvorUp_01 = transform.Find("loсk_01Up").gameObject;
        zatvorUp_02 = transform.Find("loсk_02Up").gameObject;
        zatvorDown_01 = transform.Find("loсk_01down").gameObject;
        zatvorDown_02 = transform.Find("loсk_02down").gameObject;
        prugina_01 = transform.Find("loсk_Pr2").gameObject;
        prugina_02 = transform.Find("loсk_Pr").gameObject;
        redLine = transform.Find("redlook_01").gameObject;
        greenLine = transform.Find("Greenlook_01").gameObject;
        lockMoveL = transform.Find("otm").gameObject;
        fakeLock = transform.Find("otm_fake").gameObject;
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OpenZatvor_01()
    {
        zatvorUp_01.GetComponent<Rigidbody2D>().simulated = false;
        zatvorUp_01.transform.localPosition = new Vector3(1.311f, 1.369f, 0);
        zatvorUp_01.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        zatvorDown_01.GetComponent<Rigidbody2D>().simulated = false;
        zatvorDown_01.transform.localPosition = new Vector3(1.309f, -0.388f, 0);
        zatvorDown_01.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        lockMoveL.transform.localPosition = new Vector3(-0.97f, -1.725f, 0);
        redLine.transform.localPosition = new Vector3(-0.1510042f, 1.361f, 0);
        greenLine.transform.localPosition = new Vector3(-0.151f, 0.9779999f, 0);
        //Следующий замок при красном ресетит игру
        zatvorDown_02.GetComponent<loсkTrigerRed>().LockAmountRed = true;
        prugina_01.SetActive(false);
    }
    public override void OpenZatvor_02()
    {
        zatvorUp_02.GetComponent<Rigidbody2D>().simulated = false;
        zatvorUp_02.transform.localPosition = new Vector3(0.347f, 1.381f, 0);
        zatvorUp_02.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        zatvorDown_02.GetComponent<Rigidbody2D>().simulated = false;
        zatvorDown_02.transform.localPosition = new Vector3(0.34f, -0.388f, 0);
        zatvorDown_02.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        lockMoveL.transform.localPosition = new Vector3(-0.243f, -1.725f, 0);
        zatvorDown_02.GetComponent<loсkTrigerRed>().LockAmountRed = false;
        prugina_02.SetActive(false);
        StartLock = false;
        lockMoveL.transform.localPosition = new Vector3(0f, -1.725f, 0);

        StartLock = false;
        fakeLock.SetActive(true);
        lockMoveL.SetActive(false);
        Invoke("LockOn", 1f);
    }

    public override void ZatvorReset()
    {
        lockMoveL.transform.localPosition = new Vector3(0f, -1.725f, 0);
        zatvorUp_01.transform.localPosition = new Vector3(1.311f, 0.381f, 0);
        zatvorDown_01.transform.localPosition = new Vector3(1.309f, -0.388f, 0);
        zatvorUp_01.GetComponent<Rigidbody2D>().simulated = true;
        zatvorDown_01.GetComponent<Rigidbody2D>().simulated = true;
        zatvorUp_02.transform.localPosition = new Vector3(0.347f, 0.381f, 0);
        zatvorDown_02.transform.localPosition = new Vector3(0.34f, -0.388f, 0);
        zatvorUp_02.GetComponent<Rigidbody2D>().simulated = true;
        zatvorDown_02.GetComponent<Rigidbody2D>().simulated = true;
        zatvorDown_02.GetComponent<loсkTrigerRed>().LockAmountRed = false;
        redLine.transform.localPosition = new Vector3(1.837f, 1.361f, 0);
        greenLine.transform.localPosition = new Vector3(1.837002f, 0.9779999f, 0);
        prugina_01.SetActive(true);
    }

    //Замок открыт
    public override void LockOn()
    {
        Carlock_01.GetComponent<EnvirLockCar_01>().OpenLockB = true;
        Carlock_01.GetComponent<EnvirLockCar_01>().LockOpen = true;
        Carlock_01.GetComponent<EnvirLockCar_01>().OpenLock();
        otmRigidbody2d.simulated = false;
        lockMoveL.transform.localPosition = new Vector3(-0.243f, -1.725f, 0);
        gameObject.SetActive(false);
    }
}
