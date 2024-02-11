using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyThrow : MonoBehaviour
{
    private BoyMovement _boyMovement;

    //Префаб траектории
    private GameObject[] points;

    //Массив обхектов в руке
    public GameObject[] itemsInHand;
    //Массив объектов вылетающих из руки
    public GameObject[] throwItemsInHand;
    public GameObject useItemInHand;
    //Отображение Предмета в руке
    public SpriteRenderer throwItemInHand;
    //Спрайт предмета в руке
    private Sprite spriteItemInHand;
    public Sprite SpriteItemInHand { get { return spriteItemInHand; } set { spriteItemInHand = value; } }
    //Индекс поднимемого в руку предмета
    private int throwItemIndex;
    public int ThrowItemIndex { get { return throwItemIndex; } set { throwItemIndex = value; } }
    //Имя поднимаемого в руку предмета
    private string throwItemName;
    public string ThrowItemName { get { return throwItemName; } set { throwItemName = value; } }

    //Есть ли в руке предмет?
    private bool isItemInHand;
    public bool IsItemInHand { get { return isItemInHand; } set { isItemInHand = value; } }
    //Стойка приготовления к броску
    private bool isReadyToThrow;
    public bool IsReadyToThrow { get { return isReadyToThrow; } set { isReadyToThrow = value; } }
    //Патроны на рогатку
    private int amountRockAmmo;
    public int AmountRockAmmo { get { return amountRockAmmo; } set { amountRockAmmo = value; } }
    //Может ли поднимать после броска или выстрела
    private bool isReadyToPickUp;
    public bool IsReadyToPickUp { get { return isReadyToPickUp; } set { isReadyToPickUp = value; } }
    //Может ли стрелять при наличии патронов
    private bool isCanShot;
    public bool IsCanShot { get { return isCanShot; } set { isCanShot = value; } }

    public GameObject rockAmmo;
    private bool isReadyToSlingshot;
    public bool IsReadyToSlingshot { get { return isReadyToSlingshot; } set { isReadyToSlingshot = value; } }

    //private CharactersMovement characterMovement;
    //private BoyMovement boyMovement;

    private Vector2 direction;
    private Vector2 bowPosition;
    private Vector2 moPosition;
    private GameObject throwHand;
    private GameObject throwPointPosition;
    public GameObject point;
    public Transform shotPoint;
    private int numberOfPoints;
    private float spaceBetweenPoints;
    private int launchForse = 10;
    private bool isPositionPoint;

    private void Awake()
    {
        _boyMovement = gameObject.GetComponent<BoyMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        amountRockAmmo = 0;
        numberOfPoints = 6;
        spaceBetweenPoints = 0.35f;
        throwHand = transform.Find("BowPosition").gameObject;
        throwPointPosition = transform.Find("ThrowPoint").gameObject;       
    }

    // Update is called once per frame
    void Update()
    {
        if(_boyMovement.ChangeActivePerson == 1)
        {
            ReadyToThrowItemInHand();
            //Изменение траектории броска
            //ChangeThrowingTrajectory();
            //Бросок
            TrowItem();

            //Простраивает траекторию броска
            if (isReadyToThrow == true || isReadyToSlingshot == true)
            {
                bowPosition = throwHand.transform.position;
                moPosition = throwPointPosition.transform.position;
                direction = moPosition - bowPosition;
                throwHand.transform.right = direction;

                if(isReadyToSlingshot == true)
                {
                    //Стартовая позиция точек
                    if(isPositionPoint == false)
                    {
                        //количество точек траектории
                        numberOfPoints = 6;
                        //растояние между точками траектории
                        spaceBetweenPoints = 0.1f;
                        //Стартовая траектория
                        throwPointPosition.transform.localPosition = new Vector3(46f, 36.5f, 0f);  
                        isPositionPoint = true;
                        launchForse = 20;
                    }              
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        points[i].transform.position = PointPosition2(i * spaceBetweenPoints);
                    }
                }
                else if (isReadyToThrow == true)
                {
                    //Стартовая позиция точек
                    if (isPositionPoint == false)
                    {
                        //количество точек траектории
                        numberOfPoints = 6;
                        //растояние между точками траектории
                        spaceBetweenPoints = 0.35f;
                        //Стартовая траектория
                        throwPointPosition.transform.localPosition = new Vector3(25f, 50f, 0f);
                        isPositionPoint = true;
                        launchForse = 10;
                    }
                   
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                    }
                }
            }

            //Изменение траектории броска
            ChangeThrowingTrajectory();
        }
        
    }

    //Приготовление к броску
    private void ReadyToThrowItemInHand()
    {
        //РОГАТКА
        //Если нажата кнопка, если есть патроны, если рогатка не нажата, если не двигает ящики
        if(Input.GetButtonDown("Throw") && amountRockAmmo > 0 && isItemInHand == false && isCanShot == false && isReadyToSlingshot == false && _boyMovement.IsPushBoxOn == false)
        {
            isReadyToPickUp = true;
            isReadyToSlingshot = true;
            ThrowingTrajectory();
            _boyMovement._BoyAnimator.SetInteger("SlingShot", 1);
            useItemInHand.SetActive(false);
            //Меняет точку спавна предмета в зависимости от поворота персонажа
            if (_boyMovement.HorizontalOrientation == 0)
            {
                shotPoint.transform.localPosition = new Vector3(6.85f, -1.5f, 0f);
            }
            else if (_boyMovement.HorizontalOrientation == 1)
            {
                shotPoint.transform.localPosition = new Vector3(6.85f, 2.9f, 0f);
            }
        }
        //БРОСОК ПРЕДМЕТА
        //Если нажата кнопка, если есть предмет в руках, если нет патроны, если предмет не прожат, если не двигает ящики
        else if (Input.GetButtonDown("Throw") && isItemInHand == true && isCanShot == false && isReadyToThrow == false  && _boyMovement.IsPushBoxOn == false)
        {
            isReadyToPickUp = true;
            isReadyToThrow = true;
            ThrowingTrajectory();
            _boyMovement._BoyAnimator.SetInteger("ThrowState", 1);
            throwItemInHand.sprite = SpriteItemInHand;
            //Меняет точку спавна предмета в зависимости от поворота персонажа
            if (_boyMovement.HorizontalOrientation == 0)
            {
                shotPoint.transform.localPosition = new Vector3(1.1f, 3.5f, 0);
            }
            else if (_boyMovement.HorizontalOrientation == 1)
            {
                shotPoint.transform.localPosition = new Vector3(1.6f, -4.2f, 0);
            }
        }
        else if (Input.GetButtonUp("Throw") && isReadyToSlingshot == true)
        {
            isPositionPoint = false;
            isReadyToPickUp = false;
            isReadyToSlingshot = false;
            DestroyThrowingTrajectoryPoints();
            _boyMovement._BoyAnimator.SetInteger("SlingShot", 0);
            useItemInHand.SetActive(true);
        }
        else if (Input.GetButtonUp("Throw") && isReadyToThrow == true)
        {
            isPositionPoint = false;
            isReadyToPickUp = false;
            isReadyToThrow = false;
            DestroyThrowingTrajectoryPoints();
            _boyMovement._BoyAnimator.SetInteger("ThrowState", 0);
            throwItemInHand.sprite = null;
        }
    }


    //Создает точки для траеткории броска
    private void ThrowingTrajectory()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    //Удаление точек
    private void DestroyThrowingTrajectoryPoints()
    {
        throwPointPosition.transform.localPosition = new Vector3(25f, 50f, 0f);
        GameObject[] trajectoryPoints = GameObject.FindGameObjectsWithTag("TrajectoryPoint");
        foreach (GameObject trajectoryPoint in trajectoryPoints)
            GameObject.Destroy(trajectoryPoint);
    }

    //Изменение траектории броска
    private void ChangeThrowingTrajectory()
    {
        if (isReadyToThrow == true || isReadyToSlingshot == true)
        {
            if (Input.GetAxisRaw("Vertical") < 0f && _boyMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x < 45)
            {
                throwPointPosition.transform.localPosition += new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0f && _boyMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > -40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0f && _boyMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x < 45 && throwPointPosition.transform.localPosition.x > 0)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _boyMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y < 40)
            {
                throwPointPosition.transform.localPosition += new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _boyMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > 40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetAxisRaw("Vertical") < 0f && _boyMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x < 45)
            {
                throwPointPosition.transform.localPosition += new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0f && _boyMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > -40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0f && _boyMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x < 45 && throwPointPosition.transform.localPosition.x > 0)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _boyMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y < 40)
            {
                throwPointPosition.transform.localPosition += new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _boyMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > 40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
        }
        else if (isReadyToThrow == false)
        {

        }
    }

    private void TrowItem()
    {
        if(Input.GetButtonDown("Interaction") && isReadyToSlingshot == true)
        {
            //Спавн предмета
            GameObject newRockAmmo = Instantiate(rockAmmo, shotPoint.position, shotPoint.rotation);
            newRockAmmo.GetComponent<Rigidbody2D>().velocity = throwHand.transform.right * launchForse;

            _boyMovement._BoyAnimator.SetInteger("SlingShot", 2);
            isReadyToSlingshot = false;
            isPositionPoint = false;
            amountRockAmmo -= 1;

            //Удаление точек
            DestroyThrowingTrajectoryPoints();

            Invoke("DelayOnSlingShot", 1f);
        }
        else if (Input.GetButtonDown("Interaction") && isReadyToThrow == true)
        {
            //Спавн предмета
            GameObject newArrow = Instantiate(throwItemsInHand[ThrowItemIndex], shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = throwHand.transform.right * launchForse;

            //Удаление точек
            DestroyThrowingTrajectoryPoints();

            //Включение возможности идти, предмет в руках, готов к броску = false
            _boyMovement._BoyAnimator.SetInteger("ThrowState", 2);
            IsItemInHand = isReadyToThrow = false;
            isPositionPoint = false;
            throwItemInHand.sprite = null;

            SpriteItemInHand = null;
            ThrowItemIndex = 0;
            ThrowItemName = null;

            Invoke("DelayOnSlingShot", 1f);
        }
    }

    private void DelayOnSlingShot()
    {
        isReadyToPickUp = false;
    }

    Vector2 PointPosition2(float t)
    {
        //Vector2 position = (Vector2)shotPoint.position + throwHand2 * Physics2D.gravity * (t + t);
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForse * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    Vector2 PointPosition(float t)
    {
        //Vector2 position = (Vector2)shotPoint.position + throwHand2 * Physics2D.gravity * (t + t);
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForse * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
