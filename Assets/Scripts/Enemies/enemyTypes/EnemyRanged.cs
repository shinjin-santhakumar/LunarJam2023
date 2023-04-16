using UnityEngine;
using System.Collections;

public class EnemyRanged : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private float distance;
    public float DistanceFrom;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        distance = Vector2.Distance(transform.position, target.position);
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            distance = Vector2.Distance(transform.position, target.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection = direction;

            anim.speed = FreezeTimer.Globalmovespeed;
        }
    }

    private void FixedUpdate()
    {
        if (distance == DistanceFrom)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        if (distance < DistanceFrom)
        {
            rb.velocity = new Vector2(-moveDirection.x * 2, -moveDirection.y * 2) * FreezeTimer.Globalmovespeed;
            return;
        }
        
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * FreezeTimer.Globalmovespeed;
        }
    }

    private void timeToDie()
    {
        Destroy(gameObject);
    }

   


}