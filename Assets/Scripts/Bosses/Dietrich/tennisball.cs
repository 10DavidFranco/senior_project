using UnityEngine;

public class tennisball : MonoBehaviour
{
    public float ball_speed;
    public Rigidbody2D rb;
    private Transform p_t;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        p_t = GameObject.Find("Player").GetComponent<Transform>();

        float lastxposition = (this.transform.position.x - p_t.position.x) * -1.0f; //Fire burst in straight line by referring to last known position
        float lastyposition = (this.transform.position.y - p_t.position.y); //Player will always be beneath so turn negative

        lastyposition += Random.Range(-3.0f, 3.0f);

        ball_speed += Random.Range(-100f, 100f);

        rb.AddForce(new Vector2(lastxposition, lastyposition).normalized * ball_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if(col.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
        
    }
}
