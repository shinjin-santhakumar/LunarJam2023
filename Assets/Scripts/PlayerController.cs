using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements.Experimental;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction fire;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        playerControls = new PlayerInputActions();

    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire= playerControls.Player.Fire;
        fire.Enable();

        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Fire(InputAction.CallbackContext context) 
    {
        Debug.Log("Fired");
    
    }


}
