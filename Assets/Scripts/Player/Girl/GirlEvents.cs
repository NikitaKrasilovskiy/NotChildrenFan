using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlEvents : MonoBehaviour
{
    public Transform runPoint_01;

    /// Переработать для обучения
    private GameObject lerningCloud;
    /// </summary>

    [SerializeField] private GameObject boyRef;
    [SerializeField] private UMG_Canvas_All _canvasRef;
    private EventOn_Class eventOn_class;
    private GirlMovement _girlMovement;

    //Референс на облако комикса
    private GameObject comixCloud;
    private GameObject crossNot;
    //Отмечает пройденные ивенты
    private bool[] eventAdd;
    public bool[] EventAdd { get { return eventAdd; } set { eventAdd = value; } }
    private bool[] evendEnd;
    private bool eventOffOn;
    public bool EventOffOn { get { return eventOffOn; } set { eventOffOn = value; } }
    //Индекс исполняемого ивента
    private int eventIndex;
    public int EventIndex { get { return eventIndex; } set { eventIndex = value; } }
    //Спрайт в облаке
    private GameObject eventSprite;
    //Спрайты для облака комикса
    public Sprite[] spriteEventSprite;
    //Предлагаемый предмет
    private int eventItemIndex;
    public int EventItemIndex { get { return eventItemIndex; } set { eventItemIndex = value; } }
    //Позиция респавна
    private Vector3 curentSavePosition;
    public Vector3 CurentSavePosition { get { return curentSavePosition; } set { curentSavePosition = value; } }
    private GameObject blackScreen;
    private bool girlDead;
    public bool GirlDead { get { return girlDead; } set { girlDead = value; } }
    private float girlRunToPosition;
    public float GirlRunToPosition { get { return girlRunToPosition; } set { girlRunToPosition = value; } }
    private bool girlGoToBoy;
    public bool GirlGoToBoy { get { return girlGoToBoy; } set { girlGoToBoy = value; } }
    private bool girlRunToPositionEvent;
    public bool GirlRunToPositionEvent { get { return girlRunToPositionEvent; } set { girlRunToPositionEvent = value; } }
    private int girlRunToPositionEventState;
    public int GirlRunToPositionEventState { get { return girlRunToPositionEventState; } set { girlRunToPositionEventState = value; } }


    private void Awake()
    {
        //Референс на облочко комикса
        comixCloud = transform.Find("ComixClouds").gameObject;
        eventSprite = transform.Find("Sprite_01").gameObject;
        crossNot = transform.Find("Sprite_02").gameObject;
        lerningCloud = transform.Find("LernCloud").gameObject;
        _girlMovement = gameObject.GetComponent<GirlMovement>();
        _canvasRef = _canvasRef.GetComponent<UMG_Canvas_All>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
        eventAdd = new bool[10];
        evendEnd = new bool[10];


        comixCloud.SetActive(false);
    }

    private void Update()
    {
        if (eventAdd[0] == true && eventOffOn == true && transform.position.x != runPoint_01.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(runPoint_01.position.x, transform.position.y, transform.position.z), 1.4f * Time.deltaTime);
        }
        else if (eventAdd[0] == true && eventOffOn == true && transform.position.x == runPoint_01.position.x)
        {
            Event_00End();
        }
        if (eventAdd[3] == true && eventOffOn == true && transform.position.x != runPoint_01.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(runPoint_01.position.x, transform.position.y, transform.position.z), 1.4f * Time.deltaTime);
        }
        else if (eventAdd[3] == true && eventOffOn == true && transform.position.x == runPoint_01.position.x)
        {
            //Event_000End();
        }

        if (eventAdd[6] == true && eventOffOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-305.04f, transform.position.y, transform.position.z), 3f * Time.deltaTime);
        }

        if (eventAdd[7] == true && eventOffOn == true && transform.position.x != girlRunToPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(girlRunToPosition, transform.position.y, transform.position.z), 3.5f * Time.deltaTime);
        }
        else if (eventAdd[7] == true && eventOffOn == true && transform.position.x == girlRunToPosition)
        {
            Event_07Stop();
        }
    }


    //Берет информацию о ивенте и запускает Ивент Машину
    public void SetEventsInfo()
    {
        eventIndex = eventOn_class.EventIndex;
        EventsMashine();
    }

    //Ивент машина
    public void EventsMashine()
    {       
        //ЗАпускает ивент
        switch (eventIndex)
        {
            case 0:
                break;
            case 1:                
                break;
            //Ивент с подорожником
            case 2:
                if (eventAdd[2] == false)
                {
                    Event_02();
                }
                break;
            case 3:
                break;
            //Ивент с мышкой
            case 6:
                if (eventAdd[6] == false)
                {
                    Event_06();
                }
                break;
        }
    }

    //Первая сцена ивент с генералом
    public void Event_00()
    {
        StartCoroutine(GirlEvent_00());
    }

    //Ивент с генералом идет за ящик
    IEnumerator GirlEvent_00()
    {
        yield return new WaitForSeconds(1f);
        eventAdd[0] = true;
        eventOffOn = true;
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 1);
    }
    //Ивент с генералом за ящиком
    public void Event_00End()
    {
        StartCoroutine(GirlEvent_00End());
    }
    //Ивент с генералом пришла за ящик
    IEnumerator GirlEvent_00End()
    {
        eventAdd[0] = false;
        eventOffOn = false;
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 0);
        yield return new WaitForSeconds(0.2f);
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 3);
    }
    //Ивент с генералом генерал проехал мимо
    public void Event_000()
    {
        StartCoroutine(GirlEvent_000());
    }

    //Идет на точку
    IEnumerator GirlEvent_000()
    {
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 0);
        yield return new WaitForSeconds(1f);
        eventAdd[3] = true;
        eventOffOn = true;
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 1);
    }
    //Ивент с генералом конец
    public void Event_000End()
    {

    }
    //Первая сцена Ивент_01 
    //Парень подходит к посту
    public void Event_01()
    {
        _girlMovement.CantChange = false;
        _girlMovement.GirlStartMovement();
    }

    //Первая сцена Ивент_02
    //Девочка спотыкается об камень и останавлявается
    //Запускается мульт картинка и включается передвижение мальчика
    public void Event_02()
    {
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 0);
        eventAdd[3] = false;
        //_girlMovement._GirlAnimator.SetBool("isFall2", true);
        _girlMovement._GirlAnimator.SetInteger("isFall", 1);
        _girlMovement._GirlAnimator.SetBool("isWalk", false);
        _girlMovement._GirlAnimator.SetInteger("IdleWalkState", 0);
        _girlMovement.ControlRot = false;
        eventOffOn = true;
        eventAdd[2] = true;
        ChangePersonCantChangeBack();
        eventIndex = 2;
    }

    public void PodorognikImage()
    {
        _canvasRef.PodorognikImageOn_01();
    }
    public void PodorognikImageOff()
    {
        _girlMovement._GirlAnimator.SetInteger("isFall", 2);
        Invoke("GirlCry", 0.5f);
        Invoke("PodorognikImageBuble", 1f);
    }
    public void PodorognikImageBuble()
    {
        SpriteEventOn();
    }

    private void GirlCry()
    {
        _girlMovement.GirlCryOn();
    }
    //Завершение ивента_02
    public void Event_02End()
    {
        if (eventItemIndex == 1)
        {
            evendEnd[1] = true;
            crossNot.SetActive(true);
            eventSprite.GetComponent<SpriteRenderer>().sprite = spriteEventSprite[3];
            Invoke("DelaySpriteEventBack", 3);
        }
        else if(eventItemIndex == 2)
        {
            evendEnd[2] = true;
            crossNot.SetActive(true);
            eventSprite.GetComponent<SpriteRenderer>().sprite = spriteEventSprite[4];
            Invoke("DelaySpriteEventBack", 3);
        }
        //когда пацан принес оба растения, снимает блок и переключает на девочку
        if(evendEnd[1] == true && evendEnd[2] == true)
        {
            //Invoke("Event_02EndEnd", 1f);
            Invoke("EndSpriteEvent", 3.5f);
        }
    }
    //Поле того как дает 2 неверных растения
    private void Event_02EndEnd()
    {
        //_girlMovement._GirlAnimator.SetBool("isFall2", false);
        _girlMovement._GirlAnimator.SetInteger("isFall", 0);
        ChangePersonBack();
        ChangePersonToGirl();
        _girlMovement._BoyEvent.event_02End();
    }
    //Когда дает подорожник
    public void Event_02GoodEnd()
    {
        _girlMovement.GirlCryOff();
        _canvasRef.KranImageOn();
        EventOffOn = false;
    }

    //Ивент_03 подходит к солдату плача
    public void Event_03()
    {
        gameObject.transform.position = new Vector3(-266.533f, -1.995f, 0);
        _girlMovement.GirlStopMovement();
        _girlMovement.MoveAnimationStateMashine = 0;
        _girlMovement.AnimationStateMashine();
        lerningCloud.SetActive(true);
        _girlMovement.ControlRot = true;
        Invoke("LernCloudOff", 5);
    }
    //Ивент_03 завершение
    public void Event_03End()
    {
        _girlMovement.GirlStartMovement();
        _girlMovement._BoyEvent.MicleJDance();
        _girlMovement.ControlRot = false;
        lerningCloud.SetActive(false);
    }
    //Ивент с мышкой
    public void Event_06()
    {
        StartCoroutine(GirlEvent_06());
        _girlMovement._GirlAnimator.SetBool("isScare", true);
    }

    //Бежит к пацану
    IEnumerator GirlEvent_06()
    {
        eventAdd[6] = true;
        _girlMovement.GirlStopMovement();
        yield return new WaitForSeconds(1f);
        eventOffOn = true;
        transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 2);
    }
    //Ивент с мышкой
    public void Event_06_01()
    {
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 0);
        StartCoroutine(GirlEvent_06_01());
    }
    IEnumerator GirlEvent_06_01()
    {
        eventAdd[6] = false;
        SpriteEventOn();
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(1f);
        _girlMovement.BoyActive();
        _girlMovement._BoyEvent.Event_06();
        yield return new WaitForSeconds(5f);
        EndSpriteEvent();
    }
    //Завершение ивета _06
    public void Event_06End()
    {
        _girlMovement.CantWalkRight = false;
        _girlMovement.GirlStartMovement();
        eventOffOn = false;
    }

    //Ивент с динамитом
    public void Event_07()
    {
        StartCoroutine(GirlEvent_07());
    }

    //Бежит с динамитом
    IEnumerator GirlEvent_07()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        eventAdd[7] = true;
        _girlMovement.GirlStopMovement();
        yield return new WaitForSeconds(0.1f);
        eventOffOn = true;
        _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 2);
    }
    public void Event_07Stop()
    {
        if (girlRunToPositionEvent == false)
        {
            _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 0);
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            eventOffOn = false;
            eventAdd[7] = false;
        }
        else if(girlRunToPositionEvent == true)
        {
            switch (girlRunToPositionEventState)
            {
                case 0:
                    GirlRunToPosition = -271.152f;
                    break;
                case 1:
                    GirlRunToPosition = -227.84f;
                    break;
                case 2:
                    GirlRunToPosition = -182.29f;
                    break;
            }
            _girlMovement._GirlAnimator.SetInteger("ScaneMoveState", 0);
            eventOffOn = false;
            eventAdd[7] = false;
            _girlMovement._GirlAnimator.SetBool("IsGirlRunEvent", true);
            girlRunToPositionEvent = false;
            Invoke("Event_07", 1);
        }
    }

    //Смерть пацана, запускается черный экран и пацан телепортируется
    public void GirlDieEvent()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        _girlMovement.GirlStopMovement();
        yield return new WaitForSeconds(1f);
        this.transform.position = curentSavePosition;
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", false);
        yield return new WaitForSeconds(0.5f);
        _girlMovement.GirlStartMovement();
        girlDead = false;
    }

    //Режим взлома замка
    public void GirlLockOn()
    {
        _girlMovement._BoyEvent.BoyLockOn();
        _girlMovement.CantChange = true;
        _girlMovement.GirlStopMovement();
    }
    //Режим взлома замка
    public void GirlLockOff()
    {
        _girlMovement._BoyEvent.BoyLockOff();
        _girlMovement.CantChange = false;
        _girlMovement.GirlStartMovement();
    }
    //Включает облачко с необходимым предметом
    public void SpriteEventOn()
    {
        eventSprite.GetComponent<SpriteRenderer>().sprite = spriteEventSprite[eventIndex];
        comixCloud.SetActive(true);
        eventSprite.SetActive(true);
    }

    //Возвращает нужную картинку в облако запроса
    private void DelaySpriteEventBack()
    {
        crossNot.SetActive(false);
        eventSprite.GetComponent<SpriteRenderer>().sprite = spriteEventSprite[eventIndex];
    }

    //Убирает Облако с нужным предметом
    public void EndSpriteEvent()
    {
        eventSprite.SetActive(false);
        comixCloud.SetActive(false);
        crossNot.SetActive(false);
        eventSprite.GetComponent<SpriteRenderer>().sprite = null;
    }

    //Убирает облако с подсказкой обучалкой
    private void LernCloudOff()
    {
        lerningCloud.SetActive(false);
    }

    //переключение на Мальчика без возможности поменять назад
    public void ChangePersonCantChangeBack()
    {
        _girlMovement.BoyActive();
        _girlMovement.CantChange = true;
    }
    //Переключение на девочку
    public void ChangePersonToGirl()
    {
        _girlMovement.GirlActive();
    }

    //Включение возможности менять персонажа
    public void ChangePersonBack()
    {
        _girlMovement.CantChange = false;
    }

    //Выключает возможности менять персонажа
    public void CantChangePerson()
    {
        _girlMovement.CantChange = true;
    }

    //Ивент для толкания(Пятнашки)
    public void PushBoxEventStart()
    {
        _girlMovement.GirlStopMovement();
        _girlMovement.CantChange = true;
        _girlMovement._BoyEvent.BoyLockOn();
    }

    //Ивент для толкания(Пятнашки)
    public void PushBoxEventEnd()
    {
        _girlMovement.GirlStartMovement();
        _girlMovement.CantChange = false;
        _girlMovement._BoyEvent.BoyLockOff();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Event")
        {
            eventOn_class = other.GetComponent<EventOn_Class>();
            SetEventsInfo();
        }
        if (other.tag == "SavePoint")
        {
            curentSavePosition = other.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Event")
        {

        }
    }
}
