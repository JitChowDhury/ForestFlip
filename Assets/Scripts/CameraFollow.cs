using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject Player;
    private float lastXPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, this.transform.position.z);
       
    }
}
