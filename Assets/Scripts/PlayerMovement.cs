using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector2 direction = (mousePosition - transform.position).normalized;

            if (direction.x < 0)
            {
                transform.localScale = new Vector2(-0.687263f, 0.6657676f);

            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector2(0.687263f, 0.6657676f);
            }
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        }
    }
}

