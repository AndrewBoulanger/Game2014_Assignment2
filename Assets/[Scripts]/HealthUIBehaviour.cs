///////////////////////////////
/// HealthUIBehaviour.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: adds/removes hearts based on health
/// 
/// v.1 enables or disables heart images based on health and the spot in the array
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    [SerializeField]
    Image[] hearts;

    public void UpdateHeartContainers(int health)
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }

    }
    
}
