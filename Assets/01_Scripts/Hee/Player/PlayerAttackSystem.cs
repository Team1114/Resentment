using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    PlayerController _playerController;

    [SerializeField] private Transform SwordAttackBocPosition;
    [SerializeField] private Vector2 boxSize;
    public GameObject windPrefab;

    private bool canFireAttack = false;

    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    public void SwordMeleAttack1()
    {
        print("SwordMeleAttack1");

        Collider2D collider = Physics2D.OverlapBox(SwordAttackBocPosition.position, boxSize, 0);

        if (collider != null)
        {
            if (collider.CompareTag("Enemy")) Destroy(collider.gameObject); // Enemy Die
        }
    }

    public void SwordMeleAttack2()
    {
        print("SwordMeleAttack2");

        Collider2D collider = Physics2D.OverlapBox(SwordAttackBocPosition.position, boxSize, 0);

        if (collider != null)
        {
            if (collider.CompareTag("Enemy")) Destroy(collider.gameObject); // Enemy Die
        }
    }

    public void SwordMeleAttack3()
    {
        print("SwordMeleAttack3");

        Collider2D collider = Physics2D.OverlapBox(SwordAttackBocPosition.position, boxSize, 0);

        if (collider != null)
        {
            if (collider.CompareTag("Enemy")) Destroy(collider.gameObject); // Enemy Die
        }

        canFireAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(SwordAttackBocPosition.position, boxSize);
    }

    public void SwordFireAttack()
    {
        print("SwordFireAttack");

        if (!canFireAttack) return;

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

        canFireAttack = false;
    }
}
