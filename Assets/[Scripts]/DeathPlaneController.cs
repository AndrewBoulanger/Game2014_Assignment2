///////////////////////////////
/// DeathPlaneController.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: determines what to do with things that fall off the level
/// 
/// v.1 players are returned to the spawn point, enemies are disabled
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public Transform playerSpawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (playerSpawnPoint != null)
            {
                collision.transform.position = playerSpawnPoint.position;
                collision.rigidbody.velocity = Vector2.zero;
            }
            else
            {
                Debug.Log("the spawn point has not been set, or the reference has been lost");
            }

        }
        else
        {
            collision.gameObject.SetActive(false);
        }
    }


    //if anything falls into it that isnt the player, and has a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
