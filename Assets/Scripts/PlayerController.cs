using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public float jumpForce;
    private bool isGrounded;
    private bool canDoubleJump;
    public Transform circleLocation;
    public LayerMask groundLayer;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(circleLocation.position, 0.2f, groundLayer);


        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }


        if (rb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x > 0)
        {
            sr.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("Jump", !isGrounded);
        Debug.Log("jump is now " + isGrounded);

    }
}
