using UnityEngine;

public class player_movement : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;
    public float move_speed;

    //to maintain the current direction the player is moving in.
    private bool hold = false;
    
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

            if (!hold)
            {
                anim.SetBool("right", true);
            }
           
            rb.linearVelocity = new Vector2(move_speed, rb.linearVelocity.y);
            hold = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!hold)
            {
                anim.SetBool("left", true);
            }
            
            rb.linearVelocity = new Vector2(-move_speed, rb.linearVelocity.y);
            hold = true;
        }
        else
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            hold = false;
        }
    }

    private void checkV()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!hold)
            {
                anim.SetBool("up", true);
            }
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, move_speed);
            hold = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!hold)
            {
                anim.SetBool("down", true);
            }
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -move_speed);
            hold = true;
        }
        else
        {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            hold = false;
        }
    }
}
