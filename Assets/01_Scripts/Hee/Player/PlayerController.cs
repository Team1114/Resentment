using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sprite; // flip
    BoxCollider2D col;
    Rigidbody2D rb;

    public bool isRight = true;

    #region ����
    [Header("����")]
    public bool isJumpping = false;
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
    public bool canDash = true;
    public float dashDelayTime;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = transform.GetComponentInChildren<BoxCollider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        DirectionCheck();
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

    void DirectionCheck()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        if (moveDir.x == 1)
        {
            isRight = true;
        }
        else if (moveDir.x == -1)
        {
            isRight = false;
        }
    }

    void Move()
    {
        // Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y); //moveDir * speed;

        if (isRight)
        {
            // sprite.flipX = false;
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if (isRight == false)
        {
            // sprite.flipX = true;
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    void Jump()
    {
        JumpCheck();

        if (isJumpping) return;

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void JumpCheck()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, canJump, layerMask);

        // �ִϸ��̼� �ڵ� �ּ� ���� ����
        if (raycast.collider != null) // �ٴڿ� ���� ��
        {
            isJumpping = false;
            // anim.SetTrigger("isJump");
        }
        else // �� ���� ��
        {
            isJumpping = true;
            // anim.SetTrigger("isJump");
        }
    }

    void Dash()
    {
        if (!canDash) return;
        if (isDashing) return;

        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        if (isRight) // �������� ��
        {
            StartCoroutine(DashCoroutine(1)); // ����ڷ�ƾ�� �Ű������� 1�� �־���
        }
        else if (isRight == false) // ������ ��
        {
            StartCoroutine(DashCoroutine(-1)); // ����ڷ�ƾ�� �Ű������� -1�� �־���
        }
    }

    IEnumerator DashCoroutine(float rightAndleft)
    {
        canDash = false;
        isDashing = true;

        transform.DOMoveX(transform.position.x + 2 * rightAndleft, 0.2f); // �Ű������� ���� ����� �����Ŀ� ���� ������ �޶���

        yield return new WaitForSeconds(0.18f);
        isDashing = false;

        yield return new WaitForSeconds(dashDelayTime);
        canDash = true;
    }
}
