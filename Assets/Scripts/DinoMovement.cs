using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    private GameMenager gameMenager;

    public int jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        gameMenager = FindAnyObjectByType<GameMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameMenager.isGameOver)
        {
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.y < -2.95)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }

            //jumping animation
            if(transform.position.y > -2.8f)
            {
                animator.SetFloat("Speed", 2);
            }

            //running animation
            if(transform.position.y <= -2.9f)
            {
                animator.SetFloat("Speed", 0);
            }
        }
        else
        {
            animator.SetFloat("Speed", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameMenager.GameOver();
        }
    }
}
