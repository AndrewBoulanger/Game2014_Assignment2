using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilEnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    LOS lineOfSight;

    [SerializeField]
    Transform lookAhead;

    GameObject chaseTarget;

    [SerializeField]
    EnemyMovement normalMovement;

    [SerializeField]
    ChaseBehaviour chaseMovement;

    [SerializeField]
    float stopChasingDistance;



    bool chasing;


    // Update is called once per frame
    void Update()
    {
        if(chasing)
        {
            float distance = Vector2.Distance(transform.position, chaseTarget.transform.position);
            if(distance > stopChasingDistance)
                SetChaseModeActive(false);
        }
        else
        {
            if (HasLOS())
            {
                SetChaseModeActive(true);
            }
        }
    }

    private bool HasLOS()
    {
        if (lineOfSight.colliderList.Count > 0)
        {
            if (lineOfSight.collidesWith.gameObject.CompareTag("Player") &&
                lineOfSight.colliderList[0].gameObject.CompareTag("Player"))
            {
                chaseTarget = lineOfSight.colliderList[0].gameObject;
                return true;
            }
            else
            {
                foreach (var collider in lineOfSight.colliderList)
                {
                    if (collider.gameObject.CompareTag("Player"))
                    {
                        var hit = Physics2D.Raycast(lookAhead.position, Vector3.Normalize(collider.transform.position - lookAhead.position), 5.0f, lineOfSight.contactFilter.layerMask);

                        if ((hit) && (hit.collider.gameObject.CompareTag("Player")))
                        {
                            chaseTarget = hit.collider.gameObject; 
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    //enable chase mode, or set false to return to normal movement
    void SetChaseModeActive(bool isActive)
    {
        chasing = isActive;
        chaseMovement.enabled = isActive;
        normalMovement.enabled = !isActive;
        if(isActive == true)
            chaseMovement.SetTarget(chaseTarget.transform);

    }
}
