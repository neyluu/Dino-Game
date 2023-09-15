using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public int minSpawnTime = 10;
    public int maxSpawnTime = 50;

    private int timer = 0;
    private int timeToSpawn;

    void Start()
    {
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == timeToSpawn)
        {
            int index = Random.Range(0, objectsToSpawn.Length - 1);
           
            Instantiate(objectsToSpawn[index], transform.position, transform.rotation);
           
            timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timer = 0;
        }

        timer++;
    }
}
