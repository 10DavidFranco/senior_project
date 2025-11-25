using UnityEngine;

public class BeeSwarm : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public float hoverAmount = 0.3f;
    public float hoverSpeed = 3f;

    [Header("Health")]
    public int health = 1;
    public float lifetime = 8f;

    private Transform player;
    private float hoverOffset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hoverOffset = Random.Range(0f, 10f); // randomize hover phase

        Destroy(gameObject,lifetime);

    }

    void Update()
    {
        if (!player) return;

        // Chase movement
        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;

        // Hover bobbing
        float hover = Mathf.Sin((Time.time + hoverOffset) * hoverSpeed) * hoverAmount;
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + hover * Time.deltaTime,
            transform.position.z
        );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Bullet check by tag
        if (col.CompareTag("p_bullet"))
        {
            TakeDamage(1);
        }

        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        { 
                Destroy(gameObject);
            
        }
    }

    
}
