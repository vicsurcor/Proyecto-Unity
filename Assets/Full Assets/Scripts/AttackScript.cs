using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;
    
    
    GameObject player;
    // Start is called before the first frame update


    public void FixedUpdate()
    {
        
        

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!animator.GetBool("Death 0"))
        {

            if (other.gameObject.CompareTag("Player"))
            {
                player = GameObject.FindGameObjectWithTag("Player");
                Move();
                
            }

        }

        

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!animator.GetBool("Death 0"))
        {

            if (other.gameObject.CompareTag("Player"))
            {

                animator.SetBool("sees Player", false);

            }
        }
    }
    public void Move()
    {

        if (!animator.GetBool("Death 0"))
        {
            animator.SetBool("sees Player", true);

            Debug.Log("Vision de Jugador");
            Vector2 direction = new Vector2(player.transform.position.x - (-1 + transform.position.x),rb.velocity.y);
            rb.velocity = direction;
        
        }

    }
}
