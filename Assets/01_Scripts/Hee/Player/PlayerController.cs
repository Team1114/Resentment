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

    [HideInInspector] public bool isRight = true;
    public bool isGround = true;
    public bool isObstacle = false;

    #region ����
    [Header("����")]
    public bool isJumpping = false;
    [SerializeField] private float jumpPower;
    /*[HideInInspector] */public int jumpCount = 2;
    #endregion

    #region ������
    [Header("������")]
    [SerializeField] private float speed;
    #endregion

    #region �����̵�
    [Header("�����̵�")]
    public bool isSliding = false;
    public float slidingTime = 1.5f;
    [SerializeField] private Vector2 colSize;
    [SerializeField] private Vector2 colOffset;
    #endregion

    #region �ѱ�
    [Header("�ѱ�")]
    public bool isPassing = false;
    public float passingTime = 1.5f;
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
        GroundCheck();
        ObstacleCheck();
        Move();
    }

    void GroundCheck()
    {
        Vector2 rayPosition = new Vector2(tr.position.x, tr.position.y - 1.3f);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.down, 0.01f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Ground")) // ���� ��
            {
                isGround = true;
                jumpPower = 5f; // �ν����Ϳ��� �ٲٸ� ���⵵ ����
                jumpCount = 2;
            }
            else if (!hit.collider.CompareTag("Ground")) // ������ ��
            {
                jumpPower = 10f; // �ν����Ϳ��� �ٲٸ� ���⵵ ����
                isGround = false;
            }
        }
        else // ������ ��
        {
            jumpPower = 10f; // �ν����Ϳ��� �ٲٸ� ���⵵ ����
            isGround = false;
        }

        isJumpping = !isGround;

        if (isGround)
        {
            if (isSliding) return;
            if (isPassing) return;

            PlayerAnimation.Instance.JumpAnimOff();
            PlayerAnimation.Instance.DoubleJumpOff();
        }
    }

    void ObstacleCheck()
    {
        Vector2 rayPosition = new Vector2(tr.position.x + 1f, tr.position.y - 0.5f);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.right, 0.5f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                isObstacle = true;
            }
            else
            {
                isObstacle = false;
            }
        }
        else
        {
            isObstacle = false; 
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y); //moveDir * speed;
    }

    public void Jump()
    {
        if (isSliding) return;
        if (isPassing) return;
        if (jumpCount <= 0) return;

        print("JumpMoment");

        StartCoroutine(JumpCotoutine());
    }

    IEnumerator JumpCotoutine()
    {
        isJumpping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        if (jumpCount == 2)
        {
            // ����
            PlayerAnimation.Instance.JumpAnimOn();
        }
        else
        {
            // �̴�����
            PlayerAnimation.Instance.DoubleJumpOn();
        }

        jumpCount--;
        yield return null;
    }

    Vector2 lastCoSize;
    Vector2 lastColOffset;
    bool first = true;

    public void Slide()
    {
        Debug.Log("SlideMoment");

        isSliding = true;

        if (first)
        {
            lastCoSize = col.size;
            lastColOffset = col.offset;

            col.size = colSize;
            col.offset = colOffset;
            first = false;
        }
    }

    public void SlideFinish()
    {
        Debug.Log("SlideFinish");
        
        isSliding = false;
        col.size = lastCoSize;
        col.offset = lastColOffset;
    }

    public void Pass()
    {
        if (!isObstacle) return;

        StartCoroutine(PassCoroutine());
    }

    IEnumerator PassCoroutine()
    {
        isPassing = true;
        PlayerAnimation.Instance.PassingObjAnimOn();
        Vector2 lastCoSize = col.size;
        Vector2 lastColOffset = col.offset;

        col.size = colSize;
        col.offset = -colOffset;

        yield return new WaitForSeconds(passingTime);

        col.size = lastCoSize;
        col.offset = lastColOffset;
        PlayerAnimation.Instance.PassingObjAnimOff();
        isPassing = false;
    }
}
