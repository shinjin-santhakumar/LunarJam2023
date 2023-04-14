using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    public GameObject meteor;
    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    private bool ShotMeteor = false;

    public void Update()
    {
        Debug.Log(ShotMeteor);
        if (ShotMeteor == false)
        {
            StartCoroutine(Cooldown());
        }
        
    }
    IEnumerator Cooldown()
    {
        ShotMeteor = true;
        
        yield return new WaitForSeconds(5f);
        SpawnMeteor();
        ShotMeteor = false;
    }


    void SpawnMeteor()
    {
        //random position
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Instantiate(meteor, pos, transform.rotation);
    }
}
