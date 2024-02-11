using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroPlayer : MonoBehaviour
{
    public int zoneIndex;
    public GameObject scaneData;
    public GameObject electroshit;
    private bool getWire;
    private bool setWhire;
    public Animator WhiteWire;
    public Animator BlackWire;
    public Animator BlueWire;
    public Animator GreenWire;
    public Animator RedWire;
    private Animator currentAnimator;
    public Animator whireAnimator;
    private int animState;
    private int currentWhire;
    public int[] whireWin;

    private void Start()
    {
        whireWin = new int[6];       
    }

    public void WhireSave()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        LightMoveHorizontal();
        BoxMoveToPosition();
    }

    private void ElectroWin()
    {
        if(whireWin[1] == 3 && whireWin[2] == 5 && whireWin[3] == 4 && whireWin[4] == 2 && whireWin[5] == 1)
        {
            electroshit.GetComponent<ElectroEvent>().WhireOn = true;
            electroshit.GetComponent<ElectroEvent>().WinOnn();
        }
    }

    private void BoxMoveToPosition()
    {
        if (Input.GetButtonDown("Interaction") && getWire == false && setWhire == false)
        {
            transform.localPosition = new Vector3(0.888f, 1.63f, 0);

            switch (zoneIndex)
            {
                case 0:
                    currentAnimator = WhiteWire;
                    currentWhire = 1;
                    break;
                case 1:
                    currentAnimator = BlackWire;
                    currentWhire = 2;
                    break;
                case 2:
                    currentAnimator = BlueWire;
                    currentWhire = 3;
                    break;
                case 3:
                    currentAnimator = GreenWire;
                    currentWhire = 4;
                    break;
                case 4:
                    currentAnimator = RedWire;
                    currentWhire = 5;
                    break;               
            }

            getWire = true;
        }

        else if (Input.GetButtonDown("Interaction") && getWire == true && setWhire == false)
        {
            StartCoroutine(WhireTest());
            setWhire = true;
        }
    }

    IEnumerator WhireTest()
    {
        animState = 0;
        WhireAnimationOn();
        yield return new WaitForSeconds(0.5f);
        switch (zoneIndex)
        {
            case 5:
                animState = 1;
                break;
            case 6:
                animState = 2;
                break;
            case 7:
                animState = 3;
                break;
            case 8:
                animState = 4;
                break;
            case 9:
                animState = 5;
                break;
        }
        WhireAnimationOn();
        yield return new WaitForSeconds(0.5f);
        transform.localPosition = new Vector3(1.05f, -2.33f, 0);
        getWire = false;
        setWhire = false;
    }

    private void WhireAnimationOn()
    {
        currentAnimator.SetInteger("animState", animState);
        scaneData.GetComponent<Scane_04_Data>().WhireSave[currentWhire] = animState;
        whireWin[currentWhire] = animState;
        ElectroWin();
    }

    private void LightMoveHorizontal()
    {
        //В право
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            switch (zoneIndex)
            {
                case 0:

                    break;
                case 1:
                    transform.localPosition = new Vector3(1.05f, -2.33f, 0);
                    break;
                case 2:
                    transform.localPosition = new Vector3(-0.07f, -2.33f, 0);
                    break;
                case 3:
                    transform.localPosition = new Vector3(-1.13f, -2.33f, 0);
                    break;
                case 4:
                    transform.localPosition = new Vector3(-2.24f, -2.33f, 0);
                    break;
                case 5:

                    break;
                case 6:
                    transform.localPosition = new Vector3(0.888f, 1.63f, 0);
                    break;
                case 7:
                    transform.localPosition = new Vector3(-0.15f, 1.63f, 0);
                    break;
                case 8:
                    transform.localPosition = new Vector3(-1.21f, 1.63f, 0);
                    break;
                case 9:
                    transform.localPosition = new Vector3(-2.349f, 1.63f, 0);
                    break;
            }
        }

        //В лево
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            switch (zoneIndex)
            {
                case 0:
                    transform.localPosition = new Vector3(-0.07f, -2.33f, 0);
                    break;
                case 1:
                    transform.localPosition = new Vector3(-1.13f, -2.33f, 0);
                    break;
                case 2:
                    transform.localPosition = new Vector3(-2.24f, -2.33f, 0);
                    break;
                case 3:
                    transform.localPosition = new Vector3(-3.34f, -2.33f, 0);
                    break;
                case 4:

                    break;
                case 5:
                    transform.localPosition = new Vector3(-0.15f, 1.63f, 0);
                    break;
                case 6:
                    transform.localPosition = new Vector3(-1.21f, 1.63f, 0);
                    break;
                case 7:
                    transform.localPosition = new Vector3(-2.349f, 1.63f, 0);
                    break;
                case 8:
                    transform.localPosition = new Vector3(-3.377f, 1.63f, 0);
                    break;
                case 9:
                    
                    break;
            }
        }
    }
}
