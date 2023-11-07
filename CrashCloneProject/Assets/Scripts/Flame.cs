using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed = 5f;
    public bool goingRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay(2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    // waits for "delayTime" seconds and despawns object
    IEnumerator DespawnDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}