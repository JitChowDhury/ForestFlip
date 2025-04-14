using UnityEngine;

public class Coin : MonoBehaviour
{

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpCoin();
            Destroy(this.gameObject);
        }


    }

    void Update()
    {
        if (playerTransform.position.x > this.transform.position.x + 15f)
        {
            Destroy(this.gameObject);
        }
    }
}

