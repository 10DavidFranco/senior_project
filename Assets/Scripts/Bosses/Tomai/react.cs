using UnityEngine;

public class react : MonoBehaviour
{
    public Rigidbody2D rb;
    public float move_speed;
    public bool flip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flip = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flip)
        {
            rb.linearVelocity = new Vector2(-move_speed, 0f);
        }
        else
        {
            rb.linearVelocity = new Vector2(move_speed, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "react_end")
        {
            flip = true;
        }
    }
}
