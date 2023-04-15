using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunEnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    public Transform firepoint;

    private bool hasFired;
    private bool isVisible = false;
    EnemyLaser Script;

    public void Start()
    {
        Script = laser.GetComponent<EnemyLaser>();
    }
    private void Update()
    {
        if (isVisible)
        {
            if (hasFired == false && FreezeTimer.Globalmovespeed > 0)
            {
                StartCoroutine(SpawnLasers());
            }
        }

    }
    void OnBecameVisible()
    {
        isVisible = true;
    }

    IEnumerator SpawnLasers()
    {
        Debug.Log("sdfsd");
        hasFired = true;
        Script.offset = new Vector3(7,7,0);
        Instantiate(laser, firepoint.position, firepoint.rotation);
        Script.offset = new Vector3(13, 13, 0);
        Instantiate(laser, firepoint.position, firepoint.rotation);
        Script.offset = new Vector3(-7, -7, 0);
        Instantiate(laser, firepoint.position, firepoint.rotation);
        Script.offset = new Vector3(-13, -13, 0);
        Instantiate(laser, firepoint.position, firepoint.rotation);
        Script.offset = new Vector3(0, 0, 0);
        Instantiate(laser, firepoint.position, firepoint.rotation);
        yield return new WaitForSeconds(5f);
        hasFired = false;
    }


}
