using UnityEngine;
using System.Collections;

public class wylie_duo : MonoBehaviour
{
    public int health;
    public float intro_delay;
    public float schweller_delay;

    public bool dashing;
    public float dash_speed;
    public float dash_delay;
    private bool only_flip_once;
    public bool facing_left;

    public float l_delay;
    public float l_burst;
    public GameObject lightning_prefab;
    public Transform l_spawn;

    public Animator anim;
    public Rigidbody2D rb;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 2;
        facing_left = true;
        only_flip_once = false;
        l_burst = 3;
        l_delay = 1.0f;
        dashing = false;
        dash_delay = 3.0f;
        StartCoroutine(FirstPhase());
        //StartAnimatorDash();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashing)
        {
            if (facing_left)
            {
                rb.linearVelocity = new Vector2(-dash_speed, 0f);
            }
            else
            {
                rb.linearVelocity = new Vector2(dash_speed, 0f);
            }
            
            //Debug.Log("DASHING!!!!");
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, 0f);
        }
    }

    

    IEnumerator FirstPhase()
    {
        yield return new WaitForSeconds(intro_delay + schweller_delay);


        while(health > 0)
        {
            for (int i = 0; i < l_burst; i++)
            {
                StartAnimShootLightning();
                yield return new WaitForSeconds(l_delay);
            }
            StopAnimShootLightning();
            yield return new WaitForSeconds(2.0f);
            StartAnimatorDash();
            yield return new WaitForSeconds(dash_delay);
            for (int i = 0; i < l_burst; i++)
            {
                StartAnimShootLightning();
                yield return new WaitForSeconds(l_delay);
            }
            StopAnimShootLightning();
            yield return new WaitForSeconds(2.0f);
            StartAnimatorDash();
            yield return new WaitForSeconds(dash_delay);
        }
        
        


    }
    
    /// ////////////////////////////////////////////////////////////////////////
    //DASH (dashes across the screen, need to implement flipping logic)
    void StartAnimatorDash()
    {
        only_flip_once = false;
        anim.SetBool("dash", true);
    }

    void StartPhysicalDash()
    {

        dashing = true;
        Debug.Log("dashing has been activated!");
    }

    void StopDash() //When will this execute? When it does, flip the sprite. (missing one step beforehand to check for finish)
    {
        dashing = false;
        anim.SetBool("dash", false);
        this.gameObject.transform.Rotate(0f, 180f, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "wall" && !only_flip_once)
        {
            Debug.Log("You hit a wall!");
            StopDash();
            only_flip_once = true;
            facing_left = !facing_left;
        }else if(col.gameObject.layer == 13)
        {
            health--;
            checkDeath();
        }
        else
        {

        }
    }

    void checkDeath()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    ///////////////////////////////////////////////////////////////////////////////
    
    /// ///////////////////////////////////////////////////////////////////////////
    //LIGHTNING (play around with the idea of shooting more than one bolt.)
    void StartAnimShootLightning()
    {
        anim.SetBool("lightning", true);
    }
    void StopAnimShootLightning()
    {
        anim.SetBool("lightning", false);
    }

    void ShootLightning()
    {
      
        Instantiate(lightning_prefab, l_spawn.position, l_spawn.rotation, l_spawn);
       
    }
    ////////////////////////////////////////////////////////////////////////////////
}
