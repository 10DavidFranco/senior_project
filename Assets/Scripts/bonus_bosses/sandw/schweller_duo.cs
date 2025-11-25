using UnityEngine;
using System.Collections;

public class schweller_duo : MonoBehaviour
{
    public int health;
    public Animator anim;
    public Rigidbody2D rb;
    public float walk_speed;
    public float swing_delay;
    public bool is_walking;
    public bool walk_once;
    public float intro_delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 2;
        walk_once = false; //remove this walk once security check for a cool "leap swing" (or set walk_once to always false)
        StartCoroutine(FirstPhase());
    }

    // Update is called once per frame
    void Update()
    {
        if (is_walking)
        {
            rb.linearVelocity = new Vector2(walk_speed, 0f);
        }
        else
        {

        }
    }

    IEnumerator FirstPhase()
    {
        yield return new WaitForSeconds(intro_delay);
        StartWalking();
        yield return new WaitForSeconds(1.0f);

    }

    void StartWalking()
    {
        //is_walking = true;
        anim.SetBool("is_walking", true);
    }

    void StartPhysicalWalking()
    {

        //if phase 2, do other branch without switch.


        //if phase 1 do this.
        if (!walk_once)
        {
            is_walking = true;
            walk_once = !walk_once;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.name == "schweller_half")
       {
            Debug.Log("SWINGING");
            anim.SetBool("is_walking", false);
            is_walking = false;
            rb.linearVelocity = new Vector2(0f, 0f);
            anim.SetBool("hammer_swing", true);
       }else if(col.gameObject.name == "schweller_teleport")
       {
            Teleport();
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
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void StopSwinging()
    {
        walk_once = false;
        anim.SetBool("hammer_swing", false);
        StartWalking();
    }

    void Teleport()
    {
        this.gameObject.transform.position = new Vector3(10f, 1.78f, -3f);
    }

    //walk to half

    //regsiter half

    //attack

    //walk off

    //reappear
}
