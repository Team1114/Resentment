using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region jump
    [Header("점프 관련")]
    BoxCollider2D col;
    bool isJumping = true;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float jumpPower;
    #endregion
    #region move
    [Header("움직임 관련")]
    [SerializeField] private float speed;
    [SerializeField] Animator anim;
    Rigidbody2D rb;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            Debug.Log("jump");
        }
    }

    void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);//moveDir * speed;
    }

    void Jump()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(col.bounds.center, 
            col.bounds.size, 0f, Vector2.down, 0.1f, layerMask);

        

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        if (raycast.collider != null)
            anim.SetTrigger("isJump");
        
        else anim.SetTrigger("isJump");
    }
}
