using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Emovement : MonoBehaviour
{
     public float speed = 5f;  // the speed of the enemy's movement
    public float margin = 1f;  // the margin from the edge of the screen

    private Camera mainCamera;  // reference to the main camera
    private Renderer renderer;  // reference to the enemy's renderer
    private float minX, maxX, minY, maxY;  // the minimum and maximum x and y values for the enemy's position
    private int direction = 1;  // the direction of the enemy's movement, either 1 or -1

    public float facingAngle = 90f;
    public float toleranceAngle = 5f;

    public Transform target;
    private float angle;


    private Vector3 targetPosition1;
    private Vector3 targetPosition2;
    private Vector3 targetPosition;
    private bool hasEnteredScreen = false;

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

        InGameLogic();

    }

    void InGameLogic() {
        // calculate the new position based on the enemy's direction and speed
        

        if (!hasEnteredScreen)
        {
            // Move the enemy towards the center of the screen

            targetPosition1 = new Vector2(-43f, 43f);
            targetPosition2 = new Vector2(43f, -43f);

            float distanceFromP1 = Vector3.Distance(targetPosition1, transform.position);
            float distanceFromP2 = Vector3.Distance(targetPosition2, transform.position);

            if (distanceFromP1 < distanceFromP2)
                targetPosition = targetPosition1;
            else
                targetPosition = targetPosition2;


            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * FreezeTimer.Globalmovespeed);

            // Check if the enemy has entered the screen
            if (transform.position == targetPosition)
            {
                hasEnteredScreen = true;
            }
        } else {

            Vector3 newPosition = transform.position + transform.right * speed * Time.deltaTime * FreezeTimer.Globalmovespeed;
            if (newPosition.x < minX || newPosition.x > maxX || newPosition.y < minY || newPosition.y > maxY)
            {

                transform.rotation *= Quaternion.Euler(0, 0, -90);


                if (newPosition.x > maxX)
                    newPosition.x -= 1;
                else if (newPosition.y < minY)
                    newPosition.y += 1;
                else if (newPosition.y > maxY)
                    newPosition.y -= 1;
                else if (newPosition.x < minX)
                    newPosition.x += 1;

            }

            // update the enemy's position
            transform.position = newPosition;


        }
        

    }

}
