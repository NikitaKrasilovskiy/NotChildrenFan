using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox2Floor : MonoBehaviour
{
    [SerializeField] private GameObject spawnPush_01;
    [SerializeField] private GameObject spawnPush_02;

    //Триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ClimbPushBox")
        {
            spawnPush_01.SetActive(false);
            spawnPush_02.SetActive(true);
        }      
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ClimbPushBox")
        {
            spawnPush_01.SetActive(true);
            spawnPush_02.SetActive(false);
        }
    }
}
