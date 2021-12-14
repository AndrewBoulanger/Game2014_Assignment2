///////////////////////////////
/// LOS.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: line of sight data used by enemy AI classes
/// 
/// v.1 keeps track of los collision with the player in other classes (namely the AIStrategy class)
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOS : MonoBehaviour
{
    [Header("Detection Properties")]
    public Collider2D collidesWith;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliderList;

    private PolygonCollider2D LOSCollider;

    // Start is called before the first frame update
    void Start()
    {
        LOSCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.GetContacts(LOSCollider, contactFilter, colliderList);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidesWith = collision;
    }
}
