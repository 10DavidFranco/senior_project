using UnityEngine;

public class player_bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Shoot()
    {
        rb.linearVelocity = transform.right * speed;
    }
    public void ShootUp()
    {
        rb.linearVelocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        Destroy(gameObject);
    }
}
