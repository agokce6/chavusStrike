using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public static float maxrange;

    public int damage_e { get; set; }
    public float speed_e { get; set; }

    private void Awake()
    {
        speed_e = 30;
        damage_e = 10;    
    }

    void Start()
    {
        rb.velocity = transform.right * speed_e;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "main")
        {
            health healt = collision.GetComponent<health>();
            if (healt != null)
            {
                healt.takeDamage(damage_e);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                animator.SetBool("hitEnemy", true);
            }
            Invoke("Destroyy", 0.2f);
        }
        if (collision.tag == "wall")
        {
            Destroy(gameObject);
        }
    }

    void Destroyy()
    {
        Destroy(gameObject);
    }

}
