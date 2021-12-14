///////////////////////////////
/// ChaseBehaviour.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: base class for other chasing behaviours
/// 
/// v1: holds a target, functions include set target and set direction (abstract)
///
/// last modified: Dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChaseBehaviour : EnemyMovement
{
    protected Transform target;

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }
    

    protected abstract void SetDirection();
    
}
