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

    public void Resentment() // 실행시간은 4초로 일단 (바꾸면 인풋에서도 바꿔줘야 함)
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
