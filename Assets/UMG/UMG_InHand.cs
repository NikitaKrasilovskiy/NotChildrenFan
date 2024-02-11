using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UMG_InHand : MonoBehaviour
{
    //Референсы на персонажей
    public GameObject boyReference;
    public GameObject girlReference;
    //Масив картинок предметов
    public Sprite[] spriteImageThrowInHand;
    //Картинка используемого предмета
    private Image imageThrow;
    public Text ammoCount;

    private void Start()
    {
        //Назначает ссылки на Мальчика и Девочку
        //girlReference = GameObject.FindGameObjectWithTag("Player");
        //boyReference = GameObject.FindGameObjectWithTag("PlayerBoy");
        imageThrow = gameObject.GetComponent<Image>();
        ammoCount = gameObject.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        ChangeImageTrowInHand();
    }

    private void ChangeImageTrowInHand()
    {
        //Если выбрана девочка
        if(girlReference.GetComponent<CharactersMovement>().ChangeActivePerson == 0)
        {
            //Если у девлчки нет предмета для броска
            if (girlReference.GetComponent<GirlThrow>().IsItemInHand == false)
            {
                imageThrow.enabled = false;
                ammoCount.enabled = false;
            }
            //Если у девочки есть предмет для броска
            else if (girlReference.GetComponent<GirlThrow>().IsItemInHand == true)
            {
                imageThrow.enabled = true;
                ammoCount.enabled = false;
                imageThrow.sprite = spriteImageThrowInHand[girlReference.GetComponent<GirlThrow>().ThrowItemIndex];
            }
        }
        //Если выбран Мальчик
        else if (girlReference.GetComponent<CharactersMovement>().ChangeActivePerson == 1)
        {
            //Если у мальчика есть патроны на рогатку
            if (boyReference.GetComponent<BoyThrow>().AmountRockAmmo > 0)
            {
                imageThrow.enabled = true;
                ammoCount.enabled = true;
                imageThrow.sprite = spriteImageThrowInHand[0];
                ammoCount.text = boyReference.GetComponent<BoyThrow>().AmountRockAmmo.ToString();
            }
            //Если у мальчика нет патронов но есть предмет для броска
            else if(boyReference.GetComponent<BoyThrow>().AmountRockAmmo == 0 && boyReference.GetComponent<BoyThrow>().IsItemInHand == true)
            {
                imageThrow.sprite = spriteImageThrowInHand[boyReference.GetComponent<BoyThrow>().ThrowItemIndex];
            }
            //Если у мальчика нет патронов и нет предмета для броска
            else if (boyReference.GetComponent<BoyThrow>().AmountRockAmmo == 0 && boyReference.GetComponent<BoyThrow>().IsItemInHand == false)
            {
                ammoCount.enabled = true;
                imageThrow.sprite = spriteImageThrowInHand[0];
                ammoCount.text = boyReference.GetComponent<BoyThrow>().AmountRockAmmo.ToString();
            }
        }
    }

}
