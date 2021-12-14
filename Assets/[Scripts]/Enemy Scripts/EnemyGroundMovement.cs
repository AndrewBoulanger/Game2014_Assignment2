///////////////////////////////
/// EnemyGroundMovement.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: patrol behaviour for ground-based enemies, moves back and forth, flipping direction when they hit something
/// 
/// v.1 enemy moves forward and uses linecasts to check for ledges and obstacles
/// v.2 now checks for enemies in the OnCollision events to avoid the linecast hitting itself
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMovement : EnemyMovement
{
    [Header("Movement")]
    public float runForce;
    public Transform CheckGroundPoint;
    public Transform lookInFrontPoint;
    public LayerMask platformLayerMask;
    public LayerMask obstacleLayerMask;
    public bool isGroundAhead;


    // Update is called once per frame
    void FixedUpdate()
    {
        LookForGround();
        LookInFront();
        MoveEnemy();

    }

    private void LookForGround()
    {
        //ground check
        var hit = Physics2D.Linecast(transform.position, CheckGroundPoint.position, platformLayerMask);
        isGroundAhead = (hit) ? true : false;
    }

    private void LookInFront()
    {
        var hit = Physics2D.Linecast(transform.position, lookInFrontPoint.position, obstacleLayerMask);
        if (hit)
        {
            Flip();
        }
    }

    protected override void MoveEnemy() 
    {
        if (isGroundAhead)
        {
            float mass = rigidbody.mass * rigidbody.gravityScale;
            Vector2 direction = (transform.localScale.x < 0) ? Vector2.right : Vector2.left;
            rigidbody.AddForce(direction * runForce * mass  );
            rigidbody.velocity *= 0.90f;
        }
        else
        {
            Flip();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform, true);
        }
        else if(collision.gameObject.CompareTag("Hazard"))
        {
            Flip();
        }
    }

}
