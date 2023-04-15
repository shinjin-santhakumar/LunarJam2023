using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserE : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    // The velocity of the bullet.
    public Vector3 Velocity;

    public float BulletDmg;

    public Vector3 lastVelocity;


    private Camera mainCamera;
    public Vector2 widthThresold;
    public Vector2 heightThresold;


    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        // Move the bullet in the direction of our velocity.
        transform.position += Velocity * Time.deltaTime * FreezeTimer.Globalmovespeed;
        lastVelocity = Velocity;

        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
            Destroy(gameObject);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void ChangeBulletDmg(float x)
    {

        BulletDmg = x;

    }

    public void IncreaseBulletDmg(float x)
    {
        BulletDmg += x;
    }
}
