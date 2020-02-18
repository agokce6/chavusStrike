using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour, IPointerDownHandler
{
    public Animator reload;
    public Button reloadButton;
    public GameObject main;
    public static bool isClicked;
    bool eenabled = true;
    public Button exitButton;
    public GameObject exitGameObject;
    public Button pauseButton;

    public void Click()
    {
       
        weapon weapo = main.GetComponent<weapon>();
        if(weapon.totalMagazine != weapon.magazine)
        {
            reload.SetBool("reload", true);
            if (weapo != null)
            {
                weapo.SetWeapon();
            }
            reloadButton.interactable = false;
            weapon.isReloading = true;
            Invoke("resetReload", 1 / weapon.reloadTime);
        }
        else
        {
            resetReload();
        }
    }

    void resetReload()
    {
        reloadButton.interactable = true;
        weapon.isReloading = false;
        reload.SetBool("reload", false);
        isClicked = false;
    }

    private void Update()
    {
        if (eenabled)
        {
            Time.timeScale = 1;
            exitGameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            exitGameObject.SetActive(true);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void Pause()
    {
        eenabled = !eenabled;
    }

    public void Exit()
    {
        health healt = main.GetComponent<health>();
        if (healt != null)
        {
            healt.Restart();
        }
        SceneManager.LoadScene(0);
    }

}
