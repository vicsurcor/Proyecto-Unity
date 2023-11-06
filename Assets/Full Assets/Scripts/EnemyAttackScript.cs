using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;


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
