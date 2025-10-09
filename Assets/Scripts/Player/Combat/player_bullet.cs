using UnityEngine;

public class player_bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite[] bulletSprites; // for the different bullets
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (bulletSprites != null && bulletSprites.Length > 0)
        {
            spriteRenderer.sprite = bulletSprites[Random.Range(0, bulletSprites.Length)];
        }
    }
    public void Shoot(Vector3 direction)
    {
        rb.linearVelocity = direction * speed;
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
