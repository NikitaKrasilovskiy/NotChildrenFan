using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroument_Interaction_Ammo_Class : MonoBehaviour
{
    protected bool isIneraction;
    public bool IsIneraction { get { return isIneraction; } set { isIneraction = value; } }
    public GameObject spawnGameObj;
    protected Vector3 spawnPosition;
    protected Quaternion spawnRotation;


    public virtual void InteractionAmmo()
    {      
        //DestroyObj();
    }


    public virtual void DestroyObj()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ammo" && isIneraction == false)
        {
            InteractionAmmo();
        }

        if (other.tag == "Floor")
        {
            DestroyObj();
        }
    }
}
