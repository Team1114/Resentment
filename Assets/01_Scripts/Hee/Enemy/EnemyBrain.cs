using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    EnemeyController _enemeyController;

    [SerializeField] private Transform targetPosition;
    [SerializeField] private float canChaseRange;
    [SerializeField] private float canAttackRange;

    private void Awake()
    {
        _enemeyController = GetComponent<EnemeyController>();
    }

    private void Update()
    {
        TargetChecking();

        if (_enemeyController.isCheckPlayer)
        {
            
        }
        else if (_enemeyController.isFollowPlayer)
        {
            ChaseState();
        }
        else if (_enemeyController.isAttackPlayer)
        {

        }
    }

    private void TargetChecking()
    {
        float distance = Vector2.Distance(transform.position, targetPosition.position);

        if (distance < canChaseRange)
        {
            _enemeyController.isFollowPlayer = true;
        }
        else if (distance > canAttackRange)
        {
            _enemeyController.isAttackPlayer = true;
        }
    }

    private void ChaseState()
    {
        Vector2 playerPs = targetPosition.position;

        if (playerPs.x > transform.position.x) // player가 오른쪽에 있을 때
        {
            _enemeyController.dir.x = 1f;
        }
        else
        {
            _enemeyController.dir.x = -1f;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, canChaseRange);
            Gizmos.color = Color.white;
        }
        if (UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, canAttackRange);
            Gizmos.color = Color.white;
        }
    }
#endif
}
