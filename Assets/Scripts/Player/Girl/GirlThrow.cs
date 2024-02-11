using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlThrow : MonoBehaviour
{
    private GirlMovement _girlMovement;

    //Префаб траектории
    private GameObject[] points;
    //Массив обхектов в руке
    public GameObject[] itemsInHand;
    //Массив объектов вылетающих из руки
    public GameObject[] throwItemsInHand;

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
    public bool isReadyToThrow;
    //Может ли поднимать после броска или выстрела
    private bool isReadyToPickUp;
    public bool IsReadyToPickUp { get { return isReadyToPickUp; } set { isReadyToPickUp = value; } }

    //private CharactersMovement characterMovement;

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

    private void Awake()
    {
        _girlMovement = gameObject.GetComponent<GirlMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfPoints = 6;
        spaceBetweenPoints = 0.35f;
        throwHand = transform.Find("BowPosition").gameObject;
        throwPointPosition = transform.Find("ThrowPoint").gameObject;
        //characterMovement = GetComponent<CharactersMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_girlMovement.HorizontalOrientation);
        if(_girlMovement.ChangeActivePerson == 0)
        {
            ReadyToThrowItemInHand();
            //Изменение траектории броска
            //ChangeThrowingTrajectory();
            //Бросок
            TrowItem();

            //Простраивает траекторию броска
            if (isReadyToThrow == true)
            {
                bowPosition = throwHand.transform.position;
                moPosition = throwPointPosition.transform.position;
                direction = moPosition - bowPosition;
                throwHand.transform.right = direction;

                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                }
            }

            //Изменение траектории броска
            ChangeThrowingTrajectory();
        }       
    }

    //Приготовление к броску
    private void ReadyToThrowItemInHand()
    {
        if (Input.GetButtonDown("Throw") && isItemInHand == true && isReadyToThrow == false && gameObject.GetComponent<GirlMovement>().IsCry == false)
        {          
            isReadyToThrow = true;
            isReadyToPickUp = true;
            ThrowingTrajectory();
            _girlMovement._GirlAnimator.SetInteger("ThrowState", 1);
            throwItemInHand.sprite = SpriteItemInHand;
            //Меняет точку спавна предмета в зависимости от поворота персонажа
            if (_girlMovement.HorizontalOrientation == 0)
            {
                shotPoint.transform.localPosition = new Vector3(1.1f, 3.5f, 0);
            }
            else if (_girlMovement.HorizontalOrientation == 1)
            {
                shotPoint.transform.localPosition = new Vector3(1.6f, -4.2f, 0);
            }
        }
        else if (Input.GetButtonUp("Throw") && isReadyToThrow == true)
        {
            isReadyToThrow = false;
            isReadyToPickUp = false;
            DestroyThrowingTrajectoryPoints();
            _girlMovement._GirlAnimator.SetInteger("ThrowState", 0);
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
        if (isReadyToThrow == true)
        {
            if (Input.GetAxisRaw("Vertical") > 0f && _girlMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x < 45)
            {
                throwPointPosition.transform.localPosition += new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _girlMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > -40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            if (Input.GetAxisRaw("Vertical") < 0f && _girlMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x < 45 && throwPointPosition.transform.localPosition.x > 0)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0f && _girlMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y < 40)
            {
                throwPointPosition.transform.localPosition += new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0f && _girlMovement.HorizontalOrientation == 0 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > 40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetAxisRaw("Vertical") < 0f && _girlMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x < 45)
            {
                throwPointPosition.transform.localPosition += new Vector3(50 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0f && _girlMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > -40)
            {
                throwPointPosition.transform.localPosition -= new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0f && _girlMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x < 45 && throwPointPosition.transform.localPosition.x > 0)
            {
                throwPointPosition.transform.localPosition -= new Vector3(50 * Time.deltaTime, 0f, 0f); 
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _girlMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y < 40)
            {
                throwPointPosition.transform.localPosition += new Vector3(0f, 60 * Time.deltaTime, 0f);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && _girlMovement.HorizontalOrientation == 1 && throwPointPosition.transform.localPosition.x > 45 && throwPointPosition.transform.localPosition.y > 40)
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
        if (Input.GetButtonDown("Interaction") && isReadyToThrow == true)
        {
            //Спавн предмета
            GameObject newArrow = Instantiate(throwItemsInHand[ThrowItemIndex], shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = throwHand.transform.right * launchForse;

            //Удаление точек
            DestroyThrowingTrajectoryPoints();

            //Включение возможности идти, предмет в руках, готов к броску = false
            _girlMovement._GirlAnimator.SetInteger("ThrowState", 2);
            IsItemInHand = isReadyToThrow = false;
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

    Vector2 PointPosition(float t)
    {
        //Vector2 position = (Vector2)shotPoint.position + throwHand2 * Physics2D.gravity * (t + t);
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForse * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
