using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Инициализация компонента RigidBody2D
    }

    void FixedUpdate()
    {
        transform.Translate(speedX, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void LeftButtonDown() {
        speedX = -horizontalSpeed;
    }

    public void RightButtonDown()
    {
        speedX = horizontalSpeed;
    }

    public void JumpButtonDown() {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
    }

}
