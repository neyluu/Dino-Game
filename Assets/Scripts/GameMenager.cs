using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameMenager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public float gameSpeed = 5f;
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float score = 0;

    private DinoMovement dino;
    private CactusSpawner spawner;

    public GameObject scoreLabel;

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
            Score();
        }
    }

    public void GameOver()
    {
        gameSpeed = 0;
        isGameOver = true;

        spawner.gameObject.SetActive(false);
        dino.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    void Score()
    {
        score += gameSpeed * Time.deltaTime;
        scoreLabel.GetComponent<TextMeshProUGUI>().text = Mathf.Floor(score).ToString("000000");
    }
}
