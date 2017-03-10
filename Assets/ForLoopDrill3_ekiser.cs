using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopDrill3_ekiser : MonoBehaviour {

    public GameObject prefab;
    public int prefabsPerSpawn = 10;
    public float maxSpawnDistance;
    public float spawnInterval = 3;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for (int t = 0; t < 50; t++)
        {
            for (int i = 0; i < prefabsPerSpawn; i++)
            {
                Instantiate(prefab, transform.position + Random.insideUnitSphere * maxSpawnDistance, Quaternion.identity);
            }
            Debug.Log("Instantiation " + t);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
