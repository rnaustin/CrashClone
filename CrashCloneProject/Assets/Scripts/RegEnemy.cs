using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Austin, Robert
// 10/26/2023
// Controlls Regular Enemy movement

public class RegEnemy : MonoBehaviour
{

    public float travelDistanceRight = 0f;
    public float travelDistanceLeft = 0f;
    public float speed = 0f;

    private float startX;
    private bool movingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            // if the object is not farther than the start position + right travel distance, it can move right
            if (transform.position.x <= startX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            // if the object has reached is less than start position + travel left distance, it can move left
            if (transform.position.x >= startX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                movingRight = true;
            }
        }
    }
}
