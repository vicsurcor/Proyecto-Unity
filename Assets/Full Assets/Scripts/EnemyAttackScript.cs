using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;


    //Reconoce que el jugador esta en rango de ataque, realiza el ataque(si no ha muerto)
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (!animator.GetBool("Death 0"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                animator.SetBool("is Attacking", true);
            }
        }

    }

    //Reconoce que el jugador está fuera de rango de ataque, deja de atacar
    public void OnTriggerExit2D(Collider2D other)
    {

        if (!animator.GetBool("Death 0"))
        {

            if (other.gameObject.CompareTag("Player"))
            {
                animator.SetBool("is Attacking", false);
            }
        }
        
    }
}
