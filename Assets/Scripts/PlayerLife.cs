using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] GameObject healthbar;
    private Animator healthanim;
    private int health = 3;

    [SerializeField] private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthanim = healthbar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyLaser"))
       {
            health -= 1;
            if (health >= 1)
            {
                //health -= 1;
                healthanim.SetTrigger("damage");
                StartCoroutine(takeDamage());
            }
            else if (health == 0)
            {
                pc.canAim = false;
                healthanim.SetTrigger("damage");
                anim.SetTrigger("death");
                rb.bodyType = RigidbodyType2D.Static;
                //anim.SetTrigger("death");
            }
            //rb.bodyType = RigidbodyType2D.Static;
       } 
    }

    private IEnumerator takeDamage()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.5f);
        this.GetComponent<BoxCollider2D>().enabled = true;
        //yield return new WaitForSeconds(.1f);
    }
}
