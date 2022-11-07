using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour
{
    /*[SerializeField] EnemyDataSO data;
    public EnemyDataSO Data { get { return data; } }*/
    public int speed = 5; // ���� ����
    Rigidbody2D rb;
    [HideInInspector] public Vector2 dir;

    public bool isCheckPlayer = false;
    public bool isFollowPlayer = false;
    public bool isAttackPlayer = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        DirCheck();
    }

    private void DirCheck()
    {
        if (dir.x == 1)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if (dir.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    private void Movement()
    {
        rb.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point")) // ����Ʈ�� �浹���� ��
        {
            if (isCheckPlayer || isFollowPlayer || isAttackPlayer) return; // ���� �ൿ�̶� �ϰ� ������ ����Ʈ�� ����ȭ
            DirChange();
        }
    }

    private void DirChange()
    {
        dir.x *= -1;
        transform.localScale = new Vector3(-dir.x, 1, 1);
    }
}
