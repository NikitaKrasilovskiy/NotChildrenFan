using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_03_xz : MonoBehaviour
{
    private GameObject boyRef;
    private GameObject girlRef;
    public UMG_Canvas_All canvasRef;
    public GameObject event_04;
    public int stateGame;

    // Start is called before the first frame update
    void Start()
    {
        girlRef = GameObject.FindGameObjectWithTag("Player");
        boyRef = GameObject.FindGameObjectWithTag("PlayerBoy");
        DevStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DevStart()
    {
        switch (stateGame)
        {
            case 0:
                boyRef.transform.position = new Vector3(-302.71f, -1.713435f, 0);
                girlRef.transform.position = new Vector3(-303.87f, -1.655756f, 0);
                boyRef.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                girlRef.GetComponent<GirlMovement>().CantChange = true;
                girlRef.GetComponent<GirlMovement>().GirlActive();
                boyRef.GetComponent<BoyMovement>().CantChange = true;
                boyRef.GetComponent<BoyMovement>().GirlActive();
                boyRef.GetComponent<BoyThrow>().AmountRockAmmo = 3;
                canvasRef.GetComponent<UMG_Canvas_All>().RPSGirlChose();
                canvasRef.GetComponent<UMG_Canvas_All>().RpsBoyGirlWin = 2;
                break;
            case 1:
                boyRef.transform.position = new Vector3(-255.51f, -1.713435f, 0);
                girlRef.transform.position = new Vector3(-256.67f, -1.655756f, 0);
                boyRef.GetComponent<BoyThrow>().AmountRockAmmo = 3;
                girlRef.GetComponent<GirlMovement>().CantChange = false;
                boyRef.GetComponent<BoyMovement>().CantChange = false;
                break;
            case 2:

                break;
            case 3:

                break;
        }
    }

    //Девочка убегает
    private void GirlEndRun()
    {
        if (girlRef.GetComponent<GirlEvents>().EventAdd[6] == true)
        {
            girlRef.GetComponent<GirlEvents>().Event_06_01();
            event_04.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("GirlEndRun", 0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
