using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool enemyBullet = true;
    public float speed = 1;
    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        Vector2 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector2(pos.x, pos.y - speed * Time.deltaTime * (enemyBullet ? 1 : -1));
    }

    void OnBecameInvisible() {
         Destroy(gameObject);
    }
}
