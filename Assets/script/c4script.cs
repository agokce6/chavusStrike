using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c4script : MonoBehaviour
{

    public float expoTime = 1.5f;
    public float damageRatio = 0.7f;

    void Update()
    {
        expoTime -= Time.deltaTime;
        if (expoTime <= 0)
        {
            expoTime = 100f;
            giveDamage();
            //FindObjectOfType<AudioManager>().Play("patlama");
        }
    }

    void giveDamage()
    {
        health.currenthealth = health.currenthealth * damageRatio;
    }
}
