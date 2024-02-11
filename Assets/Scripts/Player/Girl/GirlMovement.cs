using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : CharactersMovement
{
    [SerializeField] private GameObject boyRef;
    private BoyMovement _boyMovement;
    public BoyMovement _BoyMovement { get { return _boyMovement; } set { _boyMovement = value; } }
    private BoyEvents _boyEvent;
    public BoyEvents _BoyEvent { get { return _boyEvent; } set { _boyEvent = value; } }
    private BoyUsebleItems _boyUsebleItems;
    public BoyUsebleItems _BoyUsebleItems { get { return _boyUsebleItems; } set { _boyUsebleItems = value; } }

    private Animator _girlAnimator;
    public Animator _GirlAnimator { get { return _girlAnimator; } set { _girlAnimator = value; } }


    //Приседание
    [Space]
    [Header("Приседание")]
    //Радиус проверки потолка над головой
    private float ceilingRadius;
    //физический компонент проверки потолка над головой
    private GameObject ceilingCheck;
    private GameObject interCheck;
    //СлойМаска определяющий что считать потолком
    private LayerMask whatIsCeiling;
    //Чекер может встать или неможет
    private bool canStandUp;
    //Референс на ящик
    private PushObj pushObj;
    //Камера лестница
    private GameObject cameraTarget;
    private bool ladderCameraUp;
    public bool LadderCameraUp { get { return ladderCameraUp; } set { ladderCameraUp = value; } }
    private bool ladderCameraDown;
    public bool LadderCameraDown { get { return ladderCameraDown; } set { ladderCameraDown = value; } }
    private Vector3 camTarCorrentTransform;
    private Vector3 cameraUpLadder;
    private Vector3 cameraDownLadder;


    //Авто хождение
    private bool girlGoToBoy;
    public bool GirlGoToBoy { get { return girlGoToBoy; } set { girlGoToBoy = value; } }
    private float girlPositionToBoy;
    public float GirlPositionToBoy { get { return girlPositionToBoy; } set { girlPositionToBoy = value; } }
    private bool isCanBoyCall;
    public bool IsCanBoyCall { get { return isCanBoyCall; } set { isCanBoyCall = value; } }
    private bool controlRot;
    public bool ControlRot { get { return controlRot; } set { controlRot = value; } }

    private float distanceBetweenBoyGirl;

    private void Awake()
    {
        _boyMovement = boyRef.GetComponent<BoyMovement>();
        _boyEvent = boyRef.GetComponent<BoyEvents>();
        _girlAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    public override void Start()
    {
        base.Start();
        //Назначает слойМаску - что считать потолком
        whatIsCeiling = LayerMask.GetMask("Ground");
        ceilingRadius = 0.25f;

        walkSpeed = 3.5f;
        runSpeed = 5.5f;
        crouchSpeed = 2.5f;
        crySpeed = 3f;

        //Назначает чекер проверки потолка
        ceilingCheck = transform.Find("СeilingCheck").gameObject;
        interCheck = transform.Find("CharactersInteraction").gameObject;

        cameraTarget = transform.Find("CameraTarget").gameObject;
        camTarCorrentTransform = new Vector3(-3, 56.8f, 0);
        cameraUpLadder = new Vector3(-3, 82f, 0);
        cameraDownLadder = new Vector3(-3, 36, 0);

        //GirlCryOn();
    }

    
    public override void Update()
    {
        //base.ChangeCharacter();
        ChangeChar();

        if (ChangeActivePerson == 1)
        {
            if (girlGoToBoy == true && gameObject.transform.position.x != girlPositionToBoy)
            {
                //если плачет
                if(IsCry == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(girlPositionToBoy, transform.position.y, transform.position.z), 3f * Time.deltaTime);
                    characterAnimator.SetInteger("ScaneMoveState", 2);
                }
                //если не плачет
                else if (IsCry == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(girlPositionToBoy, transform.position.y, transform.position.z), 1.5f * Time.deltaTime);
                    characterAnimator.SetInteger("ScaneMoveState", 4);
                }
            }
            else if (girlGoToBoy == true && gameObject.transform.position.x == girlPositionToBoy)
            {
                CallGirlStop();
            }

            else if(girlGoToBoy == false && controlRot == false)
            {
                ChangeRotationToCharacter();
            }
        }

        if (ChangeActivePerson == 0)
        {
            base.PlayerHorizontalMovement();
            base.PlayerVerticalMovement();
            base.Run();
            Crouch();
            CallBoy();

            if(girlGoToBoy == true)
            {
                CallGirlStop();
            }    

            //Если в присяде включает проверку потолка
            if (isCrouch == true)
            {
                CheckCeiling();
            }

            Physics2D.IgnoreLayerCollision(10, 11);
            Physics2D.IgnoreLayerCollision(10, 12);
            Physics2D.IgnoreLayerCollision(10, 13);
        }

        //Перемещение камеры во время лестницы
        CameraLadderUp();
        CameraLadderDown();
    }

    //Вызывает пацана
    private void CallBoy()
    {
        if (Input.GetButtonDown("Call") && isCanBoyCall == true && IsCrouch == false)
        {
            distanceBetweenBoyGirl = Vector3.Distance(transform.position, boyRef.transform.position);    

            if (distanceBetweenBoyGirl > 10)
            {
                if (boyRef.transform.position.x > transform.position.x)
                {
                    gameObject.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    _girlAnimator.SetBool("isCallGirl", true);
                    boyRef.gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                    boyRef.gameObject.transform.position = new Vector3(transform.position.x + 11, transform.position.y, transform.position.z);
                    _boyMovement.BoyPositionToGirl = gameObject.transform.position.x;
                    _boyMovement.BoyGoToGirl = true;
                }
                else if (boyRef.transform.position.x < transform.position.x)
                {
                    gameObject.gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                    _girlAnimator.SetBool("isCallGirl", true);
                    boyRef.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    boyRef.gameObject.transform.position = new Vector3(transform.position.x - 11, transform.position.y, transform.position.z);
                    _boyMovement.BoyPositionToGirl = gameObject.transform.position.x;
                    _boyMovement.BoyGoToGirl = true;
                }
            }
            else if (distanceBetweenBoyGirl > 10 || distanceBetweenBoyGirl == 10)
            {

            }
        }
        else if (Input.GetButtonDown("Call") && isCanBoyCall == false && IsPushBoxOn == false)
        {

        }
    }

    private void CallGirlStop()
    {
        girlGoToBoy = false;
        _girlAnimator.SetInteger("ScaneMoveState", 0);
        girlPositionToBoy = gameObject.transform.position.x;
    }

    public void DontCallBoyGirl()
    {
        isCanBoyCall = false;
        _boyMovement.IsCanGirlCall = false;
    }

    //Поворот в сторону персонажа
    private void ChangeRotationToCharacter()
    {
        if (boyRef.transform.position.x > transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (boyRef.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
    }


    //ПРИСЕДАНИЕ
    private void Crouch()
    {
        //Присел
        if (Input.GetButtonDown("Crounch") && isCrouch == false && canStandUp == false && ChangeActivePerson == 0 && IsCry == false)
        {
            //включает видимость чекера проверки потолка
            ceilingCheck.SetActive(true);
            //изменяет размер капсулколайдра
            capsuleCollision.offset = new Vector2(-0.6f, 7f);
            capsuleCollision.size = new Vector2(6f, 14f);
            interCheck.transform.localPosition = new Vector3(0, 9, 0);

            //Стейты изменения анимации приседания
            //Если стоит
            if (moveAnimationStateMashine == 0)
            {
                _girlAnimator.SetInteger("IdleWalkState", 3);
                _girlAnimator.SetBool("isCrouch", true);
                moveAnimationStateMashine = 3;
                moveSpeed = crouchSpeed;
            }
            //Если идет запускает анимацию передвижения в присяде
            else if (moveAnimationStateMashine == 1)
            {
                _girlAnimator.SetInteger("IdleWalkState", 4);
                _girlAnimator.SetBool("isCrouch", true);
                moveSpeed = crouchSpeed;
            }
            //Если бежит запускает анимацию передвижения в присяде
            else if (moveAnimationStateMashine == 2)
            {
                _girlAnimator.SetInteger("IdleWalkState", 4);
                _girlAnimator.SetBool("isCrouch", true);
                moveSpeed = crouchSpeed;
            }

            isCrouch = true;
        }

        //Встал
        else if (Input.GetButtonDown("Crounch") && isCrouch == true && canStandUp == false && ChangeActivePerson == 0)
        {
            //включает видимость чекера проверки потолка
            ceilingCheck.SetActive(false);
            interCheck.transform.localPosition = new Vector3(0, 11, 0);
            capsuleCollision.offset = new Vector2(-0.6f, 9f);
            capsuleCollision.size = new Vector2(6f, 18f);


            //Стейты изменения анимации приседания
            //Если стоит на месте и включен шаг          
            if (moveAnimationStateMashine == 3 && isRun == false)
            {
                _girlAnimator.SetBool("isCrouch", false);
                _girlAnimator.SetInteger("IdleWalkState", 0);
                moveAnimationStateMashine = 0;
                moveSpeed = walkSpeed;
            }
            //Если стоит на месте и включен бег
            else if (moveAnimationStateMashine == 3 && isRun == true)
            {
                _girlAnimator.SetBool("isCrouch", false);
                _girlAnimator.SetInteger("IdleWalkState", 0);
                moveAnimationStateMashine = 0;
                moveSpeed = runSpeed;
            }
            //Если двигается на присяде и включен шаг 
            else if (moveAnimationStateMashine == 4 && isRun == false)
            {
                _girlAnimator.SetInteger("IdleWalkState", 1);
                _girlAnimator.SetBool("isCrouch", false);
                moveSpeed = walkSpeed;
            }
            //Если двигается на присяде и включен бег
            else if (moveAnimationStateMashine == 4 && isRun == true)
            {
                _girlAnimator.SetBool("isCrouch", false);
                _girlAnimator.SetInteger("IdleWalkState", 2);
                moveAnimationStateMashine = 2;
                moveSpeed = runSpeed;
            }

            isCrouch = false;
        }
    }

    //Девочка Плачет Он
    public void GirlCryOn()
    {
        IsCry = true;
        isRun = false;
        isCanBoyCall = true;
        _girlAnimator.SetBool("isCry", true);
        moveSpeed = crySpeed;
    }

    //Девочка Плачет Офф
    public void GirlCryOff()
    {
        IsCry = false;
        isCanBoyCall = false;
        _girlAnimator.SetBool("isCry", false);
        moveSpeed = walkSpeed;
    }

    //Функция Проверка Потолка
    private void CheckCeiling()
    {
        if (Physics2D.OverlapCircle(ceilingCheck.transform.position, ceilingRadius, whatIsCeiling))
        {
            canStandUp = true;
        }

        else
        {
            canStandUp = false;
        }
    }

    //Залазиет на ящик, функция вызывается из скрипта стейта анимации ClimbBox
    public void ClimbOnBox()
    {
        if(pushObj != null)
        {
            if (isRun == true)
            {
                isRun = false;
                moveAnimationStateMashine = 1;
                AnimationStateMashine();
                moveSpeed = walkSpeed;
            }
            //climbState = 2;
            //чекер на ящике или нет
            isOnBox = true;
        }
    }

    //Камера стандарт
    public void CameraStandart()
    {
        cameraTarget.transform.localPosition = camTarCorrentTransform;
    }

    //Камера лестница вверх
    public void CameraLadderUp()
    {
        if (ladderCameraUp == true)
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
            _girlAnimator.SetInteger("IdleWalkState", 0);
            _girlAnimator.SetBool("isWalk", false);
            BoyActive();
        }
        else if (Input.GetButtonDown("ChangeCharacter") && changeActivePerson == 1 && CantChange == false)
        {
            if(horizontalMove > 0 || horizontalMove < 0)
            {
                if(isRun == false)
                {
                    _girlAnimator.SetInteger("IdleWalkState", 1);
                    _girlAnimator.SetBool("isWalk", true);
                }
                else if(isRun == true)
                {
                    _girlAnimator.SetBool("isRun", true);
                    _girlAnimator.SetInteger("IdleWalkState", 2);
                }               
            }
            GirlActive();
        }
    }

    public void GirlStartMovement()
    {
        CantWalkRight = false;
        CantWalkLeft = false;
    }

    public void GirlStopMovement()
    {
        CantWalkRight = true;
        CantWalkLeft = true;
    }

    public void GirlActive()
    {
        changeActivePerson = 0;        
    }

    public void BoyActive()
    {
        changeActivePerson = 1;        
    }
    

    //Триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        //Залезть на ящик
        if (other.tag == "ClimbBox" || other.tag == "ClimbPushBox")
        {
            if (HorizontalOrientation == 0)
            {
                //pushState = 1;
                //Debug.Log("слевой стороны");
            }
            else if (HorizontalOrientation == 1)
            {
                //pushState = 2;
                //Debug.Log("справой стороны");
            }
            climbState = 1;
            climbBoxOn = true;
            pushObj = other.GetComponent<PushObj>();
            CallGirlStop();
        }
        
        //Если на ящике слезть с ящика
        if (isOnBox == true)
        {
            if (other.tag == "ClimbBoxOff")
            {
                cantWalk = true;
                climbState = 2;
                _girlAnimator.SetInteger("ClimbState", 2);
            }
        }

        //Блокирует движение и анимацию в нужную сторону
        if (other.tag == "MoveBlock")
        {
            if(other != null && other.GetComponent<BlockMoveRightLeft>().rightLeftBlock == false)
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
        if (other.tag == "PlayerBoy")
        {
            if (girlGoToBoy == true)
            {
                CallGirlStop();
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Отойти от ящика
        if (other.tag == "ClimbBox" || other.tag == "ClimbPushBox")
        {
            climbState = 0;
            climbBoxOn = false;
            pushObj.GirlOnBox = false;
        }

        if (other.tag == "ClimbBoxOff")
        {

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
