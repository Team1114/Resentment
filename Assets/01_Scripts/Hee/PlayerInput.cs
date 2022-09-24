using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    #region ���� �̺�Ʈ
    [Header("AttackEvent")]
    public UnityEvent SwordMeleAttack; // �ܰ� ���� ���� - ���콺 ��Ŭ��
    public UnityEvent SwordFireAttack; // �ܰ� �߻� ���� - E
    public UnityEvent GunFireAttack; // �Ѿ� �߻� ���� - ���콺 ��Ŭ��
    public UnityEvent ResentmentSkill; // ��� ��ų (�ñر�) - SPACE �� �ʰ� ������
    #endregion 

    public UnityEvent BulletReload; // �Ѿ� ���� - R
    public UnityEvent InteractionEvent; // ��ȣ�ۿ� - F


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
