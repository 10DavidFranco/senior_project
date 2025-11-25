using UnityEngine;

public class hook : MonoBehaviour
{

    
    
    public float move_speed;
    public float y_factor;
    public Rigidbody2D rb;
    public float center_line;
    public bool going_down;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        going_down = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y < center_line - .5f && going_down)
        {
            //go up
            going_down = false;
        }
        else if(this.gameObject.transform.position.y > center_line + .5f && !going_down)
        {
            //go down
            rb.linearVelocity = new Vector2(-move_speed, -y_factor);
            going_down = true;
        }
        else
        {
            
        }

        if (going_down)
        {
            rb.linearVelocity = new Vector2(-move_speed, -y_factor);
        }
        else
        {
            rb.linearVelocity = new Vector2(-move_speed, y_factor);
        }

        
    }

   

    
}
