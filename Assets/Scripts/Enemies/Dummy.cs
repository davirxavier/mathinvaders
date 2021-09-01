using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed = 10;

    void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length-1)];
        speed = Random.Range(10f, 16f);
    }

    void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + (-speed * Time.deltaTime), pos.z);
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
