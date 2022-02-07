using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{       
    public void ChangeSceneVertical(string scene)    
    {
        SceneManager.LoadScene(scene);
        setVertical();
    }
    public void ChangeSceneHorizontal(string scene)
    {
        SceneManager.LoadScene(scene);
        setHorizontal();
    }
    public void ChangeSceneWithWaitSeconds(string scene)
    {
        StartCoroutine(WaitSecondsForChangeScene(2, scene));
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        setVertical();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitSecondsForChangeScene(int seconds, string scene)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
        yield return null;
    }

    void setHorizontal()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    void setVertical()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

}
