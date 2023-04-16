using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] GameObject healthbar;
    private Animator healthanim;
    private Animator enemyanim;
    public int health = 3;

    public GameObject gameovertext;
    public GameObject retrybutton;
    public GameObject menubutton;

    private GameObject[] enemies;

    [SerializeField] private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthanim = healthbar.GetComponent<Animator>();

        // if (enemies == null)
        //     enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyLaser"))
       {

            if (collision.gameObject.CompareTag("EnemyLaser"))
            {
                Destroy(collision.gameObject);
            }


            this.GetComponent<BoxCollider2D>().enabled = false;
            health -= 1;
            if (health >= 1)
            {
                //health -= 1;
                healthanim.SetTrigger("damage");
                StartCoroutine(takeDamage());
            }
            else if (health == 0)
            {


                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Animator>().speed = 0;
                    enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    //enemy.GetComponent<Animator>().speed = 0;
                }

                pc.canAim = false;
                healthanim.SetTrigger("damage");
                anim.SetTrigger("death");
                rb.bodyType = RigidbodyType2D.Static;
                
                GetComponent<PlayerController>().canShoot = false;
                StartCoroutine(gameOver());
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

    private IEnumerator gameOver()
    {
        yield return new WaitForSeconds(1f);
        gameovertext.SetActive(true);
        yield return new WaitForSeconds(1f);
        retrybutton.SetActive(true);
        menubutton.SetActive(true);
    }
}
