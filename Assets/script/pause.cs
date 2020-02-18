using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour, IPointerEnterHandler
{
    public static bool isClicked=false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isClicked = true;
    }


    // Update is called once per frame
    void Update()
    {
         if(Time.timeScale == 0 && isClicked)
        {
            isClicked = false;
        }
    }
}
