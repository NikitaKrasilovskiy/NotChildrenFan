using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_02 : Lock_Class
{
    public GameObject Carlock_01;
    private GameObject zatvorUp_01;
    private GameObject zatvorUp_02;
    private GameObject zatvorUp_03;
    private GameObject zatvorDown_01;
    private GameObject zatvorDown_02;
    private GameObject zatvorDown_03;
    private GameObject prugina_01;
    private GameObject prugina_02;
    private GameObject prugina_03;
    private GameObject lockMoveL;
    private GameObject redLine;
    private GameObject greenLine;
    //private loсkTrigerRed 


    public override void Start()
    {
        zatvorUp_01 = transform.Find("loсk_01Up").gameObject;
        zatvorUp_02 = transform.Find("loсk_02Up").gameObject;
        zatvorUp_03 = transform.Find("loсk_03Up").gameObject;
        zatvorDown_01 = transform.Find("loсk_01down").gameObject;
        zatvorDown_02 = transform.Find("loсk_02down").gameObject;
        zatvorDown_03 = transform.Find("loсk_03down").gameObject;
        prugina_01 = transform.Find("loсk_Pr2").gameObject;
        prugina_02 = transform.Find("loсk_Pr").gameObject;
        prugina_03 = transform.Find("loсk_Pr3").gameObject;
        redLine = transform.Find("redlook_01").gameObject;
        greenLine = transform.Find("Greenlook_01").gameObject;
        lockMoveL = transform.Find("otm").gameObject;
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
        zatvorDown_03.GetComponent<loсkTrigerRed>().LockAmountRed = true;
        redLine.transform.localPosition = new Vector3(-1.101f, 1.361f, 0);
        greenLine.transform.localPosition = new Vector3(-1.101012f, 0.9779999f, 0);
        prugina_02.SetActive(false);
        lockMoveL.transform.localPosition = new Vector3(-1.907f, -1.725f, 0);
    }

    public override void OpenZatvor_03()
    {
        zatvorUp_03.GetComponent<Rigidbody2D>().simulated = false;
        zatvorUp_03.transform.localPosition = new Vector3(-0.582f, 1.394f, 0);
        zatvorUp_03.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        zatvorDown_03.GetComponent<Rigidbody2D>().simulated = false;
        zatvorDown_03.transform.localPosition = new Vector3(-0.5889812f, -0.388f, 0);
        zatvorDown_03.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        lockMoveL.transform.localPosition = new Vector3(-0.243f, -1.725f, 0);
        zatvorDown_03.GetComponent<loсkTrigerRed>().LockAmountRed = false;
        zatvorDown_02.GetComponent<loсkTrigerRed>().LockAmountRed = false;
        prugina_03.SetActive(false);
        otmRigidbody2d.simulated = false;
        StartLock = false;
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
        zatvorUp_03.transform.localPosition = new Vector3(-0.582f, 0.389f, 0);
        zatvorDown_03.transform.localPosition = new Vector3(-0.5889812f, -0.388f, 0);
        zatvorUp_03.GetComponent<Rigidbody2D>().simulated = true;
        zatvorDown_03.GetComponent<Rigidbody2D>().simulated = true;

        prugina_01.SetActive(true);
        prugina_02.SetActive(true);

        zatvorDown_02.GetComponent<loсkTrigerRed>().LockAmountRed = false;
        zatvorDown_03.GetComponent<loсkTrigerRed>().LockAmountRed = false;
    }

    //Замок открыт
    public override void LockOn()
    {
        Carlock_01.GetComponent<EnvirLockCar_02>().OpenLockB = true;
        Carlock_01.GetComponent<EnvirLockCar_02>().EnvirWorck();
        Carlock_01.GetComponent<EnvirLockCar_02>().OpenLock();
        gameObject.SetActive(false);
    }
}
