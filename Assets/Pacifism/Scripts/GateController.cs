using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public int points = 5;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("Entered Gate");
            gameObject.SetActive(false);
            GameManager.Points(1,points);
            ExplosionSpawner.SpawnExplosion(transform.position);

        }

    }

}
