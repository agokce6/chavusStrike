using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemy : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public GameObject main;
    public float speed;
    float angle;
    Vector2 position; // 2d form of position of object
    public int Health=150;
    public int givendamage = 10;
    public float explosionRatio = 0.1f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject c4;
    public Transform bulletpPrefabTransform;
    public float bulletScale = 0.3f;
    public float shootSpeed = 3f;
    float shootspeed;
    bool active;
    


    void Start()
    {
        active = false;
        bulletpPrefabTransform.localScale = new Vector3 (bulletScale,bulletScale,1);
        angleCalculator();
        look2Vush();
    }

    
    void Update()
    {
        if (weapon.isReloaded)
        {
            shootspeed = Random.Range(1.5f, shootSpeed);
        }
        if (!weapon.isReloaded)
        {
            shootspeed = shootSpeed;
        }
        move2Vush();
        if (active)
        {
            StartCoroutine(giveDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "wall")
        {
            active = true;
        }
        if(other.name == "main")
        {
            Explosion();
        }
    }

    void look2Vush()
    {
        Vector2 vushPos = new Vector2(0f,0f);
        transform.up = vushPos;
        
        if (transform.position.x > 0)
        {
            if (transform.position.y > 0)
            {
                transform.Rotate(new Vector3(0, 180, -angle));
            }
            else
            {
                transform.Rotate(new Vector3(0, 180, angle));
            }
        }
        else
        {
            angle -= 180;
            if(transform.position.y < 0)
            {
                transform.Rotate(new Vector3(0, 0, -angle));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, angle));
            }
        }

    }

    void angleCalculator() //angle between object and x-axis
    {
        position = new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Acos(Vector2.Dot(new Vector2(1, 0), position) / position.magnitude) * Mathf.Rad2Deg; 
        //angle by using dot product of two vectors
    }

    void move2Vush()
    {     
        GetComponent<Rigidbody2D>().velocity = -position * Time.deltaTime * speed;
    }

    public void takeDamage(int takendamage)
    {
        Health -= takendamage;
        if(Health <= 0)
        {
            Die();
        }
    }

    public IEnumerator giveDamage()
    {
        yield return new WaitForSeconds(shootspeed);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StopAllCoroutines();
    }

    public void Explosion()
    {
        Destroy(gameObject);
        GameObject clone =(GameObject) Instantiate(c4, gameObject.transform.position, Quaternion.identity);
        Destroy(clone,3f);
    }


    void Die()
    {
        if (health.currenthealth < health.totalhealth)
        {
            health.currenthealth += 10;
        }
        killScript.kill += 1;
        killScript.tempscore += 1;
        Destroy(gameObject);
    }
}
