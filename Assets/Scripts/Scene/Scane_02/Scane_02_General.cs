using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scane_02_General : MonoBehaviour
{
    [SerializeField]private Scane_02_Data scaneData;
    private float moveSpeedGeneral;
    public Transform generalTransform;
    public Transform generalImageOn;
    private bool generalOn;
    public bool GeneralOn { get { return generalOn; } set { generalOn = value; } }
    private bool seeBoy;
    public bool SeeBoy { get { return seeBoy; } set { seeBoy = value; } }


    private void Awake()
    {
        scaneData = scaneData.GetComponent<Scane_02_Data>();
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedGeneral = 6;
        Invoke("StartGeneral", 4);
    }

    private void Update()
    {
        if (generalOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, generalTransform.position, moveSpeedGeneral * Time.deltaTime);          
        }

        if (transform.position == generalTransform.position && generalOn == true)
        {
            generalOn = false;
            Invoke("DesGeneral", 0.5f);
        }
    }

    private void GeneralImage()
    {
        scaneData.GeneralImageOn();
    }

    public void StartGeneral()
    {
        generalOn = true;
    }

    private void DesGeneral()
    {
        scaneData.GeneralOff();        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            if(seeBoy == false)
            {
                BoyGirlRes();
            }
            else if(seeBoy == true)
            {
             
            }
        }

        if (other.tag == "ImageOn")
        {
            GeneralImage();
        }

    }

    private void BoyGirlRes()
    {
        scaneData.GeneralSeeBoyGirl();
    }
}
