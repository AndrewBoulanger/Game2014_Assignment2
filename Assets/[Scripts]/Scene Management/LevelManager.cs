///////////////////////////////
/// LevelManger.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: Updates UI, watches player and timer to see if the level has ended, passes info to the levelResults
/// and moves to the next level when this one ends (game over or results)
/// 
/// v.1 added scene transitions to be called when the game ends and a timer to end the game when it runs out. 
///
/// last modified: nov 24th 2021
//////////////////////////////




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
///exists in every level to handle UI and sceneManagement
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField]
    float startTimeInMinutes;
    float startTimeInSeconds;
    float timeRemainingInSeconds;
    float timeUpdateTimer = 0;

    [SerializeField]
    Text gameTimerText;

    int coins = 0;

    [SerializeField]
    GameObject player, pawnPoint;

    private void Awake()
    {
        startTimeInSeconds = (int)startTimeInMinutes * 60 + (int)(startTimeInMinutes % 1 * 100);
        timeRemainingInSeconds = startTimeInSeconds;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelResults.MostRecentLevel = SceneManager.GetActiveScene().buildIndex;
    }


    private void Update()
    {
        UpdateTimer();
    }

    //update timer every second and check if time has run out
    void UpdateTimer()
    {
        timeUpdateTimer += Time.deltaTime;
        if (timeUpdateTimer >= 1.0f)
        {
            timeRemainingInSeconds -= timeUpdateTimer;
            timeUpdateTimer = 0;
            int time = (int)timeRemainingInSeconds;
            gameTimerText.text = string.Format( "{0}:{1:00}", time/60, time%60);
        }

        if(timeRemainingInSeconds <= 0f)
        {
            LevelHasEnded(false);
        }

    }


    //update LevelResults class and load either the results screen or the game over screen 
    void LevelHasEnded(bool won)
    {
        LevelResults.SetResults(startTimeInSeconds - timeRemainingInSeconds, coins);

        string sceneToLoad = (won) ? "ResultsScreen" : "GameOver";
        SceneManager.LoadScene(sceneToLoad);
    }
    
}
