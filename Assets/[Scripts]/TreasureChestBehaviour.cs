///////////////////////////////
/// TreasureChestBehaviour.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: lets other classes know when the chest has been reached
/// 
/// v.1 unityEvent is evoked when the chest is collided with, invoke informs the LevelManager to change the scene
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreasureChestBehaviour : MonoBehaviour
{
     public UnityEvent OnChestReached;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnChestReached.Invoke();
        }
    }

}
