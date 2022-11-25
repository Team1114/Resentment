using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyObstacle : MonoBehaviour, IObstacleObject
{
    public void Crash()
    {
        GameManager.Instance.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Crash();
        }
    }

    private void OnDisable()
    {
        print("SwordEnemyDie");
    }
}
