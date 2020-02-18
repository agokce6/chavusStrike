using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    Transform bar;
    float x;

    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(0.4f, 1f);
    }

    private void Update()
    {
        x = (float)health.currenthealth / health.totalhealth;
        bar.localScale = new Vector3(x, 1f);
    }
}
