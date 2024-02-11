using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamit_Zone_03 : EnvirInterBoyGirl_Class
{
    private bool isBoy;
    private bool isGirl;
    private bool girlOn;
    [SerializeField] private Scane_05_Data scaneData;
    public GameObject infoButRef;
    private bool boyUmg;
    public GameObject boyRef;
    [SerializeField] Sprite spriteImage;
    [SerializeField] Sprite spriteImage_02;
    private SpriteRenderer _spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        worckOnNeedItems = 0;
        scaneData = scaneData.GetComponent<Scane_05_Data>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UMGOnOff();
    }

    public override void EnvirWorck()
    {
        if (isGirl == true)
        {
            _spriteRenderer.sprite = spriteImage_02;
            girlOn = true;
        }
        if (isBoy == true && girlOn == true)
        {
            scaneData._BoyAnimator.SetBool("IsGirlRunEvent", true);
            scaneData.dinamitOn[2] = true;
            _spriteRenderer.sprite = spriteImage;
            scaneData.Dinamit_03On();
        }
    }

    private void UMGOnOff()
    {
        if (scaneData.dinamitOn[2] == false)
        {
            if (boyUmg == true && boyRef.GetComponent<BoyMovement>().ChangeActivePerson == 1)
            {
                infoButRef.SetActive(true);
                infoButRef.GetComponent<InfoButtons>().SetPosBoy();
            }
            else if (boyUmg == true && boyRef.GetComponent<BoyMovement>().ChangeActivePerson == 0)
            {
                infoButRef.SetActive(false);
            }
        }
        else if (scaneData.dinamitOn[2] == true)
        {
            infoButRef.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            isBoy = true;
            boyUmg = true;
            infoButRef.SetActive(true);
            infoButRef.GetComponent<InfoButtons>().SetPosGirl();
        }
        if (other.tag == "Player")
        {
            isGirl = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBoy")
        {
            isBoy = false;
            boyUmg = false;
            infoButRef.SetActive(false);
        }
        if (other.tag == "Player")
        {
            isGirl = false;
        }
    }
}
