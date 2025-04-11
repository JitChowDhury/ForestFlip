using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        PlayMovementAnim(horizontalInput);
        MoveCharacter(horizontalInput);
    }

    private void MoveCharacter(float horizontalInput)
    {
        Vector3 position = transform.position;
        position.x += horizontalInput * Speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnim(float horizontalInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;
        if (horizontalInput < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}
