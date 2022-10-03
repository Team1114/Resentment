using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerController _playerController;

    #region 이벤트
    [Header("AttackEvent")]
    public UnityEvent SwordMeleAttack; // 단검 근접 공격 - 마우스 좌클릭
    public UnityEvent SwordMeleAttackSecond; // 단검 근접 공격 - 마우스 좌클릭 2번째 공격
    public UnityEvent SwordMeleAttackThird; // 단검 근접 공격 - 마우스 좌클릭 3번째 공격

    public UnityEvent SwordFireAttack; // 단검 원거리 공격 - 마우스 우클릭 // 넉백 공격 칼바람

    public UnityEvent EDownSkill; // E 눌렀을 때 나오는 스킬
    public UnityEvent QDownSKill; // Q 눌렀을 때 나오는 스킬
    public UnityEvent RDownSKill; // R 눌렀을 때 나오는 스킬

    public UnityEvent ResentmentSkill; // 울분 스킬 (궁극기 컨셉) - Space

    [Header("OtherEvent")]
    public UnityEvent InteractionEvent; // 상호작용 - F
    #endregion

    public int noOfClicks = 0;
    public float lastClickedTime = 0;
    public float maxComboDelay = 0.8f;

    [SerializeField] private bool isMoving = false; // Dash 또는 Jump 하고 있는지

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

    private void GetSwordMeleAttackInput() // 단검 공격
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0)) // 좌클릭
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

    private void GetSwordFireAttack() // 단검 원거리 공격
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
