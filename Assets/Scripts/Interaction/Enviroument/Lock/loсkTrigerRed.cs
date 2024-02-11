using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loсkTrigerRed : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject upLook;
    public EnvirInterBoyGirl_Class envirInterBoyGirl_Class;
    private bool redOn;
    private bool lockAmountRed;
    public bool LockAmountRed { get { return lockAmountRed; } set { lockAmountRed = value; } }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rlock")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            upLook.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            envirInterBoyGirl_Class.LockAmount2 = false;
            redOn = true;
            if (LockAmountRed == true)
            {
                envirInterBoyGirl_Class.LockAmountRed = true;
            }
        }
        if (other.tag == "Glock")
        {
            spriteRenderer.color = new Color(0, 1, 0, 1);
            upLook.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            envirInterBoyGirl_Class.LockAmount2 = true;
            envirInterBoyGirl_Class.LockAmountRed = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Rlock")
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            upLook.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            envirInterBoyGirl_Class.LockAmount2 = false;
            envirInterBoyGirl_Class.LockAmountRed = false;
            redOn = false;
        }
        if (other.tag == "Glock")
        {
            if(redOn == false)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
                upLook.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                envirInterBoyGirl_Class.LockAmount2 = false;
                envirInterBoyGirl_Class.LockAmountRed = false;
            }         
        }
    }
}
