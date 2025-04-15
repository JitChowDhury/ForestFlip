using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;//transform for player
    private PlayerController playerController;
    private Rigidbody2D rb;
    private Animator animator;
    public AnimationClip clip;

    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, -0.2f), moveSpeed * Time.deltaTime);



        if (playerTransform.position.x > this.transform.position.x + 15f)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Death");
            playerController.EnemyTrigger();
            //durationInSeconds = numberOfFrames / frameRate
            Destroy(this.gameObject, 0.2f);

        }
    }


}
