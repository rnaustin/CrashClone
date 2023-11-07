using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Devin Monaghan, Robert Austin
/// 11/02/2023
/// Handles Flamethrower flame spawning
/// </summary>

public class Flamethrower : MonoBehaviour
{
    public GameObject flamePrefab;
    public float throwRate = 0.5f;
    public bool throwRight = false;

    // Start is called before the first frame update
    void Start()
    {
        // repeatedly spawn flames at the rate of throwRate
        InvokeRepeating("ThrowFlames", 0, throwRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // spawn 3 flames
    private IEnumerator ThrowFlames()
    {
        float startTime = Time.time;
        while (true)
        {
            float timePassed = Time.time - startTime;
            if (timePassed < 5f)
            {
                // if throwing flames right instantiate them in the right rotation
                if (throwRight)
                {
                    GameObject leftFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, 30, 90));
                    GameObject middleFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    GameObject rightFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, -30, 90));

                    // set the direction the instance will move according to its rotation
                    leftFlameInstance.GetComponent<Flame>().order = "left";
                    middleFlameInstance.GetComponent<Flame>().order = "middle";
                    rightFlameInstance.GetComponent<Flame>().order = "right";

                    // set the direction of the instantiated flames equal to that of the flamethrower
                    leftFlameInstance.GetComponent<Flame>().goingRight = throwRight;
                    middleFlameInstance.GetComponent<Flame>().goingRight = throwRight;
                    rightFlameInstance.GetComponent<Flame>().goingRight = throwRight;
                }
                // if throwing flames left instantiate them in the left rotation
                else
                {
                    GameObject leftFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, -30, 90));
                    GameObject middleFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    GameObject rightFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, 30, 90));

                    // set the direction the instance will move according to its rotation
                    leftFlameInstance.GetComponent<Flame>().order = "left";
                    middleFlameInstance.GetComponent<Flame>().order = "middle";
                    rightFlameInstance.GetComponent<Flame>().order = "right";

                    // set the direction of the instantiated flames equal to that of the flamethrower
                    leftFlameInstance.GetComponent<Flame>().goingRight = throwRight;
                    middleFlameInstance.GetComponent<Flame>().goingRight = throwRight;
                    rightFlameInstance.GetComponent<Flame>().goingRight = throwRight;
                }
                
            }
            else
            {
                //wait for 3 seconds
                //startTime = Time.time;
            }
            

            yield return new WaitForEndOfFrame();
        }

        
    }
}