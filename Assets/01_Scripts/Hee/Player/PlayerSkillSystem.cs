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

    public static bool isSKillRunning = false; // Q or E ��ų ���� Ȯ��

    [Header("SkillUse")] // ��Ÿ�� ,��ų ���� �ִ��� Ȯ��
    public bool isQSkillRunning = false; 
    public bool isESkillRunning = false; 
    public bool isSpaceSkillRunning = false; 
    private bool canUseQSkill = true;
    private bool canUseESkill = true;
    private bool canUseSpaceSkill = true;

    [Header("SKillCooltime")] // ��Ÿ��
    [SerializeField] private float QSkillCoolTime = 4f; 
    [SerializeField] private float ESkillCoolTime = 7f;
    [SerializeField] private float SpaceSkillCoolTime = 10f;

    [Header("AttackPosition")] // �ڽ� ������
    [SerializeField] private Transform QSKillBoxPosition;
    [SerializeField] private Transform ESKillBoxPosition;

    [Header("AttackColliderBoxSize")] // �ڽ� ������
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
        if (isSpaceSkillRunning) return; // ��ų ��� ���̸� return

        _resentmentSKill.Resentment();
    }

    public void SpacePlusSkill()
    {
        if (!isSpaceSkillRunning) return; // ��ų ��� ������ ������ return

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
        // �ִϸ��̼� ��� �ڵ�

        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject); // Enemy Die
            }
        }

        // �ִϸ��̼��� ������ �� (is Q,E SkillRunning = false, ��Ÿ�� �ڷ�ƾ ��������ֱ�)  
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
        // �ִϸ��̼� ��� �ڵ�

        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject); // Enemy Die
            }
        }

        // �ִϸ��̼��� ������ �� (isSkillRunning = false, ��Ÿ�� �ڷ�ƾ ��������ֱ�)  
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
