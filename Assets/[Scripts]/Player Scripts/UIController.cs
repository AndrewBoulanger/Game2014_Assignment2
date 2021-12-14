///////////////////////////////
/// UIController.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: used to determine if the jump button has been pressed, so other classes (i.e playerMovement) 
/// can receive jump input from the virtual button;
/// 
/// v.1 static bool set but unity events
///
/// last modified: dec 13th 2021
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static bool jumpbuttonDown;

    //event functions
    public void OnJumpButton_Down()
    {
        jumpbuttonDown = true;
    }

    public void OnJumpButton_Up()
    {
        jumpbuttonDown = false;
    }
}