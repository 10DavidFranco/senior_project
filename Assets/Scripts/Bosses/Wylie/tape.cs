using UnityEngine;

public class tape : MonoBehaviour
{
    
    public Rigidbody2D player_rb;
    public float tape_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.layer == 10)
        {
            //Debug.Log(col.gameObject.name);
            //player_rb = col.gameObject.GetComponent<Rigidbody2D>();
            player_rb.AddForce(Vector3.right * tape_speed);
        }
        

    }
}
