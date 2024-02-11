using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    //Описание
    //Скрипт Отвечает за базовые передвижения персонажей(шаг, бег)
    //____________________________________________________________

    //Выбирает между мальчиком девочкой и дедом
    //0 девочка, 1 мальчик, 2 дедушка
    protected int changeActivePerson;
    public int ChangeActivePerson { get { return changeActivePerson; } set { changeActivePerson = value; } }
    //Может переключатся между персонажами или нет
    protected bool cantChange;
    public bool CantChange { get { return cantChange; } set { cantChange = value; } }

    //false - двигается, true - не двигается
    protected bool cantWalk;
    public bool CantWalk { get { return cantWalk; } set { cantWalk = value; } }
    protected bool cantWalkRight;
    public bool CantWalkRight { get { return cantWalkRight; } set { cantWalkRight = value; } }
    protected bool cantWalkLeft;
    public bool CantWalkLeft { get { return cantWalkLeft; } set { cantWalkLeft = value; } }
    //В присяде?
    protected bool isCrouch;
    public bool IsCrouch { get { return isCrouch; } set { isCrouch = value; } }

    //Переменные Шаг - Бег
    [Space]
    [Header("Бег-Ходьба")]
    protected Rigidbody2D characterRigidbody;
    protected CapsuleCollider2D capsuleCollision;

    //Скорость передвижения
    protected float moveSpeed, walkSpeed, runSpeed, crouchSpeed, pushSpeed, crySpeed;
    //true - бег, false - шаг
    protected bool isRun;
    //Разовое изменение состояния анимации
    protected bool swichBoolAnimationState;
    public bool SwichBoolAnimationState { get { return swichBoolAnimationState; } set { swichBoolAnimationState = value; } }
    //Горизонталь передвижения +-
    protected float horizontalMove;
    //Вертикаль передвижения
    private float verticalMove;
    //Ориентация движения 0 - право, 1 - лево
    protected int horizontalOrientation;
    public int HorizontalOrientation { get { return horizontalOrientation; } set { horizontalOrientation = value; } }

    //Анимация персонажа
    protected Animator characterAnimator;
    //Стейт машина состояния анимации Шаг - Бег
    protected int moveAnimationStateMashine = 0;
    public int MoveAnimationStateMashine { get { return moveAnimationStateMashine; } set { moveAnimationStateMashine = value; } }
    //Стопер изменения анимации
    protected bool animationStateOn;

    //Climbing
    //Стейт залазить слазить с объектов
    protected int climbState;
    //Чекер Залезла на объект?
    protected bool climbBoxOn;
    //чекер стоит на объекте
    protected bool isOnBox;
    public bool IsOnBox { get { return isOnBox; } set { isOnBox = value; } }
    private bool canBoxClimbOn;
    public bool CanBoxClimbOn { get { return canBoxClimbOn; } set { canBoxClimbOn = value; } }


    //Pushing
    //Стейт сторона толкания
    protected int pushState;
    //Стейт сторона толкания
    //1 - Толкает в Лево
    protected int pusheblState;
    //Чекер готов толкать
    protected bool isPushBoxOn;
    public bool IsPushBoxOn { get { return isPushBoxOn; } set { isPushBoxOn = value; } }
    //Может ли толкать
    protected bool cantPush;
    public bool CantPush { get { return cantPush; } set { cantPush = value; } }

    //Плачет девочка в автомате
    protected bool isCry;
    public bool IsCry { get { return isCry; } set { isCry = value; } }
    //Вскрывает замок
    protected bool isLock;
    public bool IsLock { get { return isLock; } set { isLock = value; } }

    //Лестница правая или левая
    protected int laddersLeftRight;
    public int LaddersLeftRight { get { return laddersLeftRight; } set { laddersLeftRight = value; } }
    protected Vector3 ladderPosition;
    protected Ladders ladders;
    protected bool isLadder;
    public bool IsLadder { get { return isLadder; } set { isLadder = value; } }
    protected bool isLadderUp;
    public bool IsLadderUp { get { return isLadderUp; } set { isLadderUp = value; } }

    //Катушка
    protected bool isKatushkaMove;
    public bool IsKatushkaMove { get { return isKatushkaMove; } set { isKatushkaMove = value; } }


    //Референс на карту и камеру
    public GameObject sceneData;

    


    public virtual void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();
        characterRigidbody = GetComponent<Rigidbody2D>();
        capsuleCollision = GetComponent<CapsuleCollider2D>();
        moveSpeed = 3.5f;
        pushSpeed = 2.5f;
        horizontalOrientation = 0;
        //Не возможно переключиться на другого персонажа
        //CantChange = true;
        //Первый активный персонаж мальчик
        //changeActivePerson = 1;
        //Находит Менеджер сцены
        sceneData = GameObject.FindWithTag("SceneData");
        sceneData.GetComponent<ChangeCameras>().cameraBoy.SetActive(true);
    }

    public virtual void Update()
    {
        //ChangeCharacter();
        PlayerHorizontalMovement();
        PlayerVerticalMovement();
        Run();
    }

    public void PlayerHorizontalMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        characterAnimator.SetFloat("Horizontal", Mathf.Abs(horizontalMove));

        //Передвижение вправо
        if (horizontalMove > 0f && cantWalkRight == false && isLadder == false && isLadderUp == false)
        {
            //Если false устанавливает ориентацию передвижения в лево и запускает движение персонажа
            if (cantWalk == false && isPushBoxOn == false)
            {
                horizontalOrientation = 0;
                characterRigidbody.velocity = new Vector3(moveSpeed, characterRigidbody.velocity.y, 0f) * horizontalMove;
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }

            //Проверяет включен ли бег false - шаг
            if (isRun == false && isCrouch == false && isPushBoxOn == false)
            {   
                moveAnimationStateMashine = 1;
            }
            //Проверяет включен ли бег true - бег
            else if (isRun == true && isCrouch == false && isPushBoxOn == false)
            {
                moveAnimationStateMashine = 2;
            }
            //Проверяет включен ли присяд
            else if (isCrouch == true)
            {
                moveAnimationStateMashine = 4;
            }

            //Тянет Толкает 
            else if (ChangeActivePerson == 1 && isPushBoxOn == true && cantPush == false)
            {
                //Толкае в Право
                if (pushState == 1)
                {
                    moveAnimationStateMashine = 5;
                    //Debug.Log("Толкае в Право");
                }
                //Тянет в право
                else if (pushState == 2)
                {
                    moveAnimationStateMashine = 6;
                    //Debug.Log("Тянет в право");
                }
                horizontalOrientation = 0;
                characterRigidbody.velocity = new Vector3(pushSpeed, characterRigidbody.velocity.y, 0f) * horizontalMove;
                //transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }

            //Запускает изменение состояния анимации
            if (swichBoolAnimationState == false)
            {
                AnimationStateMashine();
                swichBoolAnimationState = true;
            }
        }

        //Передвижение влево
        else if (horizontalMove < 0f && cantWalkLeft == false && isLadder == false && isLadderUp == false)
        {
            //Если false устанавливает ориентацию передвижения в право и запускает движение персонажа
            if (cantWalk == false && isPushBoxOn == false)
            {
                horizontalOrientation = 1;
                characterRigidbody.velocity = new Vector3(-moveSpeed, characterRigidbody.velocity.y, 0f) * -horizontalMove;
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }

            //Проверяет включен ли бег false - шаг
            if (isRun == false && isCrouch == false && isPushBoxOn == false)
            {
                moveAnimationStateMashine = 1;
            }
            //Проверяет включен ли бег true - бег
            else if (isRun == true && isCrouch == false && isPushBoxOn == false)
            {
                moveAnimationStateMashine = 2;
            }
            //Проверяет включен ли присяд
            else if (isCrouch == true)
            {
                moveAnimationStateMashine = 4;
            }
            //Тянет толкае
            else if (ChangeActivePerson == 1 && isPushBoxOn == true && cantPush == false)
            {
                //Тянет в Лево
                if (pushState == 1)
                {
                    moveAnimationStateMashine = 6;
                    //Debug.Log("Тянет в Лево");
                }
                //Толкает в Лево
                else if (pushState == 2)
                {
                    moveAnimationStateMashine = 5;
                    //Debug.Log("Толкает в Лево");
                }
                horizontalOrientation = 1;
                characterRigidbody.velocity = new Vector3(-pushSpeed, characterRigidbody.velocity.y, 0f) * -horizontalMove;
                //transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }

            //Запускает изменение состояния анимации
            if (swichBoolAnimationState == false)
            {
                AnimationStateMashine();
                swichBoolAnimationState = true;
            }
        }

        //Если стоит на месте, запускает анимацию покоя
        else
        {
            characterRigidbody.velocity = new Vector3(0, characterRigidbody.velocity.y, 0f);

            //Если в присяде запускает анимацию покоя в присяде
            if (isCrouch == true && moveAnimationStateMashine == 4)
            {
                moveAnimationStateMashine = 3;
            }
            //если стоит запускает анимацию покоя стоя
            else if (isCrouch == false)
            {
                moveAnimationStateMashine = 0;
            }
            if(isPushBoxOn == true)
            {
                moveAnimationStateMashine = 7;
            }
            //Запускает изменение состояния анимации
            if (swichBoolAnimationState == true)
            {
                AnimationStateMashine();
                swichBoolAnimationState = false;
            }
        }
    }

    //Бег
    public void Run()
    {
        //Бег включен
        if (Input.GetButtonDown("Run") && isRun == false && isOnBox == false && isCrouch == false && isCry == false && isKatushkaMove == false)
        {
            isRun = true;

            //Если игрок идет, сразу включает анимацию бега
            if (moveAnimationStateMashine == 1)
            {
                moveAnimationStateMashine = 2;
            }

            moveSpeed = runSpeed;
            AnimationStateMashine();
        }

        //Бег выключен
        else if (Input.GetButtonDown("Run") && isRun == true && isOnBox == false && isCrouch == false && isKatushkaMove == false)
        {
            isRun = false;
            characterAnimator.SetBool("isRun", false);
            moveSpeed = walkSpeed;

            //Если игрок бежит, сразу включает анимацию шага
            if (moveAnimationStateMashine == 2)
            {
                moveAnimationStateMashine = 1;
            }

            AnimationStateMashine();
        }
    }


    //Вертикальное передвижение - лестницы, препятсвия
    public virtual void PlayerVerticalMovement()
    {
        verticalMove = Input.GetAxisRaw("Vertical");
        characterAnimator.SetFloat("Vertical", Mathf.Abs(verticalMove));

        if (verticalMove > 0f && isCry == false && isCrouch == false && isLock == false && isKatushkaMove == false)
        {
            //Девочка
            //Если выбрана девочка и если зашла в триггер объекта на который залазиет
            if(changeActivePerson == 0 && climbState > 0)
            {
                switch (climbState)
                {
                    case 0:

                        break;
                    case 1:
                        if (climbBoxOn == true && canBoxClimbOn == true)
                        {
                            cantWalk = true;
                            characterAnimator.SetInteger("ClimbState", 1);
                            //climbBoxOn = true;
                        }
                        break;
                    case 2:
                        //Логика лестницы вверх
                        if (isLadderUp == false)
                        {
                            isLadder = true;
                            if (laddersLeftRight == 0)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Левая лестница залазиет с лева");
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    characterAnimator.SetInteger("LadderState", 1);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Левая лестница залазиет с права");
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                            else if (laddersLeftRight == 1)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Правая лестница залазиет с лева");
                                    characterAnimator.SetInteger("LadderState", 1);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Правая лестница залазиет с права");
                                    characterAnimator.SetInteger("LadderState", 1);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                            //Debug.Log(laddersLeftRight);
                        }
                        break;
                    case 3:

                        break;
                }
            }
            //Пацан
            //Если выбран пацан пытается залезть на ящик
            if (changeActivePerson == 1 && climbState > 0 && isPushBoxOn == false && isKatushkaMove == false)
            {
                switch (climbState)
                {
                    case 0:

                        break;
                    case 1:
                        if(canBoxClimbOn == true)
                        {
                            characterAnimator.SetBool("isClimb", true);
                        }
                        break;
                    case 2:
                        //Логика лестницы вверх
                        if(isLadderUp == false)
                        {
                            isLadder = true;
                            if (laddersLeftRight == 0)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Левая лестница залазиет с лева");
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    characterAnimator.SetInteger("LadderState", 1);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Левая лестница залазиет с права");
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                            else if (laddersLeftRight == 1)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Правая лестница залазиет с лева");
                                    characterAnimator.SetInteger("LadderState", 1);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Правая лестница залазиет с права");
                                    characterAnimator.SetInteger("LadderState", 1);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                            //Debug.Log(laddersLeftRight);
                        }

                        break;
                    case 3:

                        break;
                }
            }
        }

        else if (verticalMove < 0f && isCry == false && isCrouch == false && isLock == false && isKatushkaMove == false)
        {
            //Девочка
            if (changeActivePerson == 0 && climbState > 0)
            {
                switch (climbState)
                {
                    case 0:
                        break;
                    case 1:
                       
                        break;
                    case 2:

                        break;
                    case 3:
                        if (isLadder == false)
                        {
                            //Логика лестницы вверх
                            isLadderUp = true;
                            if (laddersLeftRight == 0)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Левая лестница спускается с лева");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Левая лестница спускается с права");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                            else if (laddersLeftRight == 1)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Правая лестница спускается с лева");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Правая лестница спускается с права");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                        }
                        break;
                }
            }
            if (changeActivePerson == 1 && climbState > 0 && isPushBoxOn == false && isKatushkaMove == false)
            {
                switch (climbState)
                {
                    case 0:
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:
                        if(isLadder == false)
                        {
                            //Логика лестницы вверх
                            isLadderUp = true;
                            if (laddersLeftRight == 0)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Левая лестница спускается с лева");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Левая лестница спускается с права");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                            else if (laddersLeftRight == 1)
                            {
                                if (HorizontalOrientation == 0)
                                {
                                    //Debug.Log("Правая лестница спускается с лева");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                                else if (HorizontalOrientation == 1)
                                {
                                    //Debug.Log("Правая лестница спускается с права");
                                    characterAnimator.SetInteger("LadderState", 2);
                                    transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                                    transform.position = new Vector3(ladderPosition.x - +0.95f, transform.position.y, transform.position.z);
                                    ladders.LadderStart();
                                }
                            }
                        }

                        break;
                }
            }
        }
        
        else 
        {

        }
    }

    //Выключение лестницы
    public void LaddersOff()
    {
        ladders.LadderFinish();
    }

    //Поднятие предмета, включает анимацию, стопорит передвижение
    public void PickUpAnimationStart()
    {
        cantWalk = true;
        characterAnimator.SetInteger("PickUpState", 1);
    }

    //Переключение персонажа
    //public void ChangeCharacter()
    //{
     //   if (Input.GetButtonDown("ChangeCharacter") && changeActivePerson == 0 && CantChange == false)
     //   {
     //       BoyActivePerson();
     //   }
     //   else if (Input.GetButtonDown("ChangeCharacter") && changeActivePerson == 1 && CantChange == false)
     //   {
     //       GirlActivePerson();
     //   }
    //}

    //Переключение на девочку
    //public virtual void GirlActivePerson()
    //{
        //characterAnimator.SetInteger("IdleWalkState", 0);
        //characterAnimator.SetBool("isWalk", false);
        //sceneData.GetComponent<ChangeCameras>().cameraGirl.SetActive(true);
        //sceneData.GetComponent<ChangeCameras>().cameraBoy.SetActive(false);
        //changeActivePerson = 0;
    //}
    //Переключение на мальчика
    //public virtual void BoyActivePerson()
    //{
        //characterAnimator.SetInteger("IdleWalkState", 0);
        //characterAnimator.SetBool("isWalk", false);
        //sceneData.GetComponent<ChangeCameras>().cameraGirl.SetActive(false);
        //sceneData.GetComponent<ChangeCameras>().cameraBoy.SetActive(true);
        //changeActivePerson = 1;
    //}
    private void ChangeWalk()
    {
        if (this.horizontalMove > 0f || this.horizontalMove < 0f)
        {
            moveAnimationStateMashine = 1;
            AnimationStateMashine();
        }
        else if (this.horizontalMove == 0f)
        {
            moveAnimationStateMashine = 0;
            AnimationStateMashine();
        }
    }
    //Переключение состояния анимации движения
    public void AnimationStateMashine()
    {
        switch (moveAnimationStateMashine)
        {
            //Покой
            case 0:
                characterAnimator.SetInteger("IdleWalkState", 0);
                characterAnimator.SetBool("isWalk", false);
                break;
            //Шаг
            case 1:
                characterAnimator.SetInteger("IdleWalkState", 1);
                characterAnimator.SetBool("isWalk", true);
                characterAnimator.SetBool("isRun", false);
                break;
            //Бег
            case 2:
                characterAnimator.SetBool("isRun", true);
                characterAnimator.SetInteger("IdleWalkState", 2);
                break;
            //Приседание
            case 3:
                characterAnimator.SetInteger("IdleWalkState", 3);
                break;
            //Движение в присяде
            case 4:
                characterAnimator.SetInteger("IdleWalkState", 4);
                break;
            //Толкает
            case 5:
                characterAnimator.SetInteger("PushState", 2);
                break;
            //Тянет
            case 6:
                characterAnimator.SetInteger("PushState", 3);
                break;
            //СТоит в позиции толкает
            case 7:
                characterAnimator.SetInteger("PushState", 1);
                break;
        }
    }
}
