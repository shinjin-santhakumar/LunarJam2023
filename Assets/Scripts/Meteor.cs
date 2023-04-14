using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 1f;
    public float rotation_speed = .2f;
    private Vector2 target;
    private Vector2 position;
    private Vector2 direction;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        position = transform.position;
        target = Player.transform.position;
        direction = target - position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
        transform.Rotate(0, 0, 360 * rotation_speed * Time.deltaTime);
        Object.Destroy(gameObject, 5.0f);
    }
}
