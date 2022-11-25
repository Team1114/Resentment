using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunEnemyController : MonoBehaviour
{
    // 3�ܰ�� ������
    // 1�ܰ� : ����ǥ ����
    // 2�ܰ� : �� �߻� �غ�
    // 3�ܰ� : �� �߻�

    public GameObject Bullet;

    public float OneStepDistance = 15f;
    public float TwoStepDistance = 10f;
    public float ThreeStepDistance = 5f;

    public UnityEvent OnStepEvent;
    public UnityEvent TwoStepEvent;
    public UnityEvent ThreeStepEvent;

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        print("GunEnemyDie");
    }
}
