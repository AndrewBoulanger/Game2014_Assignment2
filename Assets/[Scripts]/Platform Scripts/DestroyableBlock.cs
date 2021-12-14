///////////////////////////////
/// DestroyableBlock.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: animates and destroys block when hit from below (via an edge collider)
/// 
/// v.1 plays animation on collision and removes the block when done
/// v.2 plays sound effect too
///
/// last modified: dec 13th 2021
//////////////////////////////

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
    static AudioSource sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
        sfxPlayer = GetComponent<AudioSource>();
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
            sfxPlayer.Play();
        }
    }
}
