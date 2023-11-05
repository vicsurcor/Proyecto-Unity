using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;
    public float moveSpeed;
    public float jumpPower;
    private bool isFacingRight = true;
    private float horizontal;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate(){

        checkMovement();

    }

    public void checkMovement()

    {

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (CheckGround.isGrounded){

            animator.SetBool("is Jumping", false);

        }

        if (Math.Abs(horizontal) != 0f){

            animator.SetBool("is Running", true);

        }
        else{

            animator.SetBool("is Running", false);

        }

        if (isFacingRight && horizontal < 0f){

            sprtRnd.flipX = true;
            isFacingRight = false;

        }
        else if (!isFacingRight && horizontal > 0f) {

            sprtRnd.flipX = false;
            isFacingRight = true;

        }

    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;

    }

    public void Jump(){

        if (!CheckGround.isGrounded){

        
            animator.SetBool("is Jumping", true);

        }

        else 
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        }
    }
}
