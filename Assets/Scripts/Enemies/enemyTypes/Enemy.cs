using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    private Vector3 startingPoint;
    private Vector3 target;
    private Vector3 height;
    float count = 0.0f;
    
    void Start()
    {
        
        startingPoint = transform.position;
        target = new Vector3(Random.Range(-5f, 5f), Random.Range(-5.0f, 5.0f), 0);
        height = startingPoint + (target - startingPoint) / 2 + Vector3.up * 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 1.0f)
        {
            count += .5f * Time.deltaTime;

            Vector3 m1 = Vector3.Lerp(startingPoint, height, count);
            Vector3 m2 = Vector3.Lerp(height, target, count);
            transform.position = Vector3.Lerp(m1, m2, count);
        }
        else
        {
            count = 0;
            startingPoint = transform.position;
            target = new Vector3(Random.Range(-5f, 5f), Random.Range(-5.0f, 5.0f), 0);
            height = startingPoint + (target - startingPoint) / 2 + Vector3.up * 5.0f;
        }
    }
}
