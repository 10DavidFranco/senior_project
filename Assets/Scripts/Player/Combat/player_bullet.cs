using System.Collections;
using UnityEngine;

public class player_bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool isBoomerang = false;
    public bool isLob = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite[] bulletSprites; // for the different bullets
    private SpriteRenderer spriteRenderer;
    private Transform player;
    private float boomerangReturn = 0.8f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (bulletSprites != null && bulletSprites.Length > 0)
        {
            spriteRenderer.sprite = bulletSprites[Random.Range(0, bulletSprites.Length)];
        }
        
        player = GameObject.FindWithTag("Player")?.transform;
    }
    public void Shoot(Vector3 direction)
    {
        if (isLob)
        {
            // Enable gravity for arc shot
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 2f;

            // Give it an upward/forward velocity
            Vector2 launchVelocity = new Vector2(direction.x, Mathf.Abs(direction.y) + 1f) * (speed * 0.6f);
            rb.linearVelocity = launchVelocity;

            
        }
        else if (isBoomerang)
        {
            rb.bodyType = RigidbodyType2D.Kinematic; // control manually
            rb.gravityScale = 0f;
            StartCoroutine(BoomerangRoutine(direction));
        }
        else
        {
            // normal bullet (single or shotgun)
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.linearVelocity = direction * speed;
        }
    }

    private IEnumerator BoomerangRoutine(Vector3 direction)
    {
        float timer = 0f;
        //float forwardTime = boomerangReturn;
        bool returning = false;

        while (true)
        {
            timer += Time.deltaTime;

            if (!returning)
            {
                // move forward
                transform.position += direction * speed * Time.deltaTime;
                if (timer >= boomerangReturn)
                {
                    returning = true;
                    timer = 0f;
                }
            }
            else
            {
                // return to player
                if (player == null) break;
                Vector3 toPlayer = (player.position - transform.position).normalized;
                transform.position += toPlayer * speed * 1.2f * Time.deltaTime;

                if (Vector3.Distance(transform.position, player.position) < 0.5f)
                    break;
            }

            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Prevent early destruction for boomerangs/lobs if desired
        if (!isBoomerang)
        {
            Destroy(gameObject);
        }
    }

}
