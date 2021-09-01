using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounds : MonoBehaviour
{
    public bool vertical = false;
    public GameOver gameOver;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject != null && col.tag.Equals("Enemy")) {
            if (vertical && gameOver != null) {
                gameOver.OnGameOver();
                return;
            }

            if (!vertical) {
                Enemy.hzSpeed = -Enemy.hzSpeed;
            }
        }
    }
}
