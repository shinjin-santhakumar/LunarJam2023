using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emovement : MonoBehaviour
{
     public float speed = 5f;  // the speed of the enemy's movement
    public float margin = 1f;  // the margin from the edge of the screen

    private Camera mainCamera;  // reference to the main camera
    private Renderer renderer;  // reference to the enemy's renderer
    private float minX, maxX, minY, maxY;  // the minimum and maximum x and y values for the enemy's position
    private int direction = 1;  // the direction of the enemy's movement, either 1 or -1

    void Start()
    {
        // get references to the main camera and the enemy's renderer
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();

        // calculate the minimum and maximum x and y values for the enemy's position
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + renderer.bounds.extents.x + margin;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - renderer.bounds.extents.x - margin;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + renderer.bounds.extents.y + margin;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y - renderer.bounds.extents.y - margin;
    }

    void Update()
    {
        // calculate the new position based on the enemy's direction and speed
        Vector3 newPosition = transform.position + transform.right * speed * Time.deltaTime;

        // if the enemy reaches the edge of the screen, change direction
        if (newPosition.x < minX || newPosition.x > maxX || newPosition.y < minY || newPosition.y > maxY) {

            transform.rotation *= Quaternion.Euler(0, 0, -90);


            if(newPosition.x > maxX)
                newPosition.x -= 1;
            else if(newPosition.y < minY )
                newPosition.y += 1;
            else if(newPosition.y > maxY)
                newPosition.y -= 1;
            else if (newPosition.x < minX)
                newPosition.x += 1;

            //Debug.Log("1 -90");

            //newPosition = transform.position + transform.right * speed * Time.deltaTime;
        }

        // update the enemy's position
        transform.position = newPosition;
    }
    
}
