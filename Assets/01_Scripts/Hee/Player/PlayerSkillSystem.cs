using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public enum SkillType
{
    QSkill,
    ESkill,
}

public class PlayerSkillSystem : MonoBehaviour
{
    ResentmentSkill _resentmentSKill;

    public SkillType skillType;

    public static bool isSKillRunning = false; // Q or E 스킬 실행 확인

    [Header("SkillUse")] // 쿨타임 ,스킬 돌고 있는지 확인
    public bool isQSkillRunning = false; 
    public bool isESkillRunning = false; 
    public bool isSpaceSkillRunning = false; 
    private bool canUseQSkill = true;
    private bool canUseESkill = true;
    private bool canUseSpaceSkill = true;

    [Header("SKillCooltime")] // 쿨타임
    [SerializeField] private float QSkillCoolTime = 4f; 
    [SerializeField] private float ESkillCoolTime = 7f;
    [SerializeField] private float SpaceSkillCoolTime = 10f;

    [Header("AttackPosition")] // 박스 포지션
    [SerializeField] private Transform QSKillBoxPosition;
    [SerializeField] private Transform ESKillBoxPosition;

    [Header("AttackColliderBoxSize")] // 박스 사이즈
    [SerializeField] private Vector2 QSkillBoxSize;
    [SerializeField] private Vector2 ESkillBoxSize;

    private void Awake()
    {
        _resentmentSKill = GetComponent<ResentmentSkill>();
    }

    private void Update()
    {
        isSKillRunning = (isQSkillRunning || isESkillRunning);   
    }

    public void SpaceSkill()
    {
        if (!canUseSpaceSkill) return;
        if (isSpaceSkillRunning) return; // 스킬 사용 중이면 return

        _resentmentSKill.Resentment();
    }

    public void SpacePlusSkill()
    {
        if (!isSpaceSkillRunning) return; // 스킬 사용 중이지 않으면 return

        _resentmentSKill.Teleport();
    }

    public void QSKill()
    {
        if (!canUseQSkill) return; 
        if (isQSkillRunning || isESkillRunning) return;

        print("QSkill");

        isQSkillRunning = true;
        canUseQSkill = false;

        Collider2D collider = Physics2D.OverlapBox(QSKillBoxPosition.position, QSkillBoxSize, 0);
        // 애니메이션 재생 코드

        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject); // Enemy Die
            }
        }

        // 애니메이션이 끝났을 때 (is Q,E SkillRunning = false, 쿨타임 코루틴 실행시켜주기)  
        isQSkillRunning = false;
        StartCoroutine(CoolTime(QSkillCoolTime));
    }

    public void ESkill()
    {
        if (!canUseESkill) return;
        if (isQSkillRunning || isESkillRunning) return;

        print("ESkill");

        isESkillRunning = true;
        canUseESkill = false;

        Collider2D collider = Physics2D.OverlapBox(ESKillBoxPosition.position, ESkillBoxSize, 0);
        // 애니메이션 재생 코드

        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject); // Enemy Die
            }
        }

        // 애니메이션이 끝났을 때 (isSkillRunning = false, 쿨타임 코루틴 실행시켜주기)  
        isESkillRunning = false;
        StartCoroutine(CoolTime(ESkillCoolTime));
    }

    public IEnumerator CoolTime(float coolTime)
    {
        float FirstCoolTime = coolTime;

        /*yield return new WaitForSeconds(3f);
        isQSkillRunning = false;*/

        yield return new WaitForSeconds(coolTime);

        if (FirstCoolTime == QSkillCoolTime) canUseQSkill = true;
        else if (FirstCoolTime == ESkillCoolTime) canUseESkill = true;
    }

    private void OnDrawGizmos()
    {
        if (skillType == SkillType.QSkill)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(QSKillBoxPosition.position, QSkillBoxSize);
        }
        else if (skillType == SkillType.ESkill)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(ESKillBoxPosition.position, ESkillBoxSize);
        }
    }
}
