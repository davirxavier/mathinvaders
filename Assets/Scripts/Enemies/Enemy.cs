using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public static float hzSpeed = ConstantValues.minEnemyHzSpeed;
    public static float vrSpeed = ConstantValues.minEnemyVrSpeed;
    public bool isStatic = false;
    public int row = 0;
    public string[] operations = new string[]{"+", "-", "*", "/"};
    protected int health;
    public Operation operation;
    public int Health {get{return health;}}
    public GameObject deathExpl;
    Rigidbody2D body;
    public int destroyPoints = 5;
    SpriteRenderer enemyRenderer;
    GameObject player;
    public Vector2 targetPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        body = gameObject.GetComponent<Rigidbody2D>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();

        transform.position = new Vector2(targetPosition.x, targetPosition.y + 10);
        CalculateOperations();
        InvokeRepeating("MoveDown", 0f, 0.7f);
        InitEnemy();
    }

    void Update()
    {
        if (transform.position.y > targetPosition.y) {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5*Time.deltaTime);
            return;
        }
        UpdateEnemy();
        if (!isStatic && !GameMenu.paused) {
            transform.position = new Vector2(transform.position.x + hzSpeed, transform.position.y);
        }

        if (health == 0) {
            PlayerScore.AddPoints(5);
            Instantiate(deathExpl, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void MoveDown() 
    {
        if (!isStatic) {
            body.AddForce(new Vector2(0, -vrSpeed));
        }
    }

    public abstract void InitEnemy();

    public abstract void UpdateEnemy();

    public abstract void Shoot();

    public abstract void DamageEnemy();

    public void Damage() {
        health--;
        StartCoroutine(Utils.FlashSprites(new SpriteRenderer[]{enemyRenderer}, 1, 0.2f, true));
        CalculateOperations();

        DamageEnemy();
    }

    protected void CalculateOperations() {
        operation = MathHelper.CalculateOperations(operations);

        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = operation.firstOperand + " " + operation.operation + " " + operation.secondOperand;
    }
}
