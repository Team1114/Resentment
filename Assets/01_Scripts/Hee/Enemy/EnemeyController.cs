using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemeyController : MonoBehaviour
{
    Animator anim;

    public int speed = 5; // 추후 삭제
    Rigidbody2D rb;
    [HideInInspector] public Vector2 dir;

    public UnityEvent DiePlaced;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    public void Die()
    {
        DiePlaced?.Invoke();
        anim.SetTrigger("Die");
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
