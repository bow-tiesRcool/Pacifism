using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierController : MonoBehaviour {

    public int multi = 1;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.Points(multi,0);
        }
    }
}
