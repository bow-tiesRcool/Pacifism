using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public EnemyController enemyPrefab;
    List<EnemyController> enemyPool = new List<EnemyController>();

    void Start()
    {
        StartCoroutine("SpawnCoroutine");
    }

    void OnEnabled()
    {
        StartCoroutine("SpawnCoroutine");
    }

    IEnumerator SpawnCoroutine()
    {
        while (enabled)
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyController e = SpawnEnemy();
                e.transform.position = transform.position + (Vector3)Random.insideUnitCircle;
            }
            yield return new WaitForSeconds(3);
        }
    }

    EnemyController SpawnEnemy()
    {
        EnemyController enemy = null;
        for (int i = 0; i < enemyPool.Count; i++)
        {
            EnemyController e = enemyPool[i];
            if (!e.gameObject.activeSelf)
            {
                enemy = e;
                break;
            }
        }

        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as EnemyController;
            enemyPool.Add(enemy);
        }

        enemy.gameObject.SetActive(true);
        return enemy;
    }
}
