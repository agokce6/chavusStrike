using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class killScript : MonoBehaviour
{
    public GameObject main;
    public static int kill;
    public static int tempscore;
    public static int realscore;
    TextMeshProUGUI text;
    bool xd = false;
    public GameObject win;
    public Button reload;


    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (tempscore % 8 == 0 && !xd && tempscore != 0)
        {
            realscore += 1;
            xd = true;
            weapon weapo = main.GetComponent<weapon>();
            if (weapo != null)
            {
                weapo.SetWeapon();
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy"); 
            if(enemies != null)
            {
                foreach (GameObject a in enemies)
                {
                    Destroy(a);
                }
            }
        }
        if (tempscore % 8 != 0)
        {
            xd = false;
        }

        if(kill==74 && realscore == 9)
        {
            Win();
        }
        text.text = "KILL: " + kill.ToString() + "   LEVEL: " + realscore.ToString();
    }

    void Win()
    {
        Time.timeScale = 0;
        reload.interactable = false;
        win.SetActive(true);
    }

}
