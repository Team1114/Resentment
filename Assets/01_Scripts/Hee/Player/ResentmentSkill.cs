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

    public void Resentment() // 실행시간은 4초로 일단 (바꾸면 인풋에서도 바꿔줘야 함)
    {
        print("Resentment");
    }

    public void Teleport()
    {
        print("Teleport");
    }
}
