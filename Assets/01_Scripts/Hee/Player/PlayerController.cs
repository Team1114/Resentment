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

    #region 점프
    [Header("점프")]
    public bool isJumpping = false;
    [SerializeField] private float jumpPower;
    /*[HideInInspector] */public int jumpCount = 2;
    #endregion

    #region 움직임
    [Header("움직임")]
    [SerializeField] private float speed;
    #endregion

    #region 슬라이드
    [Header("슬라이드")]
    public bool isSliding = false;
    public float slidingTime = 1.5f;
    [SerializeField] private Vector2 colSize;
    [SerializeField] private Vector2 colOffset;
    #endregion

    #region 넘기
    [Header("넘기")]
    public bool isPassing = false;
    public float passingTime = 1.5f;
    #endregion

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        col = transform.GetComponentInChildren<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(PlayerDieCheck());
    }

    IEnumerator PlayerDieCheck()
    {
        float lastX = transform.position.x;
        yield return new WaitForSeconds(0.1f);
        if (lastX == transform.position.x)
        {
            print("PlayerIsStop");
            GameManager.Instance.GameOver();
        }
        StartCoroutine(PlayerDieCheck());
    }

    void Update()
    {
        if (UIManager.Instance.EscPanel.activeSelf) return;
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
            if (hit.collider.CompareTag("Ground")) // 땅일 때
            {
                isGround = true;
                jumpPower = 6.5f; // 인스펙터에서 바꾸면 여기도 수정

                if (jumpCount <= 1)
                {
                    jumpCount = 2;
                    PlayerAnimation.Instance.JumpAnimOff();
                    PlayerAnimation.Instance.DoubleJumpOff();
                }
            }
            else if (!hit.collider.CompareTag("Ground")) // 공중일 때
            {
                jumpPower = 9f; // 인스펙터에서 바꾸면 여기도 수정
                isGround = false;
                if (isSliding)
                {
                    SlideFinish();
                }
            }
        }
        else
        {
            jumpPower = 9f; // 인스펙터에서 바꾸면 여기도 수정
            isGround = false;
            if (isSliding)
            {
                SlideFinish();
            }
        }

        isJumpping = !isGround;
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
        if (jumpCount == 0) return;

        print("JumpMoment");

        StartCoroutine(JumpCotoutine());
    }

    IEnumerator JumpCotoutine()
    {
        isJumpping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        if (jumpCount == 2)
        {
            // 점프
            PlayerAnimation.Instance.JumpAnimOn();
        }
        else if (jumpCount == 1)
        {
            // 이단점프
            PlayerAnimation.Instance.DoubleJumpOn();
        }
        
        yield return new WaitForSeconds(0.05f);
        jumpCount--;
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
        first = true;
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

    public void PlayerStop()
    {
        speed = 0;
    }
}
