using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public GameObject bubble;
    public GameObject deathExpl;
    public float speed = 0;
    public int health = 3;
    public bool flashing = false;
    bool hasShield = false;
    Rigidbody2D body;
    SpriteRenderer shipRenderer;
    SpriteRenderer bubbleRenderer;
    public GameOver gameOver;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        shipRenderer = gameObject.GetComponent<SpriteRenderer>();
        bubbleRenderer = bubble.GetComponent<SpriteRenderer>();

        if (healthText != null) {
            healthText.text = "x" + health;
        }
    }

    void Update()
    {
        if (!GameMenu.paused) {
            body.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed));
            
            Vector2 v = body.velocity;
            transform.rotation = Quaternion.AngleAxis(22 * v.x/10 * -1, Vector3.forward);

            if (health <= 0) {
                if (gameOver != null) {
                    gameOver.OnGameOver();
                }
                Instantiate(deathExpl, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
    }

    void OnTriggerEnter2D(Collider2D col) {
        var obj = col.gameObject;
        if (obj != null && obj.tag.Equals("Bullet") && obj.GetComponent<Bullet>().enemyBullet) {
            if (!flashing) {
                Damage();
                Destroy(obj);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        var obj = col.gameObject;
        if (obj != null) {
            var laser = obj.GetComponentInParent<Laser>();
            if (!flashing && laser != null && laser.enemyLaser) {
                Damage();
            }
        }
    }

    public void Damage() {
        if (hasShield) {
            StartCoroutine(callFlashBubble());
        } else {
            PlayerScore.AddPoints(-5);
            health--;
            if (healthText != null) {
                healthText.text = "x" + health;
            }
            StartCoroutine(callFlash());
        }
    }

    IEnumerator callFlash() {
        flashing = true;
        yield return Utils.FlashSprites(new SpriteRenderer[]{shipRenderer}, 5, 0.2f, true);
        flashing = false;
    }
    
    IEnumerator callFlashBubble() {
        flashing = true;
        yield return Utils.FlashSprites(new SpriteRenderer[]{bubbleRenderer}, 5, 0.2f, true);
        flashing = false;
        DeactivateShield();
    }

    public void ActivateShield() {
        hasShield = true;
        bubble.SetActive(true);
    }

    public void DeactivateShield() {
        hasShield = false;
        bubble.SetActive(false);
    }
}
