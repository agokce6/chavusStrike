using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class weapon : MonoBehaviour
{
    // it is called by moveHead.cs
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animato;

    public RawImage weaponImg;
    public LayerMask lm;

    public static bool isReloading { get; set; }
    public static bool isReloaded { get; set; }
    public static float reloadTime { get; set; }

    public static float sprayInterval { get; set; }
    float sprayinterval;

    public static string weaponName;
    public static int magazine { get; set; }
    public static int totalMagazine { get; set; }

    public Texture p90;
    public Texture ump_45;
    public Texture m4_a4;
    public Texture ak47;
    public Texture scar_20;
    public Texture awp;
    public Texture deagle;
    public Texture usp_8;
    public Texture alayina;
    public Texture knife;
    public GameObject knifeAnim;

    private void Awake()
    {
        SetWeapon();
    }

    private void Start()
    {
        isReloading = false;
        isReloaded = true;
        sprayinterval = 0;
    }

    private void Update()
    {
        sprayinterval -= Time.deltaTime;
        if(magazine == 0)
        {
            isReloaded = false;
        }
    }

    public void Shoot()
    {
        if (true)
        {
            if(sprayinterval <= 0 && !isReloading && isReloaded)
            {
                if (weaponName != "knife")
                {
                    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    //FindObjectOfType<AudioManager>().Play("mermi");
                    if (weaponName == "alayina")
                    {
                        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        bullet1.transform.Rotate(0, 0, 5f);
                        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        bullet2.transform.Rotate(0, 0, -5f);
                        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        bullet3.transform.Rotate(0, 0, -9f);
                        GameObject bullet4 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        bullet4.transform.Rotate(0, 0, 9f);
                    }
                    magazine -= 1;

                }
                else
                {
                    knifeHit();
                }
                sprayinterval = sprayInterval;
            }
        }
    }

    public void SetWeapon()
    {
        isReloaded = true;
        bullet.speed = 30;
        switch (killScript.realscore)
        {
            case 0: //p90
                weaponName = "p90";
                weaponImg.texture = p90;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.071f;
                weapon.totalMagazine = 50;              
                bullet.damage = 26;           
                break;
            case 1: //u45
                weaponName = "ump-45";
                weaponImg.texture = ump_45;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.094f;
                weapon.totalMagazine = 35;
                bullet.damage = 35;
                break;
            case 2: //m4
                weaponName = "m4-a4";
                weaponImg.texture = m4_a4;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.094f;
                weapon.totalMagazine = 30;
                bullet.damage = 33;
                spawnObject.spawnTime = 1.1f;
                break;
            case 3: //ak
                weaponName = "ak47";
                weaponImg.texture = ak47;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.11f;
                weapon.totalMagazine = 30;
                bullet.damage = 36;
                break;
            case 4: //s20
                weaponName = "scar-20";
                weaponImg.texture = scar_20;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.31f;
                weapon.totalMagazine = 20;
                bullet.damage = 80;
                break;
            case 5: //awp
                weaponName = "awp";
                weaponImg.texture = awp;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 1.1f;
                weapon.totalMagazine = 10;
                bullet.damage = 115;
                spawnObject.spawnTime = 1f;
                break;
            case 6: //xm
                weaponName = "alayina";
                weaponImg.texture = alayina;
                reloadTime = 1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.37f;
                weapon.totalMagazine = 7;
                bullet.damage = 10;
                break;
            case 7: //u8
                weaponName = "usp-8";
                weaponImg.texture = usp_8;
                reloadTime = 1.1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.18f;
                spawnObject.spawnTime = 1.1f;
                weapon.totalMagazine = 12;
                bullet.damage = 35;
                break;
            case 8: //de
                weaponName = "deagle";
                weaponImg.texture = deagle;
                reloadTime = 1.1f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 0.18f;
                weapon.totalMagazine = 7;
                bullet.damage = 63;

                break;
            case 9: //kn
                weaponName = "knife";
                weaponImg.texture = knife;
                reloadTime = 1.5f;
                animato.SetFloat("speed", reloadTime);
                weapon.sprayInterval = 1.3f;
                weapon.totalMagazine = 1;
                bullet.damage = 230;
                spawnObject.spawnTime = 3.3f;
                break;
        }
        magazine = totalMagazine;
    }

    void knifeHit()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(firePoint.position ,1f,lm);
        foreach (Collider2D c in enemies)
        {
                c.GetComponent<enemy>().takeDamage(bullet.damage);
        }
        GameObject a = Instantiate(knifeAnim, firePoint.position, firePoint.parent.rotation);
        Destroy(a, 0.25f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(firePoint.position, 1f);
    }

}
