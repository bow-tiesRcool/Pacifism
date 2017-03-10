using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour {

    public GateController gatePrefab;
    List<GateController> gatePool = new List<GateController>();
    public int maxGates = 20;
    public int spawnInterval = 5;

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
        for(int amount = 0; amount < maxGates; amount++)
        {
            for (int i = 0; i < 1; i++)
            {
                GateController g = SpawnGate();
                Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
                g.transform.position = transform.position + screenPosition;
             }
            Debug.Log("Instantiation " + amount);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    GateController SpawnGate()
    {
        GateController gate = null;

        for (int i = 0; i < gatePool.Count; i++)
        {
            GateController g = gatePool[i];
            if (!g.gameObject.activeSelf)
            {
                gate = g;
                break;
            }
        }

        if (gate == null)
        {
            gate = Instantiate(gatePrefab) as GateController;
            gatePool.Add(gate);
        }

        return gate;
    }
}
