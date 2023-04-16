using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
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

    public bool scale;


    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        // Move the bullet in the direction of our velocity.
        if (scale == false){
            transform.localScale = new Vector3(2, 5, 0);
        }
        else{
            transform.localScale = new Vector3(.75f, 3, 0);
        }
        
        transform.position += Velocity * Time.deltaTime * FreezeTimer.Globalmovespeed;
        lastVelocity = Velocity;


        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        // Debug.Log("x:" + screenPosition.x);
        // Debug.Log("y:" + screenPosition.y);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
            Destroy(gameObject);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("coll");
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("death");
            Destroy(gameObject);
        }
        
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
