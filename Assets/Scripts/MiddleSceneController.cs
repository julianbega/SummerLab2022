using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleSceneController : MonoBehaviour
{
    public SceneController controller;
    public void Start()
    {
        controller = FindObjectOfType<SceneController>();
    }
    public void ChangeSceneVertical(string scene)
    {
        controller.ChangeSceneVertical(scene);
    }
    public void ChangeSceneHorizontal(string scene)
    {
        controller.ChangeSceneHorizontal(scene);
    }
    public void ChangeSceneWithWaitSeconds(string scene)
    {
        controller.ChangeSceneWithWaitSeconds(scene);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        setVertical();
    }

    public void ExitGame()
    {
        controller.ExitGame();
    }
    void setVertical()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
