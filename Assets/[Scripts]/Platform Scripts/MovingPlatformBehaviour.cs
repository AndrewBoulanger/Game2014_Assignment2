using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    Vector2 startPosition;
    [SerializeField]
    Vector2 MoveToPosition;

     float distance; 
    [SerializeField]
    float speed;

    float distanceReciprocal;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        MoveToPosition += startPosition;
        distance = Vector2.Distance(startPosition, MoveToPosition);
        distanceReciprocal = 1/distance;
    }

    // Update is called once per frame
    void Update()
    {
         float pingPongValue = Mathf.PingPong(Time.time * speed, distance);
        transform.position = Vector2.Lerp(startPosition, MoveToPosition, pingPongValue * distanceReciprocal);
    }
}
