using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpObstacle : MonoBehaviour, IObstacleObject
{
    public void Crash()
    {
        GameManager.Instance.GameOver();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("111");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Crash();
        }
    }
}
