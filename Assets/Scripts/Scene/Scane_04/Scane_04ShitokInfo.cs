using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_04ShitokInfo : EnvirInterBoyGirl_Class
{
    [SerializeField] private Scane_04_Data scaneData;

    public bool onOff;
    public GameObject podShit;
    private bool shitOn;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_04_Data>();
    }


    // Start is called before the first frame update
    void Start()
    {
        worckOnNeedItems = 0;
    }

    public override void EnvirWorck()
    {
        if(onOff == true && scaneData.PaytnashkiOn == false)
        {
            if(shitOn == false)
            {
                scaneData._GirlMovement.CantChange = true;
                scaneData._BoyMovement.CantChange = true;
                podShit.SetActive(true);
                shitOn = true;
            }
            else if (shitOn == true)
            {
                scaneData._GirlMovement.CantChange = false;
                scaneData._BoyMovement.CantChange = false;
                podShit.SetActive(false);
                shitOn = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerBoy")
        {
            podShit.SetActive(false);
            shitOn = false;
        }
    }
}
