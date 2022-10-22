using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResentmentSkill : MonoBehaviour
{
    PlayerSkillSystem _playerSkillSystem;
    PlayerController _playerController;

    private Vector3 resentmentTR;

    private void Awake()
    {
        _playerSkillSystem = GetComponent<PlayerSkillSystem>();
        _playerController = GetComponentInParent<PlayerController>();
    }

    public Vector3 PlayerPosition()
    {
        return GetComponentInParent<Transform>().transform.position;
    }

    public void Resentment() // ����ð��� 4�ʷ� �ϴ� (�ٲٸ� ��ǲ������ �ٲ���� ��)
    {
        print("Resentment");
        resentmentTR = PlayerPosition();
        _playerController.Dash();
    }

    public void Teleport()
    {
        print("Teleport");
    }

    public void FinishResentment()
    {
        _playerController.tr.position = resentmentTR;
    }
}
