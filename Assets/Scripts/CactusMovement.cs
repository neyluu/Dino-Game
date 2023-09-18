using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusGenerator : MonoBehaviour
{
    public GameMenager gameMenager;
    public int deadZone = -12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * gameMenager.gameSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            // Destroy();
        }
    }
}
