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
    public UnityEvent JumpEvent; // ����
    public UnityEvent SlideEvent; // �����̵� 
    public UnityEvent SlideFinishEvent; // �����̵� ��
    public UnityEvent PassEvent; // ������Ʈ �ѱ�  

    public UnityEvent SwordMeleAttack; // �ܰ� ���� ���� - ���콺 ��Ŭ��
    public UnityEvent SwordMeleAttackSecond; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 2��° ����

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
        if (UIManager.Instance.EscPanel.activeSelf) return;
        if (Time.time - comLastClickedTime > comMaxComboDelay) comNoOfClicks = 0;

        isMoving = MovingCheck();

        GetJumpInput();
        GetSlideInput();
        GetPassInput();

        GetSwordMeleAttackInput();
    }

    private bool MovingCheck()
    {
        return _playerController.isJumpping || _playerController.isSliding || _playerController.isPassing;
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpEvent?.Invoke();
        }
    }

    private void GetSlideInput()
    {
        if (_playerController.isJumpping || _playerController.isPassing) return;

        if (Input.GetKey(KeyCode.S))
        {
            SlideEvent?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            SlideFinishEvent?.Invoke();
        }
    }

    private void GetPassInput()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            PassEvent?.Invoke();
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
                comNoOfClicks = 0;
            }
        }
    }
    
}
