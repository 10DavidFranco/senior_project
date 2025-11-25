using UnityEngine;

public class nullptr : MonoBehaviour
{
    public Rigidbody2D rb;
    public float move_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(-move_speed, rb.linearVelocity.y);
    }
}
