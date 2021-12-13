using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMovement : MonoBehaviour
{
    [Header("Movement")]
    public float runForce;
    public Transform CheckGroundPoint;
    public Transform lookInFrontPoint;
    public LayerMask platformLayerMask;
    public bool isGroundAhead;

    Rigidbody2D rigidbody;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        LookInFront();
        MoveEnemy();

    }

    private void LookAhead()
    {
        //ground check
        var hit = Physics2D.Linecast(transform.position, CheckGroundPoint.position, platformLayerMask);
        isGroundAhead = (hit) ? true : false;
        print(isGroundAhead);
    }

    private void LookInFront()
    {
        var hit = Physics2D.Linecast(transform.position, lookInFrontPoint.position, platformLayerMask);
        if (hit)
        {
            Flip();
        }
    }

    private void MoveEnemy()
    {
        if (isGroundAhead)
        {
            rigidbody.AddForce(Vector2.left * runForce * transform.localScale.x);
            rigidbody.velocity *= 0.90f;
        }
        else
        {
            Flip();
        }

        animator.SetInteger("State", (int)EnemyAnimationStates.MOVING);

    }
    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
