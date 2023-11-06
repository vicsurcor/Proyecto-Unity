using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;
    public Animator playerAnimator;

    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            animator.SetBool("Attacking", true);

        }
        else if (other.gameObject.CompareTag("PlayerRange") && playerAnimator.GetBool("is Attacking"))
        {

            animator.SetTrigger("Death");


        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            animator.SetBool("Attacking", false);

        }

    }

    public void Despawn()
    {

        Destroy(gameObject);

    }

    
}
