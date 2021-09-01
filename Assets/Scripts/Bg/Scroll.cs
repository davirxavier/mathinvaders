using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    private Renderer back;
    public float vel = 1f;
    public GameObject player;
    Rigidbody2D body;
    void Start () {
        back = GetComponent<Renderer> ();
        body = player.GetComponent<Rigidbody2D>();
    }

    void Update () {
    }
}