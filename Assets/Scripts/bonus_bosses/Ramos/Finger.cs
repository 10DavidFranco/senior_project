using UnityEngine;

public class Finger : MonoBehaviour
{
    public float speed = 12f;
    private Vector2 fireDirection;
    private bool fired = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // stay frozen until fired
    }

    public void SetDirection(Vector2 dir)
    {
        fireDirection = dir.normalized;
    }

    public void Fire()
    {
        fired = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = fireDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Destroy when hitting floor/wall
        if (col.collider.CompareTag("wall") || col.collider.CompareTag("Floor")|| col.collider.CompareTag("Player"))
            Destroy(gameObject);
    }
}
