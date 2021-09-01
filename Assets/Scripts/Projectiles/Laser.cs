using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public bool enemyLaser = true;
    public GameObject helper;
    public GameObject trail;
    public float uptime = 5f;
    public float speed = 1;
    public float initialVSize = 1;
    public float maxSize = 10;
    float currentSize = 1;
    public float maxWidth = 1;
    public float minWidth = 1;
    public float widthSpeed = 0.01f;
    bool adding = false;
    bool dying = false;
    Renderer trailRenderer;
    void Start()
    {
        trailRenderer = trail.GetComponent<Renderer>();
        currentSize = initialVSize;

        Invoke("Die", uptime);
    }

    void Update()
    {
        var scale = helper.transform.localScale;
        var width = scale.x + (adding && !dying ? widthSpeed : -widthSpeed) * Time.deltaTime;
        if (dying && width <= 0) {
            Invoke("DestroySelf", 0.3f);
            return;
        }

        var height = scale.y;
        if (scale.y < maxSize) {
            var calcSpeed = speed * Time.deltaTime;
            height = scale.y + calcSpeed;

        }

        if (width > maxWidth) {
            adding = false;
        }

        if (width < minWidth) {
            adding = true;
        }

        helper.transform.localScale = new Vector3(width, height, scale.z);

        // end.transform.localScale = new Vector3(width, width, end.transform.localScale.z);
        // end.transform.position = new Vector3(0, trail.transform.position.y + (speed >= 0 ? trailRenderer.bounds.size.y : -trailRenderer.bounds.size.y)/2, 0);
    }

    void Die() {
        dying = true;
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
