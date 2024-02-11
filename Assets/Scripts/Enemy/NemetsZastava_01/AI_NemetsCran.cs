using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NemetsCran : MonoBehaviour
{
    private Animator animatorAI;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InterEnviroument")
        {
            animatorAI.SetBool("isDie", true);
        }
    }

    public void DelateObj()
    {
        Destroy(gameObject);
    }
}
