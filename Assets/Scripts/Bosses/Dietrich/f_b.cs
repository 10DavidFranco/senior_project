using UnityEngine;

public class f_b : MonoBehaviour
{
    public int health;

    private dietrich d_script;
    public Animator anim;
    private bool attack_executed = false;

    private bool strafe_left = true;
    public float strafe_speed;
    public Rigidbody2D rb;


    public GameObject lightning;
    public GameObject l_spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;
        d_script = GameObject.Find("Dietrich").GetComponent<dietrich>();
        l_spawn = GameObject.Find("Lightning_Spawn");
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
        Debug.Log("B_attacking");

        Instantiate(lightning, l_spawn.transform);
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
