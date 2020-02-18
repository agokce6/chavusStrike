using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class magazineScript : MonoBehaviour
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Ammo: " + weapon.magazine.ToString() + "\n" + weapon.weaponName;
    }
}
