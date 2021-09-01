using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : Enemy
{
    public GameObject bullet;

    public HeavyEnemy() {
        health = 3;
        destroyPoints = 10;
    }
    override public void InitEnemy()
    {
        Invoke("Shoot", Random.Range(1.5f, 3.5f));
    }

    public override void UpdateEnemy()
    {
    }

    override public void Shoot()
    {
        Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Invoke("Shoot", Random.Range(1.5f, 3.5f) - ((hzSpeed/2)*100));
    }

    public override void DamageEnemy()
    {
        PlayerScore.AddPoints(5);
    }
}
