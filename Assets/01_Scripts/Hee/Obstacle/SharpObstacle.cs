using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpObstacle : MonoBehaviour, IObstacleObject
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.color = Color.black;
    }

    public void Crash()
    {
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Crash();
        }
    }
}
