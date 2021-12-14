using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingChaseBehaviour : ChaseBehaviour
{
    [SerializeField]
    float moveSpeed;


    [SerializeField]
    float minDistance = 0.1f;

    Vector2 distance;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        { 
            SetDirection();
            MoveEnemy();
        }
    }

    protected override void MoveEnemy()
    {
        rigidbody.AddForce(distance.normalized * moveSpeed * rigidbody.mass);
        rigidbody.velocity *= 0.90f;
    }
    protected override void SetDirection()
    {
        distance = target.position - transform.position;

        if (Mathf.Sign(distance.x) == Mathf.Sign(transform.localScale.x))
            Flip();

    }

    
}
