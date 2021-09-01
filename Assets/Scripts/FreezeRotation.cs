using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(x, y, z);
    }
}
