using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;
    public float move_speed;
    public bool plaque_view;
    //public InteractionDetector interact;

    //to maintain the current direction the player is moving in.
    private bool hold = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public AudioSource footstepSource;
    public AudioClip footstepClip;


    void Start()
    {
        plaque_view = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!plaque_view)
        {
            checkH();
            checkV();
            checkEscape();
        }

        //checkI();

        HandleFootsteps();
        
    }

    private void checkEscape()
    {
        //Eventually, put an "Are you Sure you want to exit screen."
        //but for now...
        if (Input.GetButton("Cancel") && plaque_view == false)
        {
            Debug.Log("plaque view was: " + plaque_view);
            SceneManager.LoadScene("start_menu");
        }
    }
    private bool IsMoving()
    {
        return rb.linearVelocity.sqrMagnitude > 0.01f;
    }


    /*private void checkI()
    {
        if (interact.close_to_interact)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Executing");
            }
        }
    }*/

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

    private void HandleFootsteps()
    {
        if (IsMoving())
        {
            if (!footstepSource.isPlaying)
            {
                footstepSource.clip = footstepClip;
                footstepSource.Play();
            }
        }
        else
        {
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
            }
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
