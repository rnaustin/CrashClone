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
    public float throwRate = 1f;
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
    private void ThrowFlames()
    {
        // if throwing flames right instantiate them in the 
        if (throwRight)
        {
            GameObject leftFlameInstance = Instantiate(flamePrefab, transform.position, transform.rotation);
            GameObject middleFlameInstance = Instantiate(flamePrefab, transform.position, transform.rotation);
            GameObject rightFlameInstance = Instantiate(flamePrefab, transform.position, transform.rotation);
        }
        else
        {

            GameObject leftFlameInstance = Instantiate(flamePrefab, transform.position, transform.rotation);
            GameObject middleFlameInstance = Instantiate(flamePrefab, transform.position, transform.rotation);
            GameObject rightFlameInstance = Instantiate(flamePrefab, transform.position, transform.rotation);
        }
        
        
        /*
        leftFlameInstance.GetComponent<Flame>().goingRight = throwRight;
        middleFlameInstance.GetComponent<Flame>().goingRight = throwRight;
        rightFlameInstance.GetComponent<Flame>().goingRight = throwRight;
        */
    }
}