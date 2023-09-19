using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public GameMenager gameMenager;
    public float minSpawnTime = 1;
    public float maxSpawnTime = 5;

    private float timer = 0;
    private float timeToSpawn;
    public int deadZone = -12;

    void Start()
    {
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime) / gameMenager.gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > timeToSpawn)
        {
            spawnCactus();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void spawnCactus()
    {
        int index = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[index], transform.position, transform.rotation);
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime) / gameMenager.gameSpeed;
    }
}
