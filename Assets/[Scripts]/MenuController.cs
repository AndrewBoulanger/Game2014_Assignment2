using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button StartButton;
    [SerializeField]
    private Button TutorialButton;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonPressed);
        TutorialButton.onClick.AddListener(OnTutorialButtonPressed);
    }


    private void OnStartButtonPressed()
    {
        SceneManager.LoadScene(LevelNames.Level1);
    }

    private void OnTutorialButtonPressed()
    {
        SceneManager.LoadScene(LevelNames.Tutorial);
    }

}
