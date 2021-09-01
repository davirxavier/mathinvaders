using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : Enemy
{
    public GenericEnemyController enemyController;
    public GameObject laser;
    private List<GameObject> instantiatedLasers = new List<GameObject>();
    private List<GameObject> instantiatedEnemies = new List<GameObject>();
    private string[] possibleActions = new string[]{"ShootStraight", "ShootDiagonal", "ShootQuickChange"};
    private string lastAction;
    private int currentMove = -1;
    private bool isWinding = false;
    public BossLaser() {
        health = 20;
        destroyPoints = 1000;
    }
    override public void InitEnemy()
    {
        isWinding = true;
        Invoke("ShootStraight", Random.Range(1.5f, 3.5f));
        if (enemyController == null) {
            var obj = GameObject.FindGameObjectWithTag("EnemyController");
            if (obj != null) {
                enemyController = obj.GetComponent<GenericEnemyController>();
            }
        }
    }

    public override void UpdateEnemy()
    {
        instantiatedLasers.RemoveAll(l => l == null);
        instantiatedEnemies.RemoveAll(e => e == null);

        if (instantiatedLasers.Count == 0 && !isWinding && instantiatedEnemies.Count == 0) {
            isWinding = true;
            lastAction = possibleActions[Random.Range(0, possibleActions.Length)];
            Invoke(lastAction, 2f);
        } else if (instantiatedLasers.Count == 0 && !isWinding) {
            isWinding = true;
            Invoke(lastAction, 2f);
        }
    }

    override public void Shoot()
    {
    }

    public override void DamageEnemy()
    {
        PlayerScore.AddPoints(10);
    }

    public void ShootStraight() 
    {
        isWinding = true;
        var pos = gameObject.transform.position;
        pos = new Vector3(pos.x, pos.y - 1.5f, pos.z);
        
        var instLaser = Instantiate(laser, pos, Quaternion.identity);
        instantiatedLasers.Add(instLaser);

        if (enemyController != null) {
            instantiatedEnemies = enemyController.SpawnEnemies(new int[][] {
                new int[]{00, 00, -1, -1, -1, 00, 00},
                  new int[]{-1, -1, -1, -1, -1, -1},
                new int[]{-1, -1, -1, -1, -1, -1, -1},
            }, true).ConvertAll<GameObject>(e => e.gameObject);
        }
        isWinding = false;
    }

    public void ShootStraightQuick() 
    {
        isWinding = true;
        var pos = gameObject.transform.position;
        pos = new Vector3(pos.x, pos.y - 1.5f, pos.z);
        
        var instLaser = Instantiate(laser, pos, Quaternion.identity);
        var laserScr1 = instLaser.GetComponent<Laser>();
        laserScr1.uptime = 2.5f;
        laserScr1.speed = -20f;
        instantiatedLasers.Add(instLaser);
        isWinding = false;
    }

    public void ShootDiagonal() {
        isWinding = true;
        var pos = gameObject.transform.position;
        pos = new Vector3(pos.x, pos.y - 1.5f, pos.z);

        Vector3 difference1 = new Vector3(-10, -6, 0) - pos;
        float rotationZ1 = Mathf.Atan2(difference1.y, difference1.x) * Mathf.Rad2Deg + 90;

        Vector3 difference2 = new Vector3(10, -6, 0) - pos;
        float rotationZ2 = Mathf.Atan2(difference2.y, difference2.x) * Mathf.Rad2Deg + 90;
        
        var instLaser = Instantiate(laser, pos, Quaternion.Euler(0.0f, 0.0f, rotationZ1));
        instantiatedLasers.Add(instLaser);

        var inst2Laser = Instantiate(laser, pos, Quaternion.Euler(0.0f, 0.0f, rotationZ2));
        instantiatedLasers.Add(inst2Laser);

        if (enemyController != null) {
            instantiatedEnemies = enemyController.SpawnEnemies(new int[][] {
                new int[]{2, -1, -1, -1, -1, -1, 2},
                  new int[]{-1, -1, -1, -1, -1, -1},
                new int[]{-1, -1, -1, -1, -1, -1, -1},
            }, true).ConvertAll<GameObject>(e => e.gameObject);
        }
        isWinding = false;
    }

    public void ShootDiagonalQuick() {
        isWinding = true;
        var pos = gameObject.transform.position;
        pos = new Vector3(pos.x, pos.y - 1.5f, pos.z);

        Vector3 difference1 = new Vector3(-10, -6, 0) - pos;
        float rotationZ1 = Mathf.Atan2(difference1.y, difference1.x) * Mathf.Rad2Deg + 90;

        Vector3 difference2 = new Vector3(10, -6, 0) - pos;
        float rotationZ2 = Mathf.Atan2(difference2.y, difference2.x) * Mathf.Rad2Deg + 90;
        
        var instLaser = Instantiate(laser, pos, Quaternion.Euler(0.0f, 0.0f, rotationZ1));
        var laserScr1 = instLaser.GetComponent<Laser>();
        laserScr1.uptime = 2.5f;
        laserScr1.speed = -20f;
        instantiatedLasers.Add(instLaser);

        var inst2Laser = Instantiate(laser, pos, Quaternion.Euler(0.0f, 0.0f, rotationZ2));
        var laserScr2 = inst2Laser.GetComponent<Laser>();
        laserScr2.uptime = 2.5f;
        laserScr2.speed = -20f;
        instantiatedLasers.Add(inst2Laser);

        isWinding = false;
    }

    public void ShootQuickChange() {
        isWinding = true;
        var shootCount = Random.Range(3, 6);
        var option = Random.Range(0, 2);;
        for (var i = 0; i < shootCount; i++) {
            Invoke(option == 0 ? "ShootDiagonalQuick" : "ShootStraightQuick", 2.8f * i);
            option = option == 0 ? 1 : 0;
        }

        isWinding = false;
    }

}
