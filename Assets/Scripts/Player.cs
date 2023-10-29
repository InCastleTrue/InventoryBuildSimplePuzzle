using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1000.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementInput = new Vector2(horizontalInput, verticalInput);
        Vector2 movement = movementInput.normalized * moveSpeed * Time.deltaTime;

        rb.velocity = movement;
    }
}