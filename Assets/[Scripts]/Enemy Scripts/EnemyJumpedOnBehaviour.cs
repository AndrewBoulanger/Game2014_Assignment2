///////////////////////////////
/// EnemyJumpedOnBehaviour.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: attached to enemies that can be beaten when jumped on, checks for it and changes behaviour when it happens 
/// 
/// v.1 changes animation state and disables collision
/// v.2 didnt intend to make it fall through the floor, but i think its funny so im keeping it. also disabled movement classes and added a 
/// jump to the player.
///
/// last modified: dec 13th 2021
//////////////////////////////

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
            gameObject.tag = "Enemy";
            GetComponent<CircleCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().gravityScale = 3;
            foreach (EnemyMovement m in GetComponents<EnemyMovement>())
            {
                m.enabled = false;
            }
            animator.SetInteger("State", (int)EnemyAnimationStates.SQUISHED );
        }

    }
}
