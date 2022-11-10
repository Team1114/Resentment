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

    #region 점프
    [Header("점프")]
    public bool isJumpping = false;
    [SerializeField] private float jumpPower;
    #endregion

    #region 움직임
    [Header("움직임")]
    [SerializeField] private float speed;
    #endregion

    #region 슬라이드
    [Header("슬라이드")]
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
        StartCoroutine(JumpCotoutine());                        
    }

    IEnumerator JumpCotoutine()
    {
        isJumpping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1.2f);

        isJumpping = false;
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
