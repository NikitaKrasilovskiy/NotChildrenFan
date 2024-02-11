using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterEnvir_03Mouse : EnvirInterBoyGirl_Class
{
    private bool boyOrNot;
    private bool boyOrNot2;
    public GameObject boy;
    public GameObject girl;

    // Start is called before the first frame update
    void Start()
    {
        worckOnNeedItems = 0;
    }

    private void Update()
    {
        if (boyOrNot2 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -4f, transform.position.z), 2.8f * Time.deltaTime);
        }
    }

    public void BoyGirlEndEvent()
    {
        boy.GetComponent<BoyEvents>().Event_06End();
        girl.GetComponent<GirlEvents>().Event_06End();
    }

    public override void EnvirWorck()
    {
        if(boyOrNot == true)
        {
            boyOrNot2 = true;
            BoyGirlEndEvent();
            Invoke("dd", 4);
        }
    }

    private void dd()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            boyOrNot = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            boyOrNot = false;
        }
    }
}
