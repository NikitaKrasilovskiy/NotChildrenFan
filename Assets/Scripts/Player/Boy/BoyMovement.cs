using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyMovement : CharactersMovement
{
    //Референсы на девочку
    [SerializeField] private GameObject girlRef;
    private GirlMovement _girlMovement;
    public GirlMovement _GirlMovement { get { return _girlMovement; } set { _girlMovement = value; } }
    private GirlEvents _girlEvents;
    public GirlEvents _GirlEvents { get { return _girlEvents; } set { _girlEvents = value; } }
    private GirlUsebleItems _girlUsebleItems;
    public GirlUsebleItems _GirlUsebleItems { get { return _girlUsebleItems; } set { _girlUsebleItems = value; } }

    private Animator _boyAnimator;
    public Animator _BoyAnimator { get { return _boyAnimator; } set { _boyAnimator = value; } }


    private PushObj pushObj;
    private Rigidbody2D boxRigidbody;
    private float boxSpeed;
    //Камера лестница
    private GameObject cameraTarget;
    private bool ladderCameraUp;
    public bool LadderCameraUp { get { return ladderCameraUp; } set { ladderCameraUp = value; } }
    private bool ladderCameraDown;
    public bool LadderCameraDown { get { return ladderCameraDown; } set { ladderCameraDown = value; } }
    private Vector3 camTarCorrentTransform;
    private Vector3 cameraUpLadder;
    private Vector3 cameraDownLadder;
    //Катушка
    public GameObject katushkaHand;
    //Авто хождение
    private bool boyGoToGirl;
    public bool BoyGoToGirl { get { return boyGoToGirl; } set { boyGoToGirl = value; } }
    private bool isCanGirlCall;
    public bool IsCanGirlCall { get { return isCanGirlCall; } set { isCanGirlCall = value; } }
    private float boyPositionToGirl;
    public float BoyPositionToGirl { get { return boyPositionToGirl; } set { boyPositionToGirl = value; } }
    private bool controlRot;
    public bool ControlRot { get { return controlRot; } set { controlRot = value; } }

    private float distanceBetweenBoyGirl;

    private void Awake()
    {
        _girlMovement = girlRef.GetComponent<GirlMovement>();
        _girlEvents = girlRef.GetComponent<GirlEvents>();
        _boyAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    public override void Start()
    {
        base.Start();
        walkSpeed = 3.5f;
        runSpeed = 5.5f;
        boxSpeed = 2.5f;
        cameraTarget = transform.Find("CameraTarget").gameObject;
        camTarCorrentTransform = new Vector3(-3, 56.8f, 0);
        cameraUpLadder = new Vector3(-3, 82f, 0);
        cameraDownLadder = new Vector3(-3, 36, 0);
    }

    public override void Update()  
    {
        DEVCHANGELVL();
        ChangeChar();

        if(ChangeActivePerson == 0)
        {
            if (boyGoToGirl == true && gameObject.transform.position.x != boyPositionToGirl)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(boyPositionToGirl, transform.position.y, transform.position.z), 3f * Time.deltaTime);
                characterAnimator.SetInteger("ScaneMoveState", 2);
            }
            else if (boyGoToGirl == true && gameObject.transform.position.x == boyPositionToGirl)
            {
                CallBoyStop();
            }
            else if (boyGoToGirl == false && controlRot == false)
            {
                ChangeRotationToCharacter();
            }
        }
     
        if (ChangeActivePerson == 1)
        {
            base.PlayerHorizontalMovement();
            base.PlayerVerticalMovement();
            base.Run();
            MoveBox();
            CallGirl();

            Physics2D.IgnoreLayerCollision(10, 11);
            Physics2D.IgnoreLayerCollision(10, 12);
            Physics2D.IgnoreLayerCollision(10, 13);

            //Если во время призыва выбрать персонажа
            if (boyGoToGirl == true)
            {
                CallBoyStop();
            }
        }

        //Перемещение камеры во время лестницы
        CameraLadderUp();
        CameraLadderDown();
        Pushing();
    }

    public void DEVCHANGELVL()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene("2_Demo");
        }
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene("3_Demo");
        }
        if (Input.GetKey(KeyCode.F3))
        {
            SceneManager.LoadScene("4_Demo");
        }
        if (Input.GetKey(KeyCode.F4))
        {
            SceneManager.LoadScene("5_Demo");
        }
        if (Input.GetKey(KeyCode.F5))
        {
            SceneManager.LoadScene("6_Demo");
        }
    }

    private void CallGirl()
    {
        if(Input.GetButtonDown("Call") && isCanGirlCall == true && IsPushBoxOn == false)
        {
            distanceBetweenBoyGirl = Vector3.Distance(transform.position, girlRef.transform.position);
            //Debug.DrawLine(transform.position, girlRef.transform.position, Color.green);           

            if (distanceBetweenBoyGirl > 10)
            {                
                if (girlRef.transform.position.x > transform.position.x)
                {
                    gameObject.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    characterAnimator.SetBool("isCallGirl", true);
                    girlRef.gameObject.transform.position = new Vector3(transform.position.x + 11, transform.position.y, transform.position.z);
                    girlRef.gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                    _girlMovement.GirlPositionToBoy = gameObject.transform.position.x;
                    _girlMovement.GirlGoToBoy = true;
                }
                else if (girlRef.transform.position.x < transform.position.x)
                {
                    gameObject.gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                    characterAnimator.SetBool("isCallGirl", true);
                    girlRef.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    girlRef.gameObject.transform.position = new Vector3(transform.position.x - 11, transform.position.y, transform.position.z);
                    _girlMovement.GirlPositionToBoy = gameObject.transform.position.x;
                    _girlMovement.GirlGoToBoy = true;
                }
            }
            else if(distanceBetweenBoyGirl > 10 || distanceBetweenBoyGirl == 10)
            {

            }
        }
        else if(Input.GetButtonDown("Call") && isCanGirlCall == false && IsPushBoxOn == false)
        {

        }
    }

    private void CallBoyStop()
    {
        boyGoToGirl = false;
        boyPositionToGirl = gameObject.transform.position.x;
        _boyAnimator.SetInteger("ScaneMoveState", 0);
    }


    public void KatushkaMove()
    {
        walkSpeed = 3f;
        isKatushkaMove = true;
        katushkaHand.SetActive(true);
        _boyAnimator.SetInteger("KatushkaState", 1);
    }

    //Поворот в сторону персонажа
    private void ChangeRotationToCharacter()
    {
        if (girlRef.transform.position.x > transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (girlRef.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    //Передвижение коробки
    public void MoveBox()
    {
        if(pushObj != null)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            if (horizontalMove > 0f)
            {
                if(pushState == 2)
                {
                    boxRigidbody.velocity = new Vector3(boxSpeed, boxRigidbody.velocity.y, 0f) * horizontalMove;
                }
            }

            else if (horizontalMove < 0f)
            {
                if (pushState == 1)
                {
                    boxRigidbody.velocity = new Vector3(-moveSpeed, boxRigidbody.velocity.y, 0f) * -horizontalMove;
                }
            }

            else
            {
                boxRigidbody.velocity = new Vector3(0, boxRigidbody.velocity.y, 0f);
            }
        }
    }

    private bool pushingOnOg;

    //Толкание
    private void Pushing()
    {

        //Встал в позу толкания
        if (Input.GetButtonDown("Crounch") && isPushBoxOn == false && ChangeActivePerson == 1 && horizontalMove == 0)
        {
            if (pushState == 1 || pushState == 2)
            {
                _boyAnimator.SetInteger("PushState", 1);
                isPushBoxOn = true;
                pushingOnOg = true;
                controlRot = true;
            }
        }

        //Вышел из позы толкания
        else if (Input.GetButtonDown("Crounch") && isPushBoxOn == true && ChangeActivePerson == 1)
        {
            _boyAnimator.SetInteger("PushState", 0);

            if (horizontalMove > 0f && isRun == false || horizontalMove < 0f && isRun == false)
            {
                moveAnimationStateMashine = 1;
                _boyAnimator.SetInteger("IdleWalkState", 1);               
            }
            else if (horizontalMove > 0f && isRun == true || horizontalMove < 0f && isRun == true)
            {
                _boyAnimator.SetBool("isRun", true);
                _boyAnimator.SetInteger("IdleWalkState", 2);
                _boyAnimator.SetBool("isRun", true);              
            }
            else if (horizontalMove == 0f)
            {
                _boyAnimator.SetBool("isWalk", false);
                _boyAnimator.SetInteger("IdleWalkState", 0);               
            }

            _boyAnimator.SetInteger("PushState", 0);
            CantWalk = false;
            FreezePushBox();
            isPushBoxOn = false;
            controlRot = false;
        }
    }

    //Вышел из позы толкания dсле ивента с коробкой
    public void PushBoxExit()
    {
        isPushBoxOn = false;
        _boyAnimator.SetInteger("PushState", 0);

        if (horizontalMove > 0f && isRun == false || horizontalMove < 0f && isRun == false)
        {
            moveAnimationStateMashine = 1;
            _boyAnimator.SetInteger("IdleWalkState", 1);          
        }
        else if (horizontalMove > 0f && isRun == true || horizontalMove < 0f && isRun == true)
        {
            moveAnimationStateMashine = 2;
            _boyAnimator.SetBool("isRun", true);           
        }
        else if (horizontalMove == 0f)
        {
            //moveAnimationStateMashine = 1;
            _boyAnimator.SetBool("isWalk", false);
            _boyAnimator.SetInteger("IdleWalkState", 0);         
        }

        CantWalk = false;
        FreezePushBox();
    }

    public void PullBox()
    {
 
    }

    public void UnfreezePushObject()
    {
        boxRigidbody.constraints = RigidbodyConstraints2D.None;
        boxRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void FreezePushBox()
    {
        boxRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    

    //Запертые двери
    public void TryClouseDoor()
    {
        _boyAnimator.SetBool("isOpenCar", true);
    }

    //Камера стандарт
    public void CameraStandart()
    {
        cameraTarget.transform.localPosition = camTarCorrentTransform;
    }

    //Камера лестница вверх
    public void CameraLadderUp()
    {
        if(ladderCameraUp == true)
        {
            cameraTarget.transform.localPosition = Vector3.Lerp(cameraTarget.transform.localPosition, cameraUpLadder, 1.5f * Time.deltaTime);
        }
    }

    //Камера лестница вниз
    public void CameraLadderDown()
    {
        if (ladderCameraDown == true)
        {
            cameraTarget.transform.localPosition = Vector3.Lerp(cameraTarget.transform.localPosition, cameraDownLadder, 1.5f * Time.deltaTime);
        }
    }

    public void ChangeChar()
    {
        if (Input.GetButtonDown("ChangeCharacter") && changeActivePerson == 0 && CantChange == false)
        {
            if (horizontalMove > 0 || horizontalMove < 0)
            {
                if (isRun == false)
                {
                    _boyAnimator.SetInteger("IdleWalkState", 1);
                    _boyAnimator.SetBool("isWalk", true);
                }
                else if (isRun == true)
                {
                    _boyAnimator.SetBool("isRun", true);
                    _boyAnimator.SetInteger("IdleWalkState", 2);
                }
            }
            BoyActive();
        }
        else if (Input.GetButtonDown("ChangeCharacter") && changeActivePerson == 1 && CantChange == false)
        {
            _boyAnimator.SetInteger("IdleWalkState", 0);
            _boyAnimator.SetBool("isWalk", false);
            GirlActive();
        }
    }

    //Блокирует передвижение пацана
    public void BoyStopMovement()
    {
        CantWalkRight = true;
        CantWalkLeft = true;
    }

    //Возобновляет Движение пацана
    public void BoyStartMovement()
    {
        CantWalkRight = false;
        CantWalkLeft = false;
    }

    public void GirlActive()
    {
        ChangeActivePerson = 0;
    }
    public void BoyActive()
    {
        ChangeActivePerson = 1;
    }


    //Триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        //Хватается за ящик
        if (other.tag == "PushBox" || other.tag == "ClimbPushBox")
        {          
            pushObj = other.GetComponent<PushObj>();
            boxRigidbody = other.GetComponent<Rigidbody2D>();
            climbState = 1;
            CallBoyStop();
        }
        //Определяет с какой стороны подход
        if (other.tag == "ClimbBoxOff")
        {
            if(HorizontalOrientation == 0)
            {
                pushState = 1;
                //Debug.Log("слевой стороны");
            }
            else if(HorizontalOrientation == 1)
            {
                pushState = 2;
                //Debug.Log("справой стороны");
            }
        }
        //Блокирует движение и анимацию в нужную сторону
        if (other.tag == "MoveBlock")
        {
            if (other != null && other.GetComponent<BlockMoveRightLeft>().rightLeftBlock == false)
            {
                CantWalkRight = true;
            }
            else if (other != null && other.GetComponent<BlockMoveRightLeft>().rightLeftBlock == true)
            {
                CantWalkLeft = true;
            }
        }
        //Лестница
        if (other.tag == "Ladder")
        {
            climbState = 2;
            laddersLeftRight = other.gameObject.GetComponent<Ladders>().leftRightLadder;
            ladderPosition = other.gameObject.transform.position;
            ladders = other.gameObject.GetComponent<Ladders>();
        }
        //Лестница
        if (other.tag == "LadderDown")
        {
            climbState = 3;
            laddersLeftRight = other.gameObject.GetComponentInParent<Ladders>().leftRightLadder;
            ladderPosition = other.gameObject.transform.position;
            ladders = other.gameObject.GetComponentInParent<Ladders>();
        }
        if (other.tag == "Player" )
        {
            if(boyGoToGirl == true)
            {
                CallBoyStop();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Отойти от ящика
        if (other.tag == "PushBox" || other.tag == "ClimbPushBox")
        {
            pushObj = null;
            boxRigidbody = null;
            pushState = 0;
            climbState = 0;
        }
        //Разблокирует движение и анимацию в нужную сторону
        if (other.tag == "MoveBlock")
        {
            if (other != null && other.GetComponent<BlockMoveRightLeft>().rightLeftBlock == false)
            {
                CantWalkRight = false;
            }
            else if (other != null && other.GetComponent<BlockMoveRightLeft>().rightLeftBlock == true)
            {
                CantWalkLeft = false;
            }
        }
        if (other.tag == "Ladder")
        {
            climbState = 0;
        }
        if (other.tag == "LadderDown")
        {
            climbState = 0;
        }
    }

}
