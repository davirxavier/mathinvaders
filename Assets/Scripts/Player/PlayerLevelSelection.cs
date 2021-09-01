using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSelection : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 5;
    public float angularSpeed = 0.3f;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GameMenu.paused) {
            body.AddForce(transform.right * Input.GetAxis("Vertical") * speed);
            transform.Rotate(0f, 0f, -Input.GetAxis("Horizontal") * angularSpeed);
            body.velocity = transform.right * body.velocity.magnitude;
        }
    }
}
