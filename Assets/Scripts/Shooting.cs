using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;

    public Transform firepoint;

    public Transform firepoint2;

    public Camera sceneCamera;

    private Vector2 mousePosition;

    public float fireForce;

    public void Start()
    {
    }

    public void Fire()
    {


        // Get the position of the mouse on the screen.
        Vector3 screenMousePos = Input.mousePosition;

        // Turn that screen position into the actual position in the world.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

        // Find out the direction between the player and the mouse pointer.
        Vector2 direction = mousePos - (Vector2)firepoint.position;

        // Normalize the direction and multiply by bullet speed.
        direction.Normalize();
        direction *= fireForce;

        // Find the BulletScript prefab on that spawned bullet, and set it's velocity component.
        laser.GetComponent<Laser>().Velocity = direction;

        // Spawn the bullet from the prefab.
        GameObject laser1 = Instantiate(laser, firepoint.position, firepoint.rotation);
        GameObject laser2 = Instantiate(laser, firepoint2.position, firepoint2.rotation);


        //reset bullet properties
        //bullet.GetComponent<Bullet>().ChangeBulletDmg(1);
        laser.transform.localScale = new Vector3(0.75f, 3f, 0);
    }

}
