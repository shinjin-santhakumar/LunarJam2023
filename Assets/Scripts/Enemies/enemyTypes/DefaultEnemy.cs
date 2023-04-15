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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            distance = Vector2.Distance(target.position, transform.position);

            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg  * FreezeTimer.Globalmovespeed;
            rb.rotation = angle;
            moveDirection = direction;
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
            Destroy(gameObject);
        }
    }
   

}