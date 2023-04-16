using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static float GameScore = 0f;

    public GameObject ScoreBox;

    private void FixedUpdate()
    {

        if (GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().enabled == true) 
            GameScore += Time.deltaTime * 10f; // 10 points per second survived

        this.GetComponent<Text>().text = "Score: " + Mathf.Round(GameScore).ToString();

    }
}
