using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cases : MonoBehaviour
{
    Vector2 position; // 2d form of position of object
    public float speed = 10f;

    public int totalhealth_onInspector = 200;
    public static int totalhealth;
    public static float currenthealth;

    private void Awake()
    {
        totalhealth = totalhealth_onInspector;
        currenthealth = totalhealth_onInspector * 1.0f;
    }

    void Start()
    {
        position = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        move2Vush();
    }

    void move2Vush()
    {       
        GetComponent<Rigidbody2D>().velocity = -position * Time.deltaTime * speed;
    }

    public void takeDamage(int takendamage)
    {
        currenthealth -= takendamage;
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
