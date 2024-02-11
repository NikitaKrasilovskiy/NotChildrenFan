using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashPhyOff : MonoBehaviour
{
    private Rigidbody2D itemRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            itemRigidbody.simulated = false;
        }
    }
}
