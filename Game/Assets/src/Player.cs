using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    
    private bool isJumping;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontal= Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if(horizontal > 0f || horizontal < 0f)
        {
            Animator.SetBool("walk", true);
            if(horizontal > 0f)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            } else {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {
            Animator.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            Animator.SetBool("jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            Animator.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}

