using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float speed = 1f;
    public float rotation_speed = .2f;
    private Vector2 target;
    private Vector2 position;
    private Vector2 direction;
    private Vector2 offset;
    private float MeteorHp = 2f;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        position = transform.position;
        target = Player.transform.position;
        offset = new Vector2(Random.Range(-50,50), Random.Range(-50,50));
        direction = target + offset - position;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(.2f, 1);
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed * FreezeTimer.Globalmovespeed;
        transform.Rotate(0, 0, 360 * rotation_speed * Time.deltaTime);
        if (MeteorHp == 0)
        {
            Destroy(gameObject);
           
        }
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Laser")){
    //         Destroy(collision.gameObject);
    //         MeteorHp -= 1;
    //     }

    // }

    private void timeToDie()
    {
        Destroy(gameObject);
    }

}
