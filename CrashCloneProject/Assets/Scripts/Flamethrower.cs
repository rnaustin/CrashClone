using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Devin Monaghan, Robert Austin
/// 11/12/2023
/// Handles Flamethrower flame spawning
/// </summary>

public class Flamethrower : MonoBehaviour
{
    public GameObject flamePrefab;

    public float flameRate = 0.3f;
    public float flameDelay = 4f;

    public bool throwingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // repeatedly throw flames
        StartCoroutine(ThrowFlames());
    }

    // spawn 3 flames
    private IEnumerator ThrowFlames()
    {
        // creates variable representing the time the loop began
        float startTime = Time.time;
        // repeats the while loop every frame
        while (true)
        {
            // creates variable representing the time that has passed since the start of loop
            float timePassed = Time.time - startTime;
            
            // if the time since the loop began has not reached 5 seconds then continue instantiating flames
            if (timePassed < 5f)
            {
                // instantiate row of flames
                GameObject leftFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, 30, 90));
                GameObject middleFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, 0, 90));
                GameObject rightFlameInstance = Instantiate(flamePrefab, transform.position, Quaternion.Euler(0, -30, 90));

                // set the direction the instance will move according to its rotation
                leftFlameInstance.GetComponent<Flame>().order = "left";
                middleFlameInstance.GetComponent<Flame>().order = "middle";
                rightFlameInstance.GetComponent<Flame>().order = "right";

                // set the throwing direction of the instantiated flames equal to that of the flamethrower
                leftFlameInstance.GetComponent<Flame>().goingRight = throwingRight;
                middleFlameInstance.GetComponent<Flame>().goingRight = throwingRight;
                rightFlameInstance.GetComponent<Flame>().goingRight = throwingRight;

                // wait for "throwRate" seconds before instantiating another row of flames
                yield return new WaitForSeconds(flameRate);
            }
            // if the time since the loop started has passed 5 seconds then wait for "flameDelay" seconds before throwing flames agian
            else
            {
                yield return new WaitForSeconds(flameDelay);
                startTime = Time.time;
            }

            // waits until the end of the frame for a clean start before throwing flames again
            yield return new WaitForEndOfFrame();
        }        
    }
}