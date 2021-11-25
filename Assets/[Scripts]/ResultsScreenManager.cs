///////////////////////////////
/// ResultsScreenManager.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: updates results and game over screen text when they're opened
/// 
/// v.1 changes the text of the coins and time passed texts. time is formatted to display minutes and seconds
///
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//updates UI for the results and game over screen, setting the coins and time passed
public class ResultsScreenManager : MonoBehaviour
{
    [SerializeField]
    Text  coinsText, timeText;

    // Start is called before the first frame update
    void Awake()
    {
        coinsText.text = "Coins: " + LevelResults.Coins.ToString();
        int time = (int)LevelResults.EndTime;
        timeText.text = string.Format( "Play Time: {0}:{1:00}", time/60, time%60);
    }

}
