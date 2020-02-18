using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moveHead : MonoBehaviour
{

    void Update()
    {
        //Debug.Log(health.currenthealth);
        transformHead();
    }

    void transformHead()
    {
        /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 sds = touch.position;
            sds = Camera.main.ScreenToWorldPoint(sds);
            Vector2 sdss = new Vector2(sds.x, sds.y);
            transform.up = sdss;
        }*/
        
        weapon weapo = GetComponent<weapon>();
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 mousePos = new Vector2(mouse.x, mouse.y);
        if (Input.GetMouseButton(0) && Time.timeScale==1 && !buttonScript.isClicked && !pause.isClicked)
        {
            transform.up = mousePos;
            if (mousePos.x > 0)
            {                
                transform.Rotate(new Vector3(180, 0, 90));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -90));
            }
            weapo.Shoot();
        }
    }
}
