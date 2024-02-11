using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyEvents : MonoBehaviour
{
    private BoyMovement _boyMovement;

    /// Переработать для обучения
    private GameObject lerningCloud;
    /// </summary>
     
    private EventOn_Class eventOn_class;
    private GameObject comixCloud;

    //Отмечает пройденные ивенты
    private bool[] eventAdd;
    public bool[] EventAdd { get { return eventAdd; } set { eventAdd = value; } }
    //Индекс исполняемого ивента
    private int eventIndex;
    public int EventIndex { get { return eventIndex; } set { eventIndex = value; } }
    //Спрайт в облаке
    private GameObject eventSprite;
    //Спрайты для облака комикса
    public Sprite[] spriteEventSprite;
    //Позиция респавна
    private Vector3 curentSavePosition;
    public Vector3 CurentSavePosition { get { return curentSavePosition; } set { curentSavePosition = value; } }
    private GameObject blackScreen;
    private bool boyDance;
    public bool BoyDance { get { return boyDance; } set { boyDance = value; } }

    private bool eventOffOn;
    public bool EventOffOn { get { return eventOffOn; } set { eventOffOn = value; } }
    private bool boyDead;
    public bool BoyDead { get { return boyDead; } set { boyDead = value; } }

    private void Awake()
    {
        _boyMovement = gameObject.GetComponent<BoyMovement>();
    }


    // Start is called before the first frame update
    void Start()
    {
        eventAdd = new bool[10];
        //Референс на облочко комикса
        comixCloud = transform.Find("ComixClouds").gameObject;
        eventSprite = transform.Find("Sprite_01").gameObject;
        lerningCloud = transform.Find("LernCloud").gameObject;
        //Референс на девочку и ее ивент
        //MicleJDance();

        comixCloud.SetActive(false);
    }

    private void Update()
    {
        if(boyDance == true)
        {
            if(_boyMovement.HorizontalOrientation == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), 1f * Time.deltaTime);
            }
            else if (_boyMovement.HorizontalOrientation == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), 1f * Time.deltaTime);
            }
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
        //Ивент машина
        switch (eventIndex)
        {
            case 0:

                break;
            case 1:
                if (eventAdd[1] == false)
                {
                    Event_01();
                }
                break;
            case 3:

                break;
            case 4:

                break;
        }
    }

    //Анимация майкл джексон
    public void MicleJDance()
    {
        _boyMovement._BoyAnimator.SetBool("isMoon", true);
        boyDance = true;
    }


    //Подходит к немцу и останавливается переключается управление на девочку
    public void Event_01()
    {
        _boyMovement._GirlEvents.Event_01();
        _boyMovement._BoyAnimator.SetBool("isHandUp", true);
        _boyMovement.CantChange = false;
        _boyMovement.CantWalkRight = true;
        _boyMovement.CantWalkLeft = true;
        _boyMovement.MoveAnimationStateMashine = 0;
        _boyMovement.AnimationStateMashine();
        lerningCloud.SetActive(true);
        Invoke("Event_02", 3);
    }
    //Первая сцена
    //Девочка спотыкается об камень и останавлявается
    //Запускается мульт картинка и включается передвижение мальчика
    public void Event_02()
    {
        eventAdd[1] = true;
        //ChangePersonCantChangeBack();
        _boyMovement.CantWalkLeft = false;
        lerningCloud.SetActive(false);
        _boyMovement._BoyAnimator.SetBool("isHandUp", false);
    }
    public void event_02End()
    {
        _boyMovement.CantChange = false;
        _boyMovement.GirlActive();
    }
    //Девочка прибегает после мышки
    public void Event_06()
    {
        _boyMovement.BoyActive();
        _boyMovement.CantWalkRight = false;
        _boyMovement.CantWalkLeft = false;
    }
    //Завершение ивета _06
    public void Event_06End()
    {
        _boyMovement._BoyAnimator.SetBool("isFut", true);
        _boyMovement.CantChange = false;
        _boyMovement._GirlMovement.CantChange = false;
    }

    //изменение персонажа без возможности поменять назад
    public void ChangePersonCantChangeBack()
    {
        _boyMovement.BoyActive();
        _boyMovement.CantChange = true;
    }

    //Включение возможности менять персонажа
    public void ChangePersonBack()
    {
        _boyMovement.CantChange = false;
    }

    //Смерть пацана, запускается черный экран и пацан телепортируется
    public void BoyDieEvent()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BScreen");
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", true);
        _boyMovement.CantWalkRight = true;
        _boyMovement.CantWalkLeft = true;
        yield return new WaitForSeconds(1f);
        this.transform.position = curentSavePosition;
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Animator>().SetBool("isBlackScreen", false);
        yield return new WaitForSeconds(0.5f);
        _boyMovement.CantWalkRight = false;
        _boyMovement.CantWalkLeft = false;
        boyDead = false;
    }

    //Включает облачко с необходимым предметом
    public void SpriteEventOn()
    {
        comixCloud.SetActive(true);
        eventSprite.SetActive(true);
        eventSprite.GetComponent<SpriteRenderer>().sprite = spriteEventSprite[eventIndex];
        Invoke("EndSpriteEvent", 3);
    }

    //Убирает Облако с нужным предметом
    public void EndSpriteEvent()
    {
        eventSprite.SetActive(false);
        comixCloud.SetActive(false);
        eventSprite.GetComponent<SpriteRenderer>().sprite = null;
    }
    
    //Режим взлома
    public void BoyLockOn()
    {
        _boyMovement.CantChange = true;
    }
    //Режим взлома
    public void BoyLockOff()
    {
        _boyMovement.CantChange = false;
    }
    //Ивент для толкания(Пятнашки)
    public void PushBoxEventStart()
    {
        _boyMovement.CantWalkRight = true;
        _boyMovement.CantWalkLeft = true;
        _boyMovement.CantChange = true;
        _boyMovement._GirlEvents.CantChangePerson();       
    }
    //Ивент для толкания(Пятнашки)
    public void PushBoxEventEnd()
    {
        _boyMovement.CantWalkRight = false;
        _boyMovement.CantWalkLeft = false;
        _boyMovement.CantChange = false;
        //_boyMovement._GirlEvents.ChangePersonBack();
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
