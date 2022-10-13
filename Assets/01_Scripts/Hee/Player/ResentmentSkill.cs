using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResentmentSkill : MonoBehaviour
{
    PlayerSkillSystem _playerSkillSystem;

    private void Awake()
    {
        _playerSkillSystem = GetComponent<PlayerSkillSystem>();
    }

    public void Resentment() // ����ð��� 4�ʷ� �ϴ� (�ٲٸ� ��ǲ������ �ٲ���� ��)
    {
        print("Resentment");
    }

    public void Teleport()
    {
        print("Teleport");
    }
}
