using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericEnemyController : MonoBehaviour
{
    public GameObject[] enemies;
    public bool autoPassLevel = true;
    private Dictionary<int, List<Enemy>> instantiatedEnemies;
    private bool loadedNext = false;
    private int initialCount = 0;

    void Start()
    {
        var bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var bullet in bullets) {
            Destroy(bullet);
        }

        instantiatedEnemies = new Dictionary<int, List<Enemy>>();
        initialCount = 0;
        Enemy.hzSpeed = ConstantValues.minEnemyHzSpeed;
        Enemy.vrSpeed = ConstantValues.minEnemyVrSpeed;

        var currentEnemies = LevelEnemies.getLevelEnemies(ConstantValues.currentLevel);
        if (currentEnemies != null) {
            SpawnEnemies(currentEnemies);
        }
    }

    void Update()
    {
        var count = 0;
        foreach (KeyValuePair<int, List<Enemy>> entry in instantiatedEnemies) {
            foreach (var enm in entry.Value) {
                if (enm != null) {
                    count += enm.Health;
                }
            }
        }
        var lerpHz = Mathf.Lerp(ConstantValues.maxEnemyHzSpeed, ConstantValues.minEnemyHzSpeed, (float)count/(float)initialCount);
        Enemy.hzSpeed = Enemy.hzSpeed < 0 ? -lerpHz : lerpHz;

        var lerpVr = Mathf.Lerp(ConstantValues.maxEnemyVrSpeed, ConstantValues.minEnemyVrSpeed, (float)count/(float)initialCount);
        Enemy.vrSpeed = Enemy.vrSpeed < 0 ? -lerpVr : lerpVr;

        if (count == 0 && !loadedNext && autoPassLevel) {
            ConstantValues.currentLevel++;
            loadedNext = true;
            Invoke("LoadNext", 3f);
        }
    }

    void LoadNext() {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }

    public List<Enemy> SpawnEnemies(int[][] enemyIds, bool setStatic = false) {
        var positions = ConstantValues.positions;
        var ret = new List<Enemy>();

        for (var i = 0; i < positions.Length; i++) {
            var row = positions[i];
            List<Enemy> enemyList = null;
            instantiatedEnemies.TryGetValue(i, out enemyList);
            if (enemyList == null) {
                enemyList = new List<Enemy>();
                instantiatedEnemies.Add(i, enemyList);
            }

            if (row != null) {
                for (var j = 0; j < row.Length; j++) {
                    var enemyId = enemyIds[i][j];
                    if (enemyId >= 0) {
                        var col = row[j];
                        var instantiated = Instantiate(enemies[enemyId], col, Quaternion.identity);

                        var enemyScript = instantiated.GetComponent<Enemy>();
                        if (setStatic) {
                            enemyScript.isStatic = true;
                        }
                        enemyScript.targetPosition = col;
                        enemyScript.row = i;
                        initialCount += enemyScript.Health;

                        enemyList.Add(enemyScript);
                        ret.Add(enemyScript);
                    }
                }
            }
        }

        return ret;
    }
}
