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
