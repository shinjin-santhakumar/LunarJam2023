using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 target;
    private Vector3 position;
    private Vector3 direction;
    GameObject Player;
    Rigidbody2D rb;
    public Vector3 offset;


    float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        position = transform.position;
        target = Player.transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction_angle = ((target + offset) - position).normalized;
        angle = Mathf.Atan2(direction_angle.y, direction_angle.x) * Mathf.Rad2Deg * FreezeTimer.Globalmovespeed;
        
        rb.rotation = angle;
       
        rb.velocity = direction_angle * speed * FreezeTimer.Globalmovespeed;

        Object.Destroy(gameObject, 20.0f);
    }

    
}