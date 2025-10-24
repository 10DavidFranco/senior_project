using UnityEngine;

public class stanley : MonoBehaviour
{
    public Animator slash_anim;
    public Animator anim;
    public GameObject detect;
    //public stanley_detect sd;
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        //detect = sd.GetComponent<stanley_detect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        anim.SetBool("swing", true);
    }

    public void StopAttack()
    {
        anim.SetBool("swing", false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.layer == 13)
        {
            health--;
            if(health <= 0)
            {
                anim.SetBool("die", true);
            }
        }
        //Debug.Log(col);
    }

    public void Die()
    {
        Destroy(detect);
        Destroy(gameObject);
    }

    public void EnableSwingBox()
    {
        slash_anim.SetBool("swing", true);
    }

    public void Disable_SwingBox()
    {
        slash_anim.SetBool("swing", false);
    }
}
