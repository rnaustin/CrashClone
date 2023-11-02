using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Austin, Robert and Monoghan, Devin
// 11/2/2023
// Controls enemy movement

public class EnemyMovment : MonoBehaviour
{
    public float travelDistanceRight = 5f;
    public float travelDistanceLeft = 5f;
    public float travelDistanceForward = 5f;
    public float travelDistanceBack = 5f;
    public float speed = 5f;
    public bool goingSideToSide = true;

    private float startX;
    private float startZ;
    private bool movingRight = true;
    private bool movingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingSideToSide)
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
                if (transform.position.x >= startX - travelDistanceLeft)
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else
                {
                    movingRight = true;
                }
            }
        }
        else
        {
            if (movingForward)
            {
                if (transform.position.z <= startZ + travelDistanceForward)
                {
                    transform.position += Vector3.forward * speed * Time.deltaTime;
                }
                else
                {
                    movingForward = false;
                }
            }
            else
            {
                if (transform.position.z >= startZ - travelDistanceBack)
                {
                    transform.position += Vector3.back * speed * Time.deltaTime;
                }
                else
                {
                    movingForward = true;
                }
            }
        }
    }
}