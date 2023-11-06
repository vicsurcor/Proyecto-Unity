using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;
    private bool isFacingRight = false;
    GameObject player;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (other.gameObject.CompareTag("Player"))
        {
            CheckMovement();
            Move();

        }

    }
    public void CheckMovement()
    {

        if (isFacingRight && rb.velocity.x < 0f){

            sprtRnd.flipX = true;
            isFacingRight = false;

        }
        else if (!isFacingRight && rb.velocity.x > 0f) {

            sprtRnd.flipX = false;
            isFacingRight = true;

        }

    }

    

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            animator.SetBool("sees Player", false);

        }

    }
    public void Move()
    {
        animator.SetBool("sees Player", true);

        Debug.Log("Vision de Jugador");
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x,rb.velocity.y);
        rb.velocity = direction;
        

    }
}
