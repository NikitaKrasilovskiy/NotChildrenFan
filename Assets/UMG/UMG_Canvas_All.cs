using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UMG_Canvas_All : MonoBehaviour
{
    //Камень Ножницы Бумага
    private GameObject rps;
    private GameObject rpsGame;
    private GameObject rpsGirl;
    private GameObject rpsBoy;
    private GameObject rpsGirl_02;
    private GameObject rpsBoy_02;
    private GameObject number;
    public GameObject boyRef;
    public GameObject girlRef;
    private GameObject scaneData;
    private int scoreNumber;
    public Sprite[] rpsImage;
    public Image girlImageRps;
    public Image boylImageRps;
    [SerializeField] private GameObject story_Podorognik_01;
    [SerializeField] private GameObject story_Podorognik_02;
    [SerializeField] private GameObject story_General_01;
    [SerializeField] private GameObject story_General_02;
    [SerializeField] private GameObject story_Kran;
    [SerializeField] private GameObject story_map_01;
    [SerializeField] private GameObject story_map_02;
    [SerializeField] private GameObject story_map_03;
    [SerializeField] private GameObject story_map_04;


    private int rpsStatePlayer;
    public int RpsStatePlayer { get { return rpsStatePlayer; } set { rpsStatePlayer = value; } }
    //1 - девочка выграет
    //2 - мальчик выграет
    private int rpsBoyGirlWin;
    public int RpsBoyGirlWin { get { return rpsBoyGirlWin; } set { rpsBoyGirlWin = value; } }



    private void Awake()
    {
        rps = transform.Find("RPS").gameObject;
        rpsGirl = transform.Find("Girl_Chose").gameObject;
        rpsBoy = transform.Find("Boy_Chose").gameObject;
        rpsGirl_02 = transform.Find("Girl").gameObject;
        rpsBoy_02 = transform.Find("Boy").gameObject;
        rpsGame = transform.Find("RPS_game").gameObject;
        number = transform.Find("Numder").gameObject;
    }

    private void Start()
    {
        scaneData = GameObject.FindGameObjectWithTag("SceneData");
    }
    //RPS выбирает девушка
    public void RPSGirlChose()
    {       
        rps.SetActive(true);
        rpsGirl.SetActive(true);
    }
    //RPS выбирает девушка
    public void RPSBoyChose()
    {      
        rps.SetActive(true);
        rpsBoy.SetActive(true);
    }
    //Включает саму игру
    public void RPSStartGame()
    {
        scoreNumber = 4;
        rpsGame.SetActive(true);
        number.SetActive(true);
        rpsGirl_02.SetActive(true);
        rpsBoy_02.SetActive(true);
        rps.SetActive(false);
        rpsGirl.SetActive(false);
        rpsBoy.SetActive(false);
        TimeToGame();
    }
    //Отсчет времени
    public void TimeToGame()
    {
        scoreNumber--;
        number.GetComponent<Text>().text = scoreNumber.ToString();
        if(scoreNumber == 0)
        {
            number.SetActive(false);
            GoodGameRPS();
        }
        else if(scoreNumber > 0)
        {
            Invoke("TimeToGame", 1);
        }
    }
    //Подтасовка игры
    private void GoodGameRPS()
    {
        if(rpsBoyGirlWin == 2)
        {
            if (RpsStatePlayer == 1)
            {
                girlImageRps.sprite = rpsImage[1];
                boylImageRps.sprite = rpsImage[6];
            }
            else if (RpsStatePlayer == 2)
            {
                girlImageRps.sprite = rpsImage[2];
                boylImageRps.sprite = rpsImage[4];
            }
            else if (RpsStatePlayer == 3)
            {
                girlImageRps.sprite = rpsImage[3];
                boylImageRps.sprite = rpsImage[5];
            }
        }
        if (rpsBoyGirlWin == 1)
        {
            if (RpsStatePlayer == 1)
            {
                girlImageRps.sprite = rpsImage[6];
                boylImageRps.sprite = rpsImage[1];
            }
            else if (RpsStatePlayer == 2)
            {
                girlImageRps.sprite = rpsImage[4];
                boylImageRps.sprite = rpsImage[2];
            }
            else if (RpsStatePlayer == 3)
            {
                girlImageRps.sprite = rpsImage[5];
                boylImageRps.sprite = rpsImage[3];
            }
        }
        Invoke("FinishGameRPS", 2);
    }
    //Завершение игры
    private void FinishGameRPS()
    {
        rpsGame.SetActive(false);
        number.SetActive(false);
        rpsGirl_02.SetActive(false);
        rpsBoy_02.SetActive(false);

        if (rpsBoyGirlWin == 1)
        {
            boyRef.GetComponent<BoyMovement>().BoyStartMovement();
            scaneData.GetComponent<Scane_05_Data>().RPSWin();
        }
        else if (rpsBoyGirlWin == 2)
        {
            girlRef.GetComponent<GirlMovement>().GirlStartMovement();
        }
    }

    public void PodorognikImageOn_01()
    {
        story_Podorognik_01.SetActive(true);
        Invoke("PodorognikImageOn_02", 2);
    }
    public void PodorognikImageOn_02()
    {
        story_Podorognik_02.SetActive(true);
        Invoke("PodorognikImageOnOff", 2);
    }
    public void PodorognikImageOnOff()
    {
        story_Podorognik_01.SetActive(false);
        girlRef.GetComponent<GirlEvents>().PodorognikImageOff();
    }

    //Генерал имайдж
    public void GeneralImage()
    {
        story_General_01.SetActive(true);
        Invoke("GeneralImage_02", 2);
    }
    public void GeneralImage_02()
    {
        story_General_02.SetActive(true);
        Invoke("GeneralImageOff", 2);
    }
    public void GeneralImageOff()
    {
        story_General_01.SetActive(false);
    }

    //Подорожник кран
    public void KranImageOn()
    {
        story_Kran.SetActive(true);
        Invoke("KranImageOff", 2);
    }
    public void KranImageOff()
    {
        story_Kran.SetActive(false);
    }

    //Ивент с картой
    public void MapIvent()
    {
        story_map_01.SetActive(true);
        Invoke("MapIvent_02", 1.5f);
    }
    public void MapIvent_02()
    {
        story_map_02.SetActive(true);
        Invoke("MapIvent_03", 1.5f);
    }
    public void MapIvent_03()
    {
        story_map_03.SetActive(true);
        Invoke("MapIvent_04", 1.5f);
    }
    public void MapIvent_04()
    {
        story_map_04.SetActive(true);
        Invoke("MapIventOff", 1.5f);
    }
    public void MapIventOff()
    {
        story_map_01.SetActive(false);
    }
}
