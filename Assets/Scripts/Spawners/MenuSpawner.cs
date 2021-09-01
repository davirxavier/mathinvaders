using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    public GameObject dummy;
    private List<GameObject> currentEnemies = new List<GameObject>();

    void Start()
    {
        var time = Random.Range(2f, 5f);
        for (var i = 0; i < Random.Range(1, 4); i++) {
            Invoke("SpawnEnemy", Random.Range(time-2f, time));
        }
    }

    void Update()
    {
    }

    void SpawnEnemy() 
    {
        SpawnEnemyBase(true);
    }

    void SpawnEnemyNonRecursive() 
    {
        SpawnEnemyBase(false);
    }

    void SpawnEnemyBase(bool recursive) 
    {
        var euler = Quaternion.identity.eulerAngles;
        var rot = Quaternion.Euler(euler.x, euler.y, euler.z);
        var pos = new Vector3(Random.Range(-6.2f, 6.2f), transform.position.y, transform.position.z);

        var enemy = Instantiate(dummy, pos, rot);
        currentEnemies.Add(enemy);

        if (recursive) {
            var time = Random.Range(5f, 10f);
            Invoke("SpawnEnemy", Random.Range(time-2f, time));
            for (var i = 0; i < Random.Range(0, 9); i++) {
                Invoke("SpawnEnemyNonRecursive", Random.Range(time-2f, time));
            }
        }
    }
}
