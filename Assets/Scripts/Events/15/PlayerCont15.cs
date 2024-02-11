using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont15 : MonoBehaviour
{
    public int zoneIndex;
    private bool moveOn;
    private Box15 boxRef;
    public Box15[] boxArr;
    public int freeZone;
    public GameObject scaneData;
    private bool boxGo;
    private bool boxbox;
    private float horizontalMove;
    private float verticalMove;

    private void Start()
    {
        freeZone = 16;
    }

    // Update is called once per frame
    void Update()
    {
        LightMoveHorizontal();
        LightMoveVertical();
        BoxMoveToPosition();
    }

    private void BoxMoveToPosition()
    {
        if (Input.GetButtonDown("Interaction") && moveOn == false)
        {
            boxRef.freeZoneBox = freeZone;
            boxRef.MoveToPosition();
        }
    }

    public void Win15()
    {
        if(boxArr[0].boxTriggerPosition == 1 && boxArr[1].boxTriggerPosition == 2 && boxArr[2].boxTriggerPosition == 3 && boxArr[3].boxTriggerPosition == 4)
        {
            if(boxArr[4].boxTriggerPosition == 5 && boxArr[5].boxTriggerPosition == 6 && boxArr[6].boxTriggerPosition == 7 && boxArr[7].boxTriggerPosition == 8)
            {
                if(boxArr[8].boxTriggerPosition == 9 && boxArr[9].boxTriggerPosition == 10 && boxArr[10].boxTriggerPosition == 11 && boxArr[11].boxTriggerPosition == 12)
                {
                    if(boxArr[12].boxTriggerPosition == 13 && boxArr[13].boxTriggerPosition == 14 && boxArr[14].boxTriggerPosition == 15)
                    {
                        scaneData.GetComponent<Scane_04_Data>().PaytnashkiWin();
                    }
                }
            }
        }
    }

    private void LightMoveHorizontal()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        //В право
        if (horizontalMove > 0 && boxGo == false)
        {
            boxGo = true;

            switch (zoneIndex)
            {
                case 0:
                   
                    break;
                case 1:
                    transform.localPosition = new Vector3(-1, 1, 0);
                    break;
                case 2:
                    transform.localPosition = new Vector3(0, 1, 0);
                    break;
                case 3:
                    transform.localPosition = new Vector3(1, 1, 0);
                    break;
                case 4:

                    break;
                case 5:
                    transform.localPosition = new Vector3(-1, 0, 0);
                    break;
                case 6:
                    transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 7:
                    transform.localPosition = new Vector3(1, 0, 0);
                    break;
                case 8:

                    break;
                case 9:
                    transform.localPosition = new Vector3(-1, -1, 0);
                    break;
                case 10:
                    transform.localPosition = new Vector3(0, -1, 0);
                    break;
                case 11:
                    transform.localPosition = new Vector3(1, -1, 0);
                    break;
                case 12:

                    break;
                case 13:
                    transform.localPosition = new Vector3(-1, -2, 0);
                    break;
                case 14:
                    transform.localPosition = new Vector3(0, -2, 0);
                    break;
                case 15:
                    transform.localPosition = new Vector3(1, -2, 0);
                    break;
                case 16:

                    break;
            }

            Invoke("ResetBool", 0.2f);
        }
        //В лево
        if (horizontalMove < 0 && boxGo == false)
        {
            boxGo = true;

            switch (zoneIndex)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:
                    transform.localPosition = new Vector3(-2, 1, 0);
                    break;
                case 3:
                    transform.localPosition = new Vector3(-1, 1, 0);
                    break;
                case 4:
                    transform.localPosition = new Vector3(0, 1, 0);
                    break;
                case 5:

                    break;
                case 6:
                    transform.localPosition = new Vector3(-2, 0, 0);
                    break;
                case 7:
                    transform.localPosition = new Vector3(-1, 0, 0);
                    break;
                case 8:
                    transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 9:

                    break;
                case 10:
                    transform.localPosition = new Vector3(-2, -1, 0);
                    break;
                case 11:
                    transform.localPosition = new Vector3(-1, -1, 0);
                    break;
                case 12:
                    transform.localPosition = new Vector3(0, -1, 0);
                    break;
                case 13:

                    break;
                case 14:
                    transform.localPosition = new Vector3(-2, -2, 0);
                    break;
                case 15:
                    transform.localPosition = new Vector3(-1, -2, 0);
                    break;
                case 16:
                    transform.localPosition = new Vector3(0, -2, 0);
                    break;

            }

            Invoke("ResetBool", 0.2f);
        }
    }


    private void LightMoveVertical()
    {
        verticalMove = Input.GetAxisRaw("Vertical");

        if (verticalMove > 0 && boxGo == false)
        {
            boxGo = true;

            switch (zoneIndex)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:
                    
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    transform.localPosition = new Vector3(-2, 1, 0);
                    break;
                case 6:
                    transform.localPosition = new Vector3(-1, 1, 0);
                    break;
                case 7:
                    transform.localPosition = new Vector3(0, 1, 0);
                    break;
                case 8:
                    transform.localPosition = new Vector3(1, 1, 0);
                    break;
                case 9:
                    transform.localPosition = new Vector3(-2, 0, 0);
                    break;
                case 10:
                    transform.localPosition = new Vector3(-1, 0, 0);
                    break;
                case 11:
                    transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 12:
                    transform.localPosition = new Vector3(1, 0, 0);
                    break;
                case 13:
                    transform.localPosition = new Vector3(-2, -1, 0);
                    break;
                case 14:
                    transform.localPosition = new Vector3(-1, -1, 0);
                    break;
                case 15:
                    transform.localPosition = new Vector3(0, -1, 0);
                    break;
                case 16:
                    transform.localPosition = new Vector3(1, -1, 0);
                    break;
            }

            Invoke("ResetBool", 0.2f);
        }

        if (verticalMove < 0 && boxGo == false)
        {
            boxGo = true;

            switch (zoneIndex)
            {
                case 0:

                    break;
                case 1:
                    transform.localPosition = new Vector3(-2, 0, 0);
                    break;
                case 2:
                    transform.localPosition = new Vector3(-1, 0, 0);
                    break;
                case 3:
                    transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 4:
                    transform.localPosition = new Vector3(1, 0, 0);
                    break;
                case 5:
                    transform.localPosition = new Vector3(-2, -1, 0);
                    break;
                case 6:
                    transform.localPosition = new Vector3(-1, -1, 0);
                    break;
                case 7:
                    transform.localPosition = new Vector3(0, -1, 0);
                    break;
                case 8:
                    transform.localPosition = new Vector3(1, -1, 0);
                    break;
                case 9:
                    transform.localPosition = new Vector3(-2, -2, 0);
                    break;
                case 10:
                    transform.localPosition = new Vector3(-1, -2, 0);
                    break;
                case 11:
                    transform.localPosition = new Vector3(0, -2, 0);
                    break;
                case 12:
                    transform.localPosition = new Vector3(1, -2, 0);
                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;

            }

            Invoke("ResetBool", 0.2f);
        }
    }

    private void ResetBool()
    {
        boxGo = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            //if(boxbox == false)
            //{
            //    boxbox = true;
            //}
            boxRef = other.GetComponent<Box15>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            //if (boxbox == true)
            //{
            //    boxbox = false;
            //}

            //boxRef = null;
        }
    }
}
