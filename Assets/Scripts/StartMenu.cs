using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartRules()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        Cursor.visible = true;
        Score.GameScore = 0;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Score.GameScore = 0;
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
}