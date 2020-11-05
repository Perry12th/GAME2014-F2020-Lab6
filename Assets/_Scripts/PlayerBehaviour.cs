using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float joystickSensitivity;
    public float horizontalForce;
    public float jumpforce;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }
    private void _Move()
    {
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickSensitivity)
            {
                // move to right
                rigidbody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = false;
                animator.SetInteger("AnimState", 1);
                //Debug.Log("Move right");

            }

            else if (joystick.Horizontal < -joystickSensitivity)
            {
                // move to left
                rigidbody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = true;
                animator.SetInteger("AnimState", 1);
                //Debug.Log("Move left");
            }

            else if (joystick.Vertical > joystickSensitivity)
            {
                // jump
                rigidbody2D.AddForce(Vector2.up * jumpforce * Time.deltaTime);
                Debug.Log("Jump");
            }

            else
            {
                animator.SetInteger("AnimState", 0);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;  
    }
    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
