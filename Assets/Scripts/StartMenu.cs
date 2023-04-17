using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private AudioSource selectSound;
    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(Loading());
        SceneManager.LoadScene(1);
    }

    public void StartRules()
    {
        //StartCoroutine(Loading());
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        //StartCoroutine(Loading());
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        //StartCoroutine(Loading());
        Cursor.visible = true;
        Score.GameScore = 0;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        //StartCoroutine(Loading());
        Score.GameScore = 0;
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        //StartCoroutine(Loading());
        SceneManager.LoadScene(3);
    }

    IEnumerator Loading()
    {
        selectSound.Play();
        yield return new WaitForSeconds(10f);
    }
}
