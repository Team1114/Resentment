using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    #region 공격 이벤트
    [Header("AttackEvent")]
    public UnityEvent SwordMeleAttack; // 단검 근접 공격 - 마우스 좌클릭
    public UnityEvent SwordFireAttack; // 단검 발사 공격 - E
    public UnityEvent GunFireAttack; // 총알 발사 공격 - 마우스 우클릭
    public UnityEvent ResentmentSkill; // 울분 스킬 (궁극기) - SPACE 몇 초간 누르기
    #endregion 

    public UnityEvent BulletReload; // 총알 장전 - R
    public UnityEvent InteractionEvent; // 상호작용 - F


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SwordMeleAttack.Invoke();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            GunFireAttack.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            SwordFireAttack.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            BulletReload.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            InteractionEvent.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            ResentmentSkill?.Invoke();
        }
    }
}
