using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour {

    public GateController gatePrefab;
    List<GateController> gatePool = new List<GateController>();

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
        for(int amount = 0; amount < GameManager.instance.maxGates; amount++)
        {
            for (int i = 0; i < 1; i++)
            {
                GateController g = SpawnGate();
                Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
                worldPosition.z = 0;
                g.transform.position = worldPosition;
             }
            Debug.Log("Instantiation " + amount);
            yield return new WaitForSeconds(GameManager.instance.spawnInterval);
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

        gate.gameObject.SetActive(true);

        return gate;
    }
}
