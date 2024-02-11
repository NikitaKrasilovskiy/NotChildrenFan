using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box15 : MonoBehaviour
{
    public int boxIndex;
    public int boxTriggerPosition;
    public int BoxTriggerPosition { get { return boxTriggerPosition; } set { boxTriggerPosition = value; } }
    public int freeZoneBox;
    public GameObject lightRef;
    private bool moveBoxOn;
    private bool moveBoxOn2;
    public bool MoveBoxOn2 { get { return moveBoxOn2; } set { moveBoxOn2 = value; } }
    private Vector3 moveToVector;

    // Update is called once per frame
    void Update()
    {
        if(moveBoxOn == true && transform.localPosition != moveToVector)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveToVector, 1.4f * Time.deltaTime);
        }

        if (moveBoxOn == true && transform.localPosition == moveToVector)
        {
            moveBoxOn2 = false;
        }
    }

    private void Start()
    {
        freeZoneBox = 16;
    }

    private void ChekWin()
    {
        lightRef.GetComponent<PlayerCont15>().Win15();
    }

    public void MoveToPosition()
    {
        if(moveBoxOn2 == false)
        {
            switch (boxTriggerPosition)
            {
                case 0:

                    break;
                case 1:
                    if (freeZoneBox == 2)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 5)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, 0, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 2:
                    if (freeZoneBox == 1)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 3)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 6)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 0, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 3:
                    if (freeZoneBox == 2)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 4)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 7)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 0, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 4:
                    if (freeZoneBox == 3)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 8)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, 0, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 5:
                    if (freeZoneBox == 1)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 6)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 9)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, -1, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 6:
                    if (freeZoneBox == 2)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 5)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 7)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 10)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -1, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 7:
                    if (freeZoneBox == 3)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 6)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 8)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 11)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -1, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 8:
                    if (freeZoneBox == 4)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, 1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 7)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 12)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, -1, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 9:
                    if (freeZoneBox == 5)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 10)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 13)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 10:
                    if (freeZoneBox == 6)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 9)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 11)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 14)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 11:
                    if (freeZoneBox == 7)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 10)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 12)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 15)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 12:
                    if (freeZoneBox == 8)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, 0, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 11)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 16)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 13:
                    if (freeZoneBox == 9)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 14)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 14:
                    if (freeZoneBox == 10)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 13)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-2, -2, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 15)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 15:
                    if (freeZoneBox == 11)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 14)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(-1, -2, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 16)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
                case 16:
                    if (freeZoneBox == 12)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(1, -1, 0);
                        moveBoxOn = true;
                    }
                    else if (freeZoneBox == 15)
                    {
                        lightRef.GetComponent<PlayerCont15>().freeZone = boxTriggerPosition;
                        moveToVector = new Vector3(0, -2, 0);
                        moveBoxOn = true;
                    }
                    break;
            }

            Invoke("ChekWin", 1);
            moveBoxOn2 = true;
        }
    }
}
