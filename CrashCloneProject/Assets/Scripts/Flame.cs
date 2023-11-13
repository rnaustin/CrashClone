using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed = 2f;
    public float driftSpeed = 1.5f;
    public float despawntime = 2.5f;

    public bool goingRight;

    public string order = "left";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay(despawntime));
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

    /// <summary>
    /// waits for "delayTime" seconds and despawns object
    /// </summary>
    /// <param name="delayTime"> number of seconds before the flame despawns </param>
    /// <returns></returns>
    IEnumerator DespawnDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}