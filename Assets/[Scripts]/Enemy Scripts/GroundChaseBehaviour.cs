using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChaseBehaviour : ChaseBehaviour
{
    [SerializeField]
    float runForce;

    //set by SetDirection(), will be either vector2.left or right 
    Vector2 targetDirection;

    [SerializeField]
    float targetOvercorrection = 1f;

    private void FixedUpdate()
    {
        if(target != null)
        {
            SetDirection();
            MoveEnemy();
        }
    }

    //moves the enemy in the direction set by SetDirection()
    protected override void MoveEnemy()
    {
        float mass = rigidbody.mass * rigidbody.gravityScale;
        rigidbody.AddForce(targetDirection * runForce * mass);
        rigidbody.velocity *= 0.90f;
    }


    //set the direction to move in based on the target position, flips the target if its changed
    protected override void SetDirection()
    {
        float distance = transform.position.x - target.position.x;
        Vector2 newDirection = (distance > 0) ? Vector2.left : Vector2.right;

        if(newDirection != targetDirection && Mathf.Abs(distance ) > targetOvercorrection )
        {
            targetDirection = newDirection;

            if(Mathf.Sign(distance) != Mathf.Sign(transform.localScale.x))
                Flip();
        }

    }
}
