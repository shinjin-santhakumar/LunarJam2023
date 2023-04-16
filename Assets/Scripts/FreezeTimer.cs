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

    public GameObject player;

    public GameObject freezeSquare;
    private Image img;
    private bool justFroze;
    private float speed;

    private void Start()
    {
        Frozen = true;
        justFroze = false;
        speed = .5f;
        img = freezeSquare.GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        Debug.Log(justFroze);
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }
        else
        {
            //Debug.Log("Time is UP!");
            TimeLeft = 10;
        }
        if (justFroze == true)
        {
            Debug.Log(img.color.a);
            img.enabled = true;
            if (img.color.a - speed * Time.deltaTime > 0)
            {
                img.color = new Color(img.color.r, img.color.b, img.color.g, img.color.a - speed * Time.deltaTime);
            }
            //img.color = new Color(img.color.r, img.color.b, img.color.g, img.color.a - speed * Time.deltaTime);
        }
    }


    void updateTimer(float currentTime)
    {
        if (player.GetComponent<PlayerLife>().health == 0)
        {
            Globalmovespeed = 0;
            return;
        }
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);

        if (Frozen)
        {
            TimerTxt.text = string.Format("{0}", seconds);
            Globalmovespeed = 1;

            if (seconds == 0)
            {
                Frozen = false;
                justFroze = true;
                img.enabled = false;
                img.color = new Color(img.color.r, img.color.b, img.color.g, .39f);
            }
                
        }
        else 
        {
            TimerTxt.text = string.Format("{0}", seconds);
            Globalmovespeed = 0;

            if (seconds == 0)
            {
                Frozen = true;
                justFroze = false;
                //img.color.a = 100;
            }
                //Frozen = true;
        }
            
    }



}
