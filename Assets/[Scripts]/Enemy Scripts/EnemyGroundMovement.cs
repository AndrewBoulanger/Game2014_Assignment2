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
