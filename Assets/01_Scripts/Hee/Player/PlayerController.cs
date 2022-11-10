using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BoxCollider2D col;
    Rigidbody2D rb;
    Transform tr;
    Animator anim;

    public LayerMask layermask;

    public bool isRight = true;
    public bool isGround = true;

    #region ����
    [Header("����")]
    public bool isJumpping = false;
    public float canJump;
    [SerializeField] private float jumpPower;
    #endregion

    #region ������
    [Header("������")]
    [SerializeField] private float speed;
    #endregion

    #region �뽬
    [Header("�뽬")]
    public bool isDashing = false;
    public bool canDash = true;
    public float dashDelayTime;
    #endregion

    #region �����̵�
    [Header("�����̵�")]
    public bool isSliding = false;
    public bool canSlide = true;
    [SerializeField] private Vector2 colSize;
    [SerializeField] private Vector2 colOffset;
    #endregion

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        col = transform.GetComponentInChildren<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        DirectionCheck();
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
        rb.velocity = new Vector2(speed, rb.velocity.y); //moveDir * speed;

        /*if (isRight)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if (isRight == false)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }*/
    }

    public void Jump()
    {
        if (isJumpping) return;

        isJumpping = true;

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        if (!canDash) return;
        if (isDashing) return;

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

    public void Slide()
    {
        if (!canSlide) return;
        if (isSliding) return;

        Debug.Log("SlideMoment");

        StartCoroutine(SlideCoroutine());
    }

    IEnumerator SlideCoroutine()
    {
        isSliding = true;

        Vector2 lastCoSize = col.size; 
        Vector2 lastColOffset = col.offset; 

        col.size = colSize;
        col.offset = colOffset;

        yield return new WaitForSeconds(2f);
        
        col.size = lastCoSize;
        col.offset = lastColOffset;
        
        isSliding = false;
    }
}
