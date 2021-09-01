using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public bool oneBulletATime = false;
    public GameObject bullet;
    GameObject instantiatedBullet;
    
    public float shootDelay = 0;
    public float bulletYDiff = 0;
    public float bulletXDiff = 0;

    public int pointsPerDmg = 5;

    public SimpleEnemy() {
        health = 1;
    }
    override public void InitEnemy()
    {
        Invoke("Shoot", Random.Range(1.5f, 3.5f) + shootDelay - ((hzSpeed/2)*100));

        operations = new string[]{"+", "-"};
        CalculateOperations();
    }

    public override void UpdateEnemy()
    {
    }

    override public void Shoot()
    {
        if (!oneBulletATime || (oneBulletATime && instantiatedBullet == null)) {
            var pos = gameObject.transform.position;
            pos = new Vector3(pos.x + bulletXDiff, pos.y + bulletYDiff, pos.z);
            
            instantiatedBullet = Instantiate(bullet, pos, Quaternion.identity);
        }

        Invoke("Shoot", Random.Range(1.5f, 3.5f) + shootDelay);
    }

    public override void DamageEnemy()
    {
        PlayerScore.AddPoints(pointsPerDmg);
    }
}
