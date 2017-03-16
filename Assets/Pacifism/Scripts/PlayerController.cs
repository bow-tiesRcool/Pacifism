using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController player;
    public ParticleSystem Death;

    Rigidbody2D _body;
    Renderer renderer;
    public Rigidbody2D body
    {
        get {
                if (_body == null)
                {
                    _body = GetComponent<Rigidbody2D>();
                }
                return _body;
            }
    }

    void Awake()
    {
        if (player == null)
        {
            player = this;
        }
    }

    void Start ()
    {
        renderer = GetComponentInChildren<Renderer>();
    }
    
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        body.velocity = new Vector2(x, y) * GameManager.instance.playerSpeed;

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

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            //Death.Play();
            GameManager.GameOver();
        }
    }
}
