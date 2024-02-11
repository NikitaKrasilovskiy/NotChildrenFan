using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_04OpenDoor : MonoBehaviour
{
    [SerializeField] private Scane_04_Data scaneData;
    private bool OnOff;

    private bool onOff;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_04_Data>();
    }

    private void Update()
    {
        //Встал в позу толкания
        if (Input.GetButtonDown("Crounch") && onOff == true && scaneData._BoyMovement.ChangeActivePerson == 1 && OnOff == false)
        {
            OnOff = true;
            scaneData.PaytnashkiStart();
        }
        else if (Input.GetButtonDown("Crounch") && onOff == true && scaneData._BoyMovement.ChangeActivePerson == 1 && OnOff == true)
        {
            OnOff = false;
            scaneData.PaytnashkiFinish();
        }
    }



    //Триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        //Хватается за ящик
        if (other.tag == "PlayerBoy")
        {
            onOff = true;
        }       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Отойти от ящика
        if (other.tag == "PlayerBoy")
        {
            onOff = false;
        }       
    }
}
