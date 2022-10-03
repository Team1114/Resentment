using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerController _playerController;

    #region �̺�Ʈ
    [Header("AttackEvent")]
    public UnityEvent SwordMeleAttack; // �ܰ� ���� ���� - ���콺 ��Ŭ��
    public UnityEvent SwordMeleAttackSecond; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 2��° ����
    public UnityEvent SwordMeleAttackThird; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 3��° ����

    public UnityEvent SwordFireAttack; // �ܰ� ���Ÿ� ���� - ���콺 ��Ŭ�� // �˹� ���� Į�ٶ�

    public UnityEvent EDownSkill; // E ������ �� ������ ��ų
    public UnityEvent QDownSKill; // Q ������ �� ������ ��ų
    public UnityEvent RDownSKill; // R ������ �� ������ ��ų

    public UnityEvent ResentmentSkill; // ��� ��ų (�ñر� ����) - Space

    [Header("OtherEvent")]
    public UnityEvent InteractionEvent; // ��ȣ�ۿ� - F
    #endregion

    public int noOfClicks = 0;
    public float lastClickedTime = 0;
    public float maxComboDelay = 0.8f;

    [SerializeField] private bool isMoving = false; // Dash �Ǵ� Jump �ϰ� �ִ���

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay) noOfClicks = 0;
        isMoving = MovingCheck();

        GetSwordMeleAttackInput();
        GetSwordFireAttack();

        GetQSkill();
        GetESkill();
        GetRSkill();

        GetSpaceSkill(); // Resentment Skill

        GetInteractionInput();
    }

    private bool MovingCheck()
    {
        return _playerController.isDashing || _playerController.isJumpping;
    }

    private void GetInteractionInput()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractionEvent.Invoke();
        }
    }

    private void GetSwordMeleAttackInput() // �ܰ� ����
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0)) // ��Ŭ��
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                SwordMeleAttack?.Invoke();
            }
            else if (noOfClicks == 2)
            {
                SwordMeleAttackSecond?.Invoke();
            }
            else if (noOfClicks == 3)
            {
                SwordMeleAttackThird?.Invoke();
                noOfClicks = 0;
            }
        }
    }

    private void GetSwordFireAttack() // �ܰ� ���Ÿ� ����
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(1))
        {
            SwordFireAttack?.Invoke();
        }
    }

    private void GetQSkill()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            QDownSKill?.Invoke();
        }
    }

    private void GetESkill()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            EDownSkill?.Invoke();
        }
    }

    private void GetRSkill()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            RDownSKill?.Invoke();
        }
    }

    private void GetSpaceSkill()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResentmentSkill?.Invoke();
        }
    }
}
