using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    PlayerController _playerController;

    [SerializeField] private Transform SwordAttackBocPosition;
    [SerializeField] private Vector2 boxSize;
    public GameObject windPrefab;

    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    public void SwordMeleAttack()
    {
        print("SwordMeleAttack");

        Collider2D collider = Physics2D.OverlapBox(SwordAttackBocPosition.position, boxSize, 0);

        if(collider != null)
        {
            if(collider.CompareTag("Enemy")) Destroy(collider.gameObject); // Enemy Die
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(SwordAttackBocPosition.position, boxSize);
    }

    public void SwordFireAttack()
    {
        print("SwordFireAttack");

        if (_playerController.isRight)
        {
            windPrefab.GetComponent<SwordWind>().isRight = true;
        }
        else
        {
            windPrefab.GetComponent<SwordWind>().isRight = false;
        }
        windPrefab.transform.position = SwordAttackBocPosition.position;

        Instantiate(windPrefab);
    }
}
