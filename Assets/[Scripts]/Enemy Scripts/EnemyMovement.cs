///////////////////////////////
/// EnemyMovement.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: baseClass to all enemy movement
/// 
/// v.1 gets rigidbody and animator, has the flip function and an abstract Move Enemy
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{

    protected Rigidbody2D rigidbody;
    protected Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    protected abstract void MoveEnemy();


    protected void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
