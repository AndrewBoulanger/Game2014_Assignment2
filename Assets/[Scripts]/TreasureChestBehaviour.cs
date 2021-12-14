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

    public void AddListerner(UnityAction call)
    {
        OnChestReached.AddListener(call);
    }

}
