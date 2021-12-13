using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpedOnBehaviour : MonoBehaviour
{
    Animator animator;
    EdgeCollider2D topCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        topCollider = GetComponent<EdgeCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //squish enemy, make the player jump, let them fall through the floor into the death plane
        if (collision.gameObject.CompareTag("Player") && topCollider.IsTouching(collision))
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddJumpVelocity();
            GetComponent<CircleCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<EnemyGroundMovement>().enabled = false;
            animator.SetInteger("State", (int)EnemyAnimationStates.SQUISHED );
        }

    }
}
