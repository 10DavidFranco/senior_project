using UnityEngine;

public class thunderbolt : MonoBehaviour
{

    public float move_speed;
    public Rigidbody2D rb;
    public wylie_duo wd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        wd = this.transform.parent.parent.GetComponent<wylie_duo>();
        Debug.Log(wd);
    }

    void Awake()
    {
        wd = this.transform.parent.parent.GetComponent<wylie_duo>();
        Debug.Log(wd);
    }

    // Update is called once per frame
    void Update()
    {
        if (wd.facing_left)
        {
            rb.linearVelocity = new Vector2(-move_speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(move_speed, 0);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }


}
