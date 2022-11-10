using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerController _playerController;

    [SerializeField] private bool isMoving = false; // Dash �Ǵ� Jump �Ǵ� Slide �ϰ� �ִ���

    #region �̺�Ʈ
    [Header("Event")]
    public UnityEvent JumpEvent;
    public UnityEvent DashEvent;
    public UnityEvent SlideEvent;

    public UnityEvent SwordMeleAttack; // �ܰ� ���� ���� - ���콺 ��Ŭ��
    public UnityEvent SwordMeleAttackSecond; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 2��° ����
    public UnityEvent SwordMeleAttackThird; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 3��° ����

    public UnityEvent PushAttack; // �ܰ� ���Ÿ� ���� - ���콺 ��Ŭ�� // �˹� ���� Į�ٶ�
    #endregion

    // �޺� �ý��� ����
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

    private void GetSwordMeleAttackInput() // �ܰ� ����
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0)) // ��Ŭ��
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

    private void GetSwordFireAttack() // �ܰ� ���Ÿ� ����
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(1))
        {
            PushAttack?.Invoke();
        }
    }
}
