using UnityEngine;
using System.Collections;

public class f_a : MonoBehaviour
{
    public int health;

    public float burst_count;
    public float bullet_speed;
    public float burst_time;

    public GameObject bullet;
    private GameObject new_b;
    private Rigidbody2D b_rb;
    public Rigidbody2D rb;

    private Transform p_t;

    private dietrich d_script;
    public Animator anim;
    private bool attack_executed = false;

    private bool strafe_left = true;
    public float strafe_speed;
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

        if(this.transform.position.x < 2.0f || this.transform.position.x > 13.0f)
        {
            strafe_left = !strafe_left;
        }

        

        if (strafe_left && this.transform.position.x > 2.0f)
        {
            rb.linearVelocity = new Vector2(-strafe_speed, rb.linearVelocity.y);
        }else if (!strafe_left && this.transform.position.x < 13.0f)
        {
            rb.linearVelocity = new Vector2(strafe_speed, rb.linearVelocity.y);
        }else
        {

        }
    }

    private void Attack()
    {
        attack_executed = true;
        Debug.Log("A_attacking");


        StartCoroutine(Burst());
        
    }

    IEnumerator Burst()
    {
        

        
        float lastxposition = (this.transform.position.x - p_t.position.x) * -1.0f; //Fire burst in straight line by referring to last known position
        float lastyposition =  (this.transform.position.y - p_t.position.y) * -1.0f; //Player will always be beneath so turn negative



        for (int i = 0; i < burst_count; i++)
        {
            new_b = Instantiate(bullet, this.transform);
            b_rb = new_b.GetComponent<Rigidbody2D>();
            b_rb.AddForce(new Vector2(lastxposition, lastyposition).normalized * bullet_speed);
            yield return new WaitForSeconds(burst_time);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 13)
        {
            health--;

            checkDeath();
        }
    }

    void checkDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
