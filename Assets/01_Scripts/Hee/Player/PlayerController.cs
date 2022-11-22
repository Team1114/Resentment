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
            if (hit.collider.CompareTag("Ground")) // 땅일 때
            {
                isGround = true;
                speed = 10f;
                jumpPower = 7f; // 인스펙터에서 바꾸면 여기도 수정
                jumpCount = 2;
            }
            else if (!hit.collider.CompareTag("Ground")) // 공중일 때
            {
                jumpPower = 5f; // 인스펙터에서 바꾸면 여기도 수정
                isGround = false;
                speed = 7f;
            }
        }
        else // 공중일 때
        {
            jumpPower = 5f; // 인스펙터에서 바꾸면 여기도 수정
            isGround = false;
            speed = 7f;
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
        if (isSliding) return;
        if (isPassing) return;
        if (jumpCount <= 1) return;

        print("JumpMoment");

        StartCoroutine(JumpCotoutine());
    }

    IEnumerator JumpCotoutine()
    {
        isJumpping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        jumpCount--;
        yield return null;
    }

    public void Slide()
    {
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

        yield return new WaitForSeconds(slidingTime);
        
        col.size = lastCoSize;
        col.offset = lastColOffset;
        
        isSliding = false;
    }

    public void Pass()
    {
        if (!isObstacle) return;

        StartCoroutine(PassCoroutine());
    }

    IEnumerator PassCoroutine()
    {
        isPassing = true;

        Vector2 lastCoSize = col.size;
        Vector2 lastColOffset = col.offset;

        col.size = colSize;
        col.offset = -colOffset;

        yield return new WaitForSeconds(passingTime);

        col.size = lastCoSize;
        col.offset = lastColOffset;

        isPassing = false;
    }
}
