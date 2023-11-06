using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprtRnd;
    public Animator animator;
    private bool isFacingRight = false;
    public Animator playerAnimator;

    public void FixedUpdate()
    {

        CheckMovement();
        
    }

        public void CheckMovement()
    {

        if (isFacingRight && rb.velocity.x < 0){

            sprtRnd.flipX = true;
            isFacingRight = false;

        }
        else if (!isFacingRight && rb.velocity.x > 0) {

            sprtRnd.flipX = false;
            isFacingRight = true;

        }

    }

    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("AttackRange") && playerAnimator.GetBool("is Attacking"))
        {

            animator.SetTrigger("Death");

        }
    }

    

    public void Despawn()
    {

        Destroy(gameObject);

    }

    
}
