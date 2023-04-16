using UnityEngine;
using System.Collections;

public class DefaultEnemy : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private float distance;
    public float thrust;
    private float angle;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (FreezeTimer.Globalmovespeed == 0)
        {
            rb.rotation = angle;
            anim.speed = FreezeTimer.Globalmovespeed;
            return;
        }
        if (target)
        {

            distance = Vector2.Distance(target.position, transform.position);

            Vector3 direction = (target.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg  * FreezeTimer.Globalmovespeed;
            rb.rotation = angle;
            moveDirection = direction;
            
            anim.speed = FreezeTimer.Globalmovespeed;
        }
    }

    

    private void FixedUpdate()
    {
        if (target && distance < 10)
        {
            rb.AddForce(new Vector2(moveDirection.x * thrust, moveDirection.y * thrust));
        }
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * FreezeTimer.Globalmovespeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            //Destroy(gameObject);
        }
    }

    private void timeToDie()
    {
        Destroy(gameObject);
    }
   

}