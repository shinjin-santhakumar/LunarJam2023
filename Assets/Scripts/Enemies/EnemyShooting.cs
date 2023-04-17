using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;

    public Transform firepoint;
    public Transform firepoint2;

    private bool hasFired;
    private bool isVisible = false;

    [SerializeField] private AudioSource enemySound;

    public void Start()
    {
        
    }
    private void Update()
    {
        if (isVisible && FreezeTimer.Globalmovespeed > 0)
        {
            if (hasFired == false)
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
        enemySound.Play();
        hasFired = true;
        GameObject laser1 = Instantiate(laser, firepoint.position, firepoint.rotation);
        yield return new WaitForSeconds(5f);
        hasFired = false;
    }

}
