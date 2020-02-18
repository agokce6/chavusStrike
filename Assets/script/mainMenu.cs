using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject AboutPanel;

    public void Onown()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void about()
    {
        AboutPanel.SetActive(true);
    }

    public void aboutback()
    {
        AboutPanel.SetActive(false);
    }
}
