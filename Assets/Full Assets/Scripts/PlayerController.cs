using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;

    public UnityEvent respawnPlayer;
    public float moveSpeed;
    public float jumpPower;
    private bool isFacingRight = true;
    private float horizontal;
    private Animator enemyAnimator;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate(){

        CheckMovement();
        CheckAnim();

    }

    //Recoge en animator de el enemigo 
    public void CheckAnim()
    {

        enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();


    }

    //Confirma el movimiento y la direccion del personaje principal
    public void CheckMovement()

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

    //Mueve el personaje principal
    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;

    }

    //Inicia la animacion de ataque
    public void Attack()
    {

        animator.SetBool("is Attacking", true);

    }

    //Finaliza la animacion de ataque
    public void StopAttack()
    {

        animator.SetBool("is Attacking", false);

    }

    //Realiza el salto si el personaje esta en contacto con el suelo, en caso contrario no salta
    public void Jump(){

        if (!CheckGround.isGrounded){

        
            animator.SetBool("is Jumping", true);

        }

        else 
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        }
        
    }

    //Reconoce el ataque de un enemigo(en caso de que el enemigo no haya muerto) o la caida del mapa y mata al personaje
    public void OnTriggerEnter2D(Collider2D other)
    {

        if ((other.gameObject.CompareTag("AreaAttack") && enemyAnimator.GetBool("is Attacking")) 
            || other.gameObject.CompareTag("DeathPit"))
        {
            Debug.Log("MuerteJugador");
            
            animator.SetTrigger("is Dead");

        }
        

    }

}
