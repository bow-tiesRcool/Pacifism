using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour
{
    public static MultiplierSpawner instance;
    public MultiplierController DNAPrefab;

    private List<MultiplierController> MultiplierPool = new List<MultiplierController>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static void SpawnMultiplier(Vector3 position)
    {
        instance.MultiplierCreator(position);
    }

    void MultiplierCreator(Vector3 position)
    {
        MultiplierController multiplier = null;
        for (int i = 0; i < MultiplierPool.Count; i++)
        {
            if (!MultiplierPool[i].gameObject.activeSelf)
            {
                multiplier = MultiplierPool[i];
                break;
            }
        }
        if (multiplier == null)
        {
            multiplier = Instantiate(DNAPrefab) as MultiplierController;
            MultiplierPool.Add(multiplier);
        }
        multiplier.gameObject.SetActive(true);
        multiplier.transform.position = position;
    }
}