using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerController _playerController;

    [SerializeField] private bool isMoving = false; // Dash �Ǵ� Jump �ϰ� �ִ���

    #region �̺�Ʈ
    [Header("AttackEvent")]
    public UnityEvent SwordMeleAttack; // �ܰ� ���� ���� - ���콺 ��Ŭ��
    public UnityEvent SwordMeleAttackSecond; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 2��° ����
    public UnityEvent SwordMeleAttackThird; // �ܰ� ���� ���� - ���콺 ��Ŭ�� 3��° ����

    public UnityEvent SwordFireAttack; // �ܰ� ���Ÿ� ���� - ���콺 ��Ŭ�� // �˹� ���� Į�ٶ�

    public UnityEvent EDownSkill; // E ������ �� ������ ��ų
    public UnityEvent QDownSKill; // Q ������ �� ������ ��ų

    public UnityEvent ResentmentSkill; // ��� ��ų (�ñر� ����) - Space
    public UnityEvent TeleportSkill; // ��� �� �ڷ���Ʈ ��ų (�ñر� ����) - SpaceSecond

    [Header("OtherEvent")]
    public UnityEvent InteractionEvent; // ��ȣ�ۿ� - F
    #endregion

    // �޺� �ý��� ����
    private int comNoOfClicks = 0;
    private float comLastClickedTime = 0;
    private float comMaxComboDelay = 0.8f;

    // �ñر� ��ų ����
    private int spaceNoOfClicks = 0;
    private float spaceLastClickedTime = 0;
    private float spaceMaxComboDelay = 4f;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Time.time - comLastClickedTime > comMaxComboDelay) comNoOfClicks = 0;
        if (Time.time - spaceLastClickedTime > spaceMaxComboDelay) spaceNoOfClicks = 0;

        isMoving = MovingCheck();

        GetSwordMeleAttackInput();
        GetSwordFireAttack();

        GetQSkill();
        GetESkill();

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
        if (PlayerSkillSystem.isSKillRunning) return;

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
        if (PlayerSkillSystem.isSKillRunning) return;

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

    private void GetSpaceSkill()
    {
        if (isMoving) return;
        if (PlayerSkillSystem.isSKillRunning) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceLastClickedTime = Time.time;
            spaceNoOfClicks++;

            if (spaceNoOfClicks == 1)
            {
                ResentmentSkill?.Invoke();
            }
            else if (spaceNoOfClicks == 2)
            {
                TeleportSkill?.Invoke();
                spaceNoOfClicks = 0;
            }
        }
    }
}
