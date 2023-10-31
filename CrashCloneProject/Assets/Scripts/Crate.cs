using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject wumpaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestryCrate()
    {
        gameObject.SetActive(false);
        GameObject wumpaInstance = Instantiate(wumpaPrefab, transform.position, transform.rotation);
      
    }

}
