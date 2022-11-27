using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private Transform NormalAttackBoxPosition;
    [SerializeField] private Vector2 NormalAttackBoxSize;
    
    public void SwordMeleAttack1()
    {
        print("SwordMeleAttack1");

        Collider2D collider = Physics2D.OverlapBox(NormalAttackBoxPosition.position, NormalAttackBoxSize, 0);

        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.gameObject.GetComponent<EnemeyController>()?.Die();
                collider.gameObject.GetComponent<GunEnemyController>()?.Die();
                // Destroy(collider.gameObject); // Enemy Die
            }
        }
    } 

    public void SwordMeleAttack2()
    {
        print("SwordMeleAttack2");

        Collider2D collider = Physics2D.OverlapBox(NormalAttackBoxPosition.position, NormalAttackBoxSize, 0);

        if (collider != null)
        {
            if (collider.CompareTag("Enemy")) 
            {
                collider.gameObject.GetComponent<EnemeyController>()?.Die();
                collider.gameObject.GetComponent<GunEnemyController>()?.Die();
                // Destroy(collider.gameObject); // Enemy Die
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(NormalAttackBoxPosition.position, NormalAttackBoxSize);
    }
}
