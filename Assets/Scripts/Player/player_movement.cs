using UnityEngine;

public class player_movement : MonoBehaviour
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
        checkH();
        checkV();

        
    }

    private void checkH()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(move_speed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector2(-move_speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }

    private void checkV()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, move_speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -move_speed);
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); ;
        }
    }
}
