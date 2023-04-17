using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject RangedEnemy;
    public GameObject DefaultEnemy;
    public GameObject ShotgunEnemy;

    public GameObject TurretEnemy;
    // the range of X
    float minX;
    float maxX;
    float minY;
    float maxY;
    Vector2 pos;

    private bool EnemySpawn = false;
    private float randomSide;
    private float randWave;
    private float WaveCooldown = 10;
    private bool difficulty = false;
    Dictionary<string, float[]> side = new Dictionary<string, float[]>()
        {
        // xMin xMax yMin yMax
         {"top", new float[] {-50,50,60,60} },
         {"bottom", new float[] {-50,50,-60,-60} },
         {"left", new float[] {-60,-60,-50,50} },
         {"right", new float[] {60,60,-50,50} },
        };
   private void Start() {
        
   }
   IEnumerator wait(){
    difficulty = true;
    yield return new WaitForSeconds(30);
    WaveCooldown = WaveCooldown - .3f;
    Debug.Log(WaveCooldown);
    difficulty = false;
   }
    public void getRandPos(){
        randomSide = Random.Range(0, 4);
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
    }
    public void Update()
    {
        
        if (EnemySpawn == false)
        {
            StartCoroutine(Cooldown());
        }
        if (difficulty == false && WaveCooldown > 6){
            StartCoroutine(wait());
        }
        
    }
    IEnumerator Cooldown()
    {
        EnemySpawn = true;
        randWave = Random.Range(0, 4);
        switch(randWave) 
            {
                case 0:
                SpawnRangedEnemy();
                break;
                case 1:
                // code block
                SpawnShotgunEnemy();
                break;
                case 2:
                SpawnDefaultEnemy();
                break;
                case 3:
                SpawnTurretEnemy();
                break;
            
                
                
            }
        yield return new WaitForSeconds(WaveCooldown);
        EnemySpawn = false;
    }



   
    void SpawnRangedEnemy()
    {
        
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(RangedEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(RangedEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(RangedEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(RangedEnemy, pos, transform.rotation);
        
    }
    void SpawnDefaultEnemy()
    {
        
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(DefaultEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(DefaultEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(DefaultEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(DefaultEnemy, pos, transform.rotation);
        
    }
    
    void SpawnShotgunEnemy()
    {
       
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(ShotgunEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(ShotgunEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(ShotgunEnemy, pos, transform.rotation);
            getRandPos();
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(ShotgunEnemy, pos, transform.rotation);
        
    }

    void SpawnTurretEnemy()
    {

        pos = new Vector2(45, Random.Range(-50, -75));
        Instantiate(TurretEnemy, pos, transform.rotation);

        pos = new Vector2(-45, Random.Range(50, 75));
        Instantiate(TurretEnemy, pos, transform.rotation);

    }
    
}
