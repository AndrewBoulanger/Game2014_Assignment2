///////////////////////////////
/// ButtonLevelOpener.cs
/// Author: Andrew Boulanger 101292574
/// 
/// description: allows buttons to load a scene when clicked. the scene to be loaded will be based on the object's tag
/// 
/// v.1 originally opened based on a separate enum and static class combination. abandoned because adding to the enum ruined the order.
/// v.2 opens a level based on the tag, with extra logic for the next level and replay options
///
//////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

//allows buttons to load a scene when clicked. the scene to be loaded will be based on the object's tag
public class ButtonLevelOpener : MonoBehaviour
{
    private Button button;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        if(button != null)
            button.onClick.AddListener(OnButtonPressed);
        else
            Debug.Log("This object is not a button.");

       
    }

    //loads scene based on the tag. NextScene tag will load the next level in the build order until it reaches the results screen.
    //*There is an expectation that the scenes are ordered correctly and followed by the results screen in the build settings
    private void OnButtonPressed()
    {
        string levelName = tag;

        if (levelName == "NextLevel")
        {
            //the next level button is only called on the results page, so if current index == next index you've run out of levels
            if(LevelResults.MostRecentLevel + 1  >= SceneManager.GetActiveScene().buildIndex)
                SceneManager.LoadScene("MainMenu");
            else
                SceneManager.LoadScene( LevelResults.MostRecentLevel + 1);
        }

        else if (levelName == "ReplayLast")
        {
            SceneManager.LoadScene( LevelResults.MostRecentLevel );
        }
        else
        {
            SceneManager.LoadScene(tag);
        }

    }

    private void OnDestroy()
    {
        if(button != null)
            button.onClick.RemoveAllListeners();
    }

}
