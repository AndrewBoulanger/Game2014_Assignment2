using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBlock : MonoBehaviour
{
    bool destructionTriggered;
    [SerializeField]
    float animationLength;
    float timer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(destructionTriggered)
        { 
            RemoveBlock();
        }

    }

    //remove block after the animation finishes
    void RemoveBlock()
    {
        timer += Time.deltaTime;
        if (timer >= animationLength)
        { 
            transform.DetachChildren();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            destructionTriggered = true;
            animator.SetTrigger("BlockHit");
        }
    }
}
