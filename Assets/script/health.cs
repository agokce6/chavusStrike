using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public int totalhealth_onInspector;
    public static int totalhealth;
    public static float currenthealth;
    public GameObject gameover;
    public Button reload;

    private void Awake()
    {
        totalhealth = totalhealth_onInspector;
        currenthealth = totalhealth_onInspector * 1.0f;
    }

    private void Update()
    {
        //Debug.Log(currenthealth);
    }

    public void takeDamage(int takenDamage)
    {
        currenthealth -= takenDamage;
        if(currenthealth <= 0)
        {
            GameOver();
        }
    }

    public void Heal()
    {
        if (currenthealth + 25 <= totalhealth)
        {
            currenthealth += 25;
        }
        else
        {
            currenthealth = totalhealth;
        }
    }

    void GameOver()
    {
        if (currenthealth <= 0)
        {
            Time.timeScale = 0;
            reload.interactable = false;
            gameover.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        reload.interactable = true;
        killScript.realscore = 0;
        killScript.tempscore = 0;
        killScript.kill = 0;
        SceneManager.LoadScene("gameScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "case")
        {
            Heal();
            Destroy(collision.gameObject);
        }
    }
    
}
