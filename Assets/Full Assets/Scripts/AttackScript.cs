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


    //Reconoce que el jugador es visible por el enemigo, se mueve hacia el(mientras no este muerto)
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

    //Reconoce que el jugador esta fuera del rango de vision del enemigo, deja de moverse(si no esta muerto)
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

    //Mueve al enemigo hacia el jugador(mientras no este muerto)
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
