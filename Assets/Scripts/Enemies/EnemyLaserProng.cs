using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserProng : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 target;
    private Vector3 position;
    private Vector3 direction;
    GameObject Player;
    Rigidbody2D rb;
    float angle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        position = transform.position;
        target = Player.transform.position;
        direction = target - position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction_angle = (target - position).normalized;
        angle = Mathf.Atan2(direction_angle.y, direction_angle.x) * Mathf.Rad2Deg * FreezeTimer.Globalmovespeed;
        rb.rotation = angle;
        rb.velocity = direction * speed;
        Object.Destroy(gameObject, 5.0f);
    }
}