using UnityEngine;
using System.Collections;

public class pointer : MonoBehaviour
{
    public Transform player;
    public float x_factor;
    public float y_factor;
    private bool chase;
    public Rigidbody2D rb;
    public float move_speed;
    public float rotation_counter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player 1").transform;
        chase = false;
        this.transform.Rotate(0f, 180f, 0f);
        StartCoroutine(FollowPlayer());
        rotation_counter = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chase)
        {
            //fire pointer
            rb.linearVelocity = new Vector2(-x_factor, -y_factor);
            
        }
        else
        {
            //rotate to face player
            //this.transform.rotation = new Vector3(this.transform.rotation.x, this.transform.rotation.y, rotation_counter);
            //rotation_counter += 1;
        }
    }

    void snapshot_player()
    {
        x_factor = this.gameObject.transform.position.x - player.position.x;
        y_factor = this.gameObject.transform.position.y - player.position.y;
        this.gameObject.transform.right = player.position - this.gameObject.transform.position;
    }

    IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        snapshot_player();
        chase = true;
    }
}
