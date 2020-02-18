using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public static float maxrange;

    public static int damage { get; set; }
    public static float speed { get; set; }

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "enemy")
        {
            enemy enem = collision.GetComponent<enemy>();
            if (enem != null && weapon.weaponName != "knife")
            {
                enem.takeDamage(damage);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                animator.SetBool("hitEnemy", true);
                //FindObjectOfType<AudioManager>().Play("vurma");
            }
            Invoke("Destroyy", 0.2f);
            
        }

        if(collision.tag == "wall")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "case")
        {
            cases casee = collision.GetComponent<cases>();
            if(casee != null)
            {
                casee.takeDamage(damage);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                animator.SetBool("hitEnemy", true);             
            }
            Invoke("Destroyy", 0.1f);
        }
    }

    void Destroyy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {

    }

}
