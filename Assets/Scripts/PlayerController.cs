using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Animator animator;

    public float jumpForce;
    private bool isGrounded;
    private bool canDoubleJump;
    public Transform circleLocation;
    public LayerMask groundLayer;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        //rb.linearVelocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.linearVelocity.y);
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
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

        Vector2 scale = transform.localScale;
        if (rb.linearVelocity.x < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (rb.linearVelocity.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("Jump", !isGrounded);
        Debug.Log("jump is now " + isGrounded);

    }


    public void PickUpCoin()
    {
        Debug.Log("player picked up the coin");
    }

    public void EnemyTrigger()
    {
        Debug.Log("Collided with Enemy");
    }
}
