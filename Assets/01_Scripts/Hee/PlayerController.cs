using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sprite; // flip
    BoxCollider2D col;
    Rigidbody2D rb;

    #region ����
    [Header("����")]
    public bool isJumping = false;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float jumpPower;
    public float canJump;
    #endregion

    #region ������
    [Header("������")]
    [SerializeField] private float speed;
    [SerializeField] Animator anim;
    #endregion

    #region �뽬
    [Header("�뽬")]
    public bool isDashing = false;
    public float dashDelayTime;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        JumpCheck();

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }

    void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y); //moveDir * speed;

        if (moveDir.x == 1)
        {
            sprite.flipX = false;
        }
        else if (moveDir.x == -1)
        {
            sprite.flipX = true;
        }
    }

    void Jump()
    {
        JumpCheck();

        if (isJumping) return;

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void JumpCheck()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, canJump, layerMask);

        // �ִϸ��̼� �ڵ� �ּ� ���� ����
        if (raycast.collider != null) // �ٴڿ� ���� ��
        {
            isJumping = false;
            // anim.SetTrigger("isJump");
        }
        else // �� ���� ��
        {
            isJumping = true;
            // anim.SetTrigger("isJump");
        }
    }

    void Dash()
    {
        if (isDashing) return;

        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        if (moveDir.x == 1) // �������� ��
        {
            StartCoroutine(DashCoroutine(1)); // ����ڷ�ƾ�� �Ű������� 1�� �־���
        }
        else if (moveDir.x == -1) // ������ ��
        {
            StartCoroutine(DashCoroutine(-1)); // ����ڷ�ƾ�� �Ű������� -1�� �־���
        }
    }

    IEnumerator DashCoroutine(float rightAndleft)
    {
        isDashing = true;
        transform.DOMoveX(transform.position.x + 2 * rightAndleft, 0.2f); // �Ű������� ���� ����� �����Ŀ� ���� ������ �޶���
        yield return new WaitForSeconds(dashDelayTime);
        isDashing = false;
    }
}
