using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameMenager : MonoBehaviour
{
    [HideInInspector] public float gameSpeed = 5f;
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;


    private void Awake()
    {
        gameSpeed = initialGameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed +=  gameSpeedIncrease * Time.deltaTime;
    }
}
