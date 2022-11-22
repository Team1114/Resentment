using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnemy : MonoBehaviour, IObstacleObject
{
    public void Crash()
    {
        GameManager.Instance.GameClear();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Crash();
        }
    }
}
