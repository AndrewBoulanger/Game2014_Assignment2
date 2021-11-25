///////////////////////////////
/// LevelResults.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: static class for saving level results (coins and time passed) and which level was just accessed.
/// 
/// v.1 saves coins and playtime
///
//////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//saves most recent level data
public static class LevelResults
{
    static float playTime;
    static int coinTotal;
    static int mostRecentLevel;

    public static float EndTime{get => playTime;}
    public static int Coins{get => coinTotal;}
    public static int MostRecentLevel
    { get => mostRecentLevel; set => mostRecentLevel = value; }


    //called at the end of the level. saves time passed and coins collected
    public static void SetResults(float time, int coins)
    {
        playTime = time;
        coinTotal = coins; 
        
    }
}
