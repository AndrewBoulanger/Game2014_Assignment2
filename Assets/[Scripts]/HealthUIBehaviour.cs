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
