using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesShotgun : MonoBehaviour
{
    public GameObject DefaultEnemy;
    // the range of X
    float minX;
    float maxX;
    float minY;
    float maxY;

    private bool EnemySpawn = false;
    private float randomSide;
    public float randomTime;
    Dictionary<string, float[]> side = new Dictionary<string, float[]>()
        {
        // xMin xMax yMin yMax
         {"top", new float[] {-50,50,60,60} },
         {"bottom", new float[] {-50,50,-60,-60} },
         {"left", new float[] {-60,-60,-50,50} },
         {"right", new float[] {60,60,-50,50} },
        };
    private void Start()
    {

    }
    public void Update()
    {
        if (EnemySpawn == false)
        {
            randomSide = Random.Range(0, 3);
            switch (randomSide)
            {
                case 0:
                    minX = side["top"][0];
                    maxX = side["top"][1];
                    minY = side["top"][2];
                    maxY = side["top"][3];
                    break;
                case 1:
                    minX = side["bottom"][0];
                    maxX = side["bottom"][1];
                    minY = side["bottom"][2];
                    maxY = side["bottom"][3];

                    break;
                case 2:
                    minX = side["left"][0];
                    maxX = side["left"][1];
                    minY = side["left"][2];
                    maxY = side["left"][3];
                    // code block
                    break;
                case 3:
                    minX = side["right"][0];
                    maxX = side["right"][1];
                    minY = side["right"][2];
                    maxY = side["right"][3];
                    // code block
                    break;

            }

            StartCoroutine(Cooldown(minX, maxX, minY, maxY));
        }
    }
    IEnumerator Cooldown(float xMin, float xMax, float yMin, float yMax)
    {
        EnemySpawn = true;
        randomTime = Random.Range(5, 7);
        yield return new WaitForSeconds(randomTime);
        SpawnMeteor(xMin, xMax, yMin, yMax);
        EnemySpawn = false;
    }
    


    void SpawnMeteor(float xMin, float xMax, float yMin, float yMax)
    {
        //random position
        if (FreezeTimer.Globalmovespeed > 0)
        {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(DefaultEnemy, pos, transform.rotation);
        }
        // Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        // Instantiate(DefaultEnemy, pos, transform.rotation);
    }
}
