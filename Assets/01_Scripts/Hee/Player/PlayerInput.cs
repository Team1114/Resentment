using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerController _playerController;

    [SerializeField] private bool isMoving = false; // Dash 또는 Jump 또는 Slide 하고 있는지

    #region 이벤트
    [Header("Event")]
    public UnityEvent JumpEvent;
    public UnityEvent DashEvent;
    public UnityEvent SlideEvent;

    public UnityEvent SwordMeleAttack; // 단검 근접 공격 - 마우스 좌클릭
    public UnityEvent SwordMeleAttackSecond; // 단검 근접 공격 - 마우스 좌클릭 2번째 공격
    public UnityEvent SwordMeleAttackThird; // 단검 근접 공격 - 마우스 좌클릭 3번째 공격

    public UnityEvent PushAttack; // 단검 원거리 공격 - 마우스 우클릭 // 넉백 공격 칼바람
    #endregion

    // 콤보 시스템 변수
    private int comNoOfClicks = 0;
    private float comLastClickedTime = 0;
    private float comMaxComboDelay = 0.8f;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Time.time - comLastClickedTime > comMaxComboDelay) comNoOfClicks = 0;

        isMoving = MovingCheck();

        GetJumpInput();
        GetDashInput();
        GetSlideInput();

        GetSwordMeleAttackInput();
        GetSwordFireAttack();
    }

    private bool MovingCheck()
    {
        return _playerController.isDashing || _playerController.isJumpping || _playerController.isSliding;
    }

    private void GetJumpInput()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpEvent?.Invoke();
        }
    }

    private void GetDashInput()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashEvent?.Invoke();   
        }
    }

    private void GetSlideInput()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.S))
        {
            SlideEvent?.Invoke();
        }
    }

    private void GetSwordMeleAttackInput() // 단검 공격
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            comLastClickedTime = Time.time;
            comNoOfClicks++;

            if (comNoOfClicks == 1)
            {
                SwordMeleAttack?.Invoke();
            }
            else if (comNoOfClicks == 2)
            {
                SwordMeleAttackSecond?.Invoke();
            }
            else if (comNoOfClicks == 3)
            {
                SwordMeleAttackThird?.Invoke();
                comNoOfClicks = 0;
            }
        }
    }

    private void GetSwordFireAttack() // 단검 원거리 공격
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(1))
        {
            PushAttack?.Invoke();
        }
    }
}
