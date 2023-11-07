using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed = 3f;
    public float driftSpeed = 2f;
    public bool goingRight;

    public string order = "left";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay(3f));
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (order == "left")
            {
                transform.position += Vector3.back * driftSpeed * Time.deltaTime;

            }
            if (order == "right")
            {
                transform.position += Vector3.forward * driftSpeed * Time.deltaTime;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (order == "left")
            {
                transform.position += Vector3.forward * driftSpeed * Time.deltaTime;

            }
            if (order == "right")
            {
                transform.position += Vector3.back * driftSpeed * Time.deltaTime;
            }
        }
    }

    // waits for "delayTime" seconds and despawns object
    IEnumerator DespawnDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}