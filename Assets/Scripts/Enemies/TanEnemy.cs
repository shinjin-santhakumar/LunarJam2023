using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // speed of movement
    public GameObject bulletPrefab; // prefab of the bullet
    public float fireRate = 0.5f; // delay between shots
    private float nextFire = 0.0f; // time of next shot
    public float distance = 60f; // distance to move back and forth
    private Vector3 startPosition; // starting position
    private Vector3 endPosition; // end position
    private bool movingForward = true; // direction of movement
    public float fireForce;

    void Start()
    {
        // set the starting and end positions
        //startPosition = transform.position;
        //endPosition = transform.position + new Vector3(distance, 0f, 0f);
    }

    void Update()
    {
        if (FreezeTimer.Globalmovespeed == 1)
            Freeze();

    }

    private void Freeze()
    {
        // move the object along the x-axis
        //if (movingForward)
        //{
        //    transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        //    if (transform.position.x >= endPosition.x)
        //    {
        //        movingForward = false;
        //    }
        //}
        //else
        //{
        //    transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        //    if (transform.position.x <= startPosition.x)
        //    {
        //        movingForward = true;
        //    }
        //}

        // check if it's time to shoot
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; // set time of next shot

            Shoot(); // shoot a bullet
        }
    }

    void Shoot()
    {


        Vector2 direction = -transform.up * fireForce;

        // Find the BulletScript prefab on that spawned bullet, and set it's velocity component.
        bulletPrefab.GetComponent<LaserE>().Velocity = direction;


        // instantiate a bullet at the object's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // set the bullet's velocity to move in the positive x direction
        //bullet.GetComponent<Rigidbody2D>().velocity = transform.right;

        //reset bullet properties
        //bullet.GetComponent<Bullet>().ChangeBulletDmg(1);
        //bullet.transform.localScale = new Vector3(0.75f, 3f, 0);
    }

    private void timeToDie()
    {
        Destroy(gameObject);
    }


}
