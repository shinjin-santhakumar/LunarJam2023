using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTimer : MonoBehaviour
{

    static public float Globalmovespeed;

    public float TimeLeft;

    public Text TimerTxt;

    private bool Frozen;

    private void Start()
    {
        Frozen = true;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }
        else
        {
            Debug.Log("Time is UP!");
            TimeLeft = 10;
        }
    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);

        if (Frozen)
        {
            TimerTxt.text = string.Format("{0} until Freeze", seconds);
            Globalmovespeed = 1;

            if (seconds == 0)
                Frozen = false;
        }
        else 
        {
            TimerTxt.text = string.Format("{0} until battle resumes", seconds);
            Globalmovespeed = 0;

            if (seconds == 0)
                Frozen = true;
        }
            
    }



}
