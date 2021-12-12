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