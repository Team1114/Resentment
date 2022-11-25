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
    public Transform bulletPosition;

    public float OneStepDistance = 15f;
    public float TwoStepDistance = 10f;
    public float ThreeStepDistance = 5f;

    public UnityEvent OneStepEvent;
    public UnityEvent TwoStepEvent;
    public UnityEvent ThreeStepEvent;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, GameManager.Instance.Player.transform.position);
        if (distance < OneStepDistance && distance > TwoStepDistance)
        {
            print("1");
            OneStepEvent?.Invoke();
        }
        else if (distance < TwoStepDistance && distance > ThreeStepDistance)
        {
            print("2");
            TwoStepEvent?.Invoke();
        }
        else if (distance < ThreeStepDistance)
        {
            print("3");
            ThreeStepEvent?.Invoke();
        }
    }

    public void Shooting()
    {
        Instantiate(Bullet, bulletPosition.position, Quaternion.identity);
    }


    private void OnDisable()
    {
        print("GunEnemyDie");
    }
}
