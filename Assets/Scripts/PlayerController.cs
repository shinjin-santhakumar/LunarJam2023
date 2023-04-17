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
    private InputAction freeze;
    private InputAction boost;
    private Vector2 moveDirection;
    private bool Freezing;
    [SerializeField] private Boostbar bbb;
    private bool holdingBoost;

    public Shooting shoot;

    public bool canAim = true;
    public bool canShoot = true;

    private float firerate = 1;
    public GameObject Laser;

    [SerializeField] private AudioSource shootSound;

    [SerializeField] private AudioSource pickupSound;

    //static public float Globalmovespeed;

    // Start is called before the first frame update
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        Laser.GetComponent<Laser>().scale = true;

    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire= playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;


        freeze = playerControls.Player.Freeze;
        freeze.Enable();

        boost = playerControls.Player.Boost;
        boost.Enable();
        

    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        freeze.Disable();
        boost.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (FreezeTimer.Globalmovespeed == 0)
        {
            fire.Enable();
        }
        else
        {
            //Comment out to fire whenever
            fire.Disable();
        }
        moveDirection = move.ReadValue<Vector2>();

        if (canAim == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }
        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


        Freezing = freeze.ReadValue<float>() > 0;

        // if (holdingBoost)
        //     bbb.UseBoost();

        holdingBoost = boost.ReadValue<float>() > 0.1f;




    }

    void FixedUpdate()
    {
        Move();
        ifFreezing();

        if (holdingBoost)
            bbb.UseBoost();

    }

    void Move()
    {
        //rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
    }

    void Fire(InputAction.CallbackContext context) 
    {
        if (canShoot)
        {
            shoot.Fire();
            shootSound.Play();
            StartCoroutine(SetCanShoot());
        }

        // shoot.Fire();
        // shootSound.Play();
        //StartCoroutine(SetCanShoot());
    
    }

    void ifFreezing()
    {
        //if (Freezing)
        //    Globalmovespeed = 0;
        //else
        //    Globalmovespeed = 1;
    }

    IEnumerator SetCanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(firerate);
        canShoot = true;
    }

    IEnumerator wait(){
        pickupSound.Play();
        firerate = .5f;
        yield return new WaitForSeconds(20f);
        firerate = 1;
    }
    IEnumerator waitBullet(){
        pickupSound.Play();
        //Debug.Log("time to enumerate");
        Laser.GetComponent<Laser>().scale = false;
        yield return new WaitForSeconds(20f);
        Laser.GetComponent<Laser>().scale = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("FireRate")){
            Destroy(other.gameObject);
            StartCoroutine(wait());
           
        }
        if (other.gameObject.CompareTag("BulletBigger")){
            Destroy(other.gameObject);
            StartCoroutine(waitBullet());
           
        }
    }
}
