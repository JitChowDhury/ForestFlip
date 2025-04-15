using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 pos = this.transform.position;
        pos = new Vector3(playerTransform.position.x - 20f, playerTransform.position.y, transform.position.z);
        this.transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }



}
