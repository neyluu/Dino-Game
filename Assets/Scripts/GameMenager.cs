using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public float gameSpeed = 5f;
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float score = 0;
    private int highScore;

    private DinoMovement dino;
    private CactusSpawner spawner;

    public GameObject scoreLabel;
    public GameObject highScoreLabel;
    public GameObject gameOverScreen;

    private void Awake()
    {
        gameSpeed = initialGameSpeed;
    }

    void Start()
    {
        dino = FindObjectOfType<DinoMovement>();
        spawner = FindObjectOfType<CactusSpawner>();

        if(PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            showHighScore(highScore);
        }
        else
        {
            highScore = 0;
            showHighScore(highScore);
        }
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

        gameOverScreen.SetActive(true);

        PlayerPrefs.Save();
    }

    void Score()
    {
        score += gameSpeed * Time.deltaTime;
        scoreLabel.GetComponent<TextMeshProUGUI>().text = Mathf.Floor(score).ToString("000000");

        if(Mathf.Floor(score) > highScore)
        {
            setHighScore((int)Mathf.Floor(score));
            showHighScore((int)Mathf.Floor(score));
        }
    }

    void setHighScore(int highScore)
    {
        PlayerPrefs.SetInt("highScore", highScore);
    }

    void showHighScore(int highScore)
    {
        highScoreLabel.GetComponent<TextMeshProUGUI>().text = highScore.ToString("000000");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
