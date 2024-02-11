using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_02_TeleportTrane : MonoBehaviour
{
    [SerializeField] private Scane_02_Data scaneData;

    //Полна на поезде
    private GameObject floorCollisionTrane;
    [SerializeField] private GameObject boxClimb;
    [SerializeField] private GameObject box;
    private bool onTrane;

    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_02_Data>();
    }

    // Start is called before the first frame update
    void Start()
    {
        floorCollisionTrane = transform.Find("Floor_02").gameObject;
    }


    public void TraneFloorOn()
    {
        scaneData._GirlMovement.GirlStopMovement();
        scaneData._GirlMovement.DontCallBoyGirl();
        scaneData._GirlAnimator.SetBool("isJumpTo", true);
        floorCollisionTrane.SetActive(true);
        scaneData._GirlMovement.IsOnBox = false;
        Invoke("TeleportOnTrane", 1f);
    }

    private void TeleportOnTrane()
    {
        scaneData.GirlRef.transform.position = Vector3.Lerp(scaneData.GirlRef.transform.position, new Vector3(scaneData.GirlRef.transform.position.x, scaneData.GirlRef.transform.position.y, 2), 2);
        boxClimb.SetActive(false);
        box.SetActive(true);
        onTrane = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && onTrane == false)
        {
            Invoke("TraneFloorOn", 0.1f);
        }
    }
}
