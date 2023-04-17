using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;

public class Boostbar : MonoBehaviour
{

    public Slider boostBar;

    private int maxBoost = 100;
    private float currBoost;

    public float boostForce;

    public static Boostbar instance;

    public Rigidbody2D rb;
    public Transform direction;

    private Coroutine regen;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currBoost = maxBoost;
        boostBar.maxValue = maxBoost;
        boostBar.value = maxBoost;
    }

    public void UseBoost()
    {
        
        if (currBoost >= 0)
        {
            currBoost -= 1;
            boostBar.value = currBoost;
            rb.AddForce(direction.up * boostForce);
            Debug.Log("Boosted");

            if(regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenBoost());

        }
    }

    public IEnumerator RegenBoost() 
    {
        //Debug.Log("Called RegenBoost");
        yield return new WaitForSeconds(3);
        //Debug.Log("currBoost: " + currBoost);
        //Debug.Log("maxBoost: " + maxBoost);
        while (currBoost < maxBoost)
        {

            currBoost += (float) maxBoost / 100;
            Debug.Log("increased boost by: " + maxBoost / 1000);
            boostBar.value = currBoost;
            yield return new WaitForSeconds(0.1f);
        }

        regen = null;
        
    }

    public void CheckRegen()
    {

        if (regen != null) {
            StopCoroutine(regen);
        }
        else {
            regen = StartCoroutine(RegenBoost());
        }

    }
}
