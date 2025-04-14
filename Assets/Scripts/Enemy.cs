using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator animator;
    public AnimationClip clip;

    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, -0.2f), speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Death");
            //durationInSeconds = numberOfFrames / frameRate
            Destroy(this.gameObject, 0.2f);
        }
    }


}
