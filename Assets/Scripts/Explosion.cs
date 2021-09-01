using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
         Invoke("DestroySelf", 1f);
    }

    void Update()
    {
        
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
