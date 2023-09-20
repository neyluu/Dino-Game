using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameMenager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public float gameSpeed = 5f;
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;

    private DinoMovement dino;
    private CactusSpawner spawner;

    private void Awake()
    {
        gameSpeed = initialGameSpeed;
    }

    void Start()
    {
        dino = FindObjectOfType<DinoMovement>();
        spawner = FindObjectOfType<CactusSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
        }
    }

    public void GameOver()
    {
        gameSpeed = 0;
        isGameOver = true;

        spawner.gameObject.SetActive(false);
        dino.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
}
