using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float lookAhead = 1;
    public float speed = 3;
    Rigidbody2D body;
    Renderer renderer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        Vector2 target = (Vector2)PlayerController.player.transform.position + PlayerController.player.body.velocity * lookAhead;
        Vector2 heading = (target - (Vector2)transform.position).normalized;
        body.velocity = heading * speed;

        if (body.velocity.sqrMagnitude > 0.1f)
        {
            transform.right = body.velocity;
        }
        ClampToScreen(renderer.bounds.extents.x);
        ClampToScreen(-renderer.bounds.extents.x);
        ClampToScreen(renderer.bounds.extents.y);
        ClampToScreen(-renderer.bounds.extents.y);
    }

    void ClampToScreen(float xOffset)
    {
        Vector3 v = Camera.main.WorldToViewportPoint(transform.position + Vector3.right * xOffset);
        v.x = Mathf.Clamp01(v.x);
        transform.position = Camera.main.ViewportToWorldPoint(v) - Vector3.right * xOffset;

        Vector3 u = Camera.main.WorldToViewportPoint(transform.position + Vector3.down * xOffset);
        u.y = Mathf.Clamp01(u.y);
        transform.position = Camera.main.ViewportToWorldPoint(u) - Vector3.down * xOffset;
    }
}
