using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_Data_Girl : MonoBehaviour
{
    private GameObject scaneData;


    // Start is called before the first frame update
    void Start()
    {
        scaneData = GameObject.FindGameObjectWithTag("SceneData");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            scaneData.GetComponent<Scane_05_Data>().OnGirl();
        }
    }
}
