using UnityEngine;

public class ram0s_bullet : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rb;

    public bool bouncemode = false;
    public float bouncespeed = 8f;

    public float lifetime = 5f;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 2f);

        Destroy(gameObject, lifetime);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   


    public void Launch(Vector2 direction)
    {
        rb.linearVelocity = direction * speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (bouncemode)
        {
            // current velocity
            Vector2 v = rb.linearVelocity;

            // if somehow stopped, give it a tiny kick
            if (v.sqrMagnitude < 0.01f)
                v = Random.insideUnitCircle.normalized * bouncespeed;

            // reflect off the surface
            Vector2 n = col.contacts[0].normal;
            Vector2 reflected = Vector2.Reflect(v, n);

            rb.linearVelocity = reflected.normalized * bouncespeed;

            // nudge it slightly away from the surface so it doesn't stay glued to it
            transform.position = col.contacts[0].point + n * 0.05f;

            if (col.collider.CompareTag("Player"))
                Destroy(gameObject);

            return;
        }

        // non-bounce mode behaviour (phase 1)
        if (col.collider.CompareTag("wall") || col.collider.CompareTag("Floor") || col.collider.CompareTag("Player"))
            Destroy(gameObject);
    }

}
