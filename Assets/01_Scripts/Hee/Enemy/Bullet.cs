using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.Translate(bulletSpeed * Vector2.left * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // PlayerDie
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
