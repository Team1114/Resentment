using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    /*[SerializeField] EnemyDataSO data;
    public EnemyDataSO Data { get { return data; } }*/
    int speed = 5; // 추후 삭제
    Rigidbody2D rb;
    [SerializeField] Vector2 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        rb.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point")) // 포인트랑 충돌했을 때
        {
            DirChange();
        }
    }

    private void DirChange()
    {
        dir.x *= -1;
        transform.localScale = new Vector3(-dir.x, 1, 1);
    }
}
