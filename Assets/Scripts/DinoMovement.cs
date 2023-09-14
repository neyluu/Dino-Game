using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y < -3)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
