using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
    [TextArea]
    [Tooltip("önemli bir yorum")]
    public string Notes = "yorrum";

    public GameObject terorist1; //id=0
    public GameObject terorist2; //id=1
    public GameObject hearth; //id=2
    public bool spawnTerorists=true;

    GameObject[] objects ;

    int spawneePossibilty = 0;
    public static float spawnTime = 0.7f;
    public float spawnRadius = 12.5f;

    float randomAngle = 0f;
    Vector2 spawnPoint;

    void Start()
    {
        objects = new GameObject[] { terorist1, terorist2, hearth };
    }

    void Update()
    {
        Spawn();
        spawnRadius += 3;
        spawnRadius -= 5;
        spawnRadius += 5;
        spawnRadius -= 3;
    }

    void Spawn()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(spawnTime);
        idChooser();      
    }

    void idChooser()
    {
        spawneePossibilty = Random.Range(0, 101);
        posChooser();
        
        if (spawneePossibilty <= 45 && spawnTerorists)
        {
            Instantiate(objects[0],spawnPoint, Quaternion.identity);
        }
        else if(spawneePossibilty <= 90 && spawnTerorists)
        {
            Instantiate(objects[1], spawnPoint, Quaternion.identity);
        }
        if(spawneePossibilty <= 100 && spawneePossibilty>90)
        {
            Instantiate(objects[2], spawnPoint, Quaternion.identity);
        }
        StopAllCoroutines();
    }

    void posChooser()
    {
        randomAngle = Random.Range(0, Mathf.PI * 2);
        spawnPoint = new Vector2(Mathf.Sin(randomAngle) * spawnRadius , Mathf.Cos(randomAngle) * spawnRadius);
    }

    
}
