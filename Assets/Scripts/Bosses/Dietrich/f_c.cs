using UnityEngine;

public class f_c : MonoBehaviour
{
    public int health;

    private dietrich d_script;
    public Animator anim;
    private bool attack_executed = false;

    private bool strafe_left = true;
    public float strafe_speed;
    public Rigidbody2D rb;

    private Transform p_t;


    public GameObject bullet;
    private GameObject new_b;
    private Rigidbody2D b_rb;
    public float bullet_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;
        d_script = GameObject.Find("Dietrich").GetComponent<dietrich>();
        p_t = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (d_script.call)
        {
            anim.SetBool("call", true);
            if (!attack_executed)
            {
                Attack();

            }
        }
        else
        {
            attack_executed = false;
            anim.SetBool("call", false);
        }

        if (this.transform.position.x < 2.0f || this.transform.position.x > 13.0f)
        {
            strafe_left = !strafe_left;
        }



        if (strafe_left && this.transform.position.x > 2.0f)
        {
            rb.linearVelocity = new Vector2(-strafe_speed, rb.linearVelocity.y);
        }
        else if (!strafe_left && this.transform.position.x < 13.0f)
        {
            rb.linearVelocity = new Vector2(strafe_speed, rb.linearVelocity.y);
        }
        else
        {

        }
    }

    private void Attack()
    {
        attack_executed = true;
        Debug.Log("C_attacking");

        float lastxposition = (this.transform.position.x - p_t.position.x) * -1.0f; //Fire burst in straight line by referring to last known position
        float lastyposition = (this.transform.position.y - p_t.position.y) * -1.0f; //Player will always be beneath so turn negative

      
        float diffx = (this.transform.position.x - p_t.position.x); //Fire burst in straight line by referring to last known position
        float diffy = (this.transform.position.y - p_t.position.y); //Player will always be beneath so turn negative
        float angle = -diffx / diffy;

        angle = Mathf.Atan(angle);
        angle = angle * Mathf.Rad2Deg;

        Debug.Log(diffx);
        Debug.Log(diffy);
        //Debug.Log(Mathf.Rad2Deg);
        Debug.Log("OG ANGLE");
        Debug.Log(angle);

        /*if(angle > 90f)
        {
            angle -= 180f;
        }*/

        

        /*Debug.Log("NEW ANGLE");
        Debug.Log(angle);*/


        
        new_b = Instantiate(bullet, this.transform);
        new_b.transform.Rotate(0f,0f, angle);
        b_rb = new_b.GetComponent<Rigidbody2D>();
        b_rb.AddForce(new Vector2(lastxposition, lastyposition).normalized * bullet_speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            health--;
            checkDeath();
        }
    }

    void checkDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
