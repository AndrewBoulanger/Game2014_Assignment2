using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlockController : MonoBehaviour
{
    Transform spikes;
    Vector3 startPosition, moveToPosition;
    [SerializeField]
    float distance, speed;

    bool isActivated = false;
    float distanceOffset = 0.1f;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spikes = transform.GetChild(0);
        startPosition = spikes.position;
        moveToPosition = Vector3.up * distance + startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated)
        {
            timer+= Time.deltaTime;
            MoveSpikes();
        }
    }

    void MoveSpikes()
    {
        float pingPongValue = Mathf.PingPong(timer * speed, distance);
        spikes.position = new Vector2(startPosition.x, startPosition.y + pingPongValue);

        if(timer * speed >= distance * 2)
        { 
            isActivated = false;
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isActivated = true;
        }
    }
}
