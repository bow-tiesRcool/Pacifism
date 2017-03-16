using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierController : MonoBehaviour {

    public int multi = 1;
    public static MultiplierController instance;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.Points(multi,2);
        }
    }
}
