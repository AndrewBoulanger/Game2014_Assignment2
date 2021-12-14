///////////////////////////////
/// EnemyFlyingMovement.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: patrol behaviour for flying enemies, moves between set points
/// 
/// v.1 enemy moves from point to point, returns to first point when they reach the end of the patrol points list
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingMovement : EnemyMovement
{
    [SerializeField]
    float moveSpeed;

    Vector3 startingPos;
    [SerializeField]
    List<Vector3> moveToPositions;
    int positionIndex;

    [SerializeField]
    float minDistance = 0.1f;

    Vector2 direction;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = (moveToPositions[positionIndex] + startingPos) - transform.position;

        if (Mathf.Sign(direction.x) == Mathf.Sign(transform.localScale.x))
            Flip();

        MoveEnemy();
    }

    protected override void MoveEnemy()
    {

        if ( direction.sqrMagnitude <= minDistance * minDistance )
        {
            IncrementPositionIndex();
        }

        rigidbody.AddForce(direction.normalized * moveSpeed * rigidbody.mass);
         rigidbody.velocity *= 0.90f;
        
    }

    void IncrementPositionIndex()
    {
        positionIndex++;
        if(positionIndex >= moveToPositions.Count)
            positionIndex = 0;
    }

    private void OnEnable()
    {
        direction = (moveToPositions[positionIndex] + startingPos) - transform.position;
  
    }
}
