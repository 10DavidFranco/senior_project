using System.Collections;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour
{

    [Header("Dashing")]
    public float dashspeed = 20f;
    public float dashduration = 0.5f;
    public float dashcooldown = 0.1f;
    private Vector2 dashingdir;
    bool isDashing;
    bool canDash = true;
    TrailRenderer trailRenderer;
    public int health = 3;


    float horizontalInput;
    public float moveSpeed = 25f;
    bool isFacingRight = false;
    public float jumpPower = 30f;
    public bool isGrounded = false;


    public float iduration;
    private bool hittable;
    


    Rigidbody2D rb;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
        hittable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        flipchecker();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);

        }

        

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        checkDeath();
    }

    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("xVelocity", math.abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        dashingdir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dashingdir == Vector2.zero)
        {
            if (!isFacingRight)
            {
                dashingdir = new Vector2(transform.localScale.x, 0f);
            }
            else
            {
                dashingdir = new Vector2(-transform.localScale.x, 0f);
            }
        }
        rb.linearVelocity = dashingdir.normalized * dashspeed;
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashduration);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashcooldown);
        canDash = true;


    }



    private void flipchecker()
    {
        if (horizontalInput > 0 && isFacingRight)
        {
            FlipSprite();
        }
        else if (horizontalInput < 0 && !isFacingRight)
        {
            FlipSprite();
        }
    }
    void FlipSprite()
    {

        isFacingRight = !isFacingRight;
        transform.Rotate(1f, 180f, 0f);
    }

    public void Jumping()
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }


    
    








    ///DAMAGE
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (hittable)
        {
            Debug.Log(other);
            if (other.gameObject.CompareTag("bullet"))
            {
                Debug.Log("Player has been hit!!!");

                health--;
                hittable = false;
                Debug.Log(health);
                checkDeath();

                StartCoroutine(iFrames());
            }
        }
        
    }

    IEnumerator iFrames()
    {
        yield return new WaitForSeconds(iduration);
        hittable = true;
    }

    private void checkDeath()
    {
        if (health <= 0)
        {
            Debug.Log("You Lost...");
            SceneManager.LoadScene("first_floor");
        }
    }




}