using UnityEngine;
using System.Collections;

public class ayati_floor : MonoBehaviour
{
    public Rigidbody2D player;
    public player_move p_script;
    public float upward_force;
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
        if(col.gameObject.name == "JumpCheck")
        {
            Debug.Log("The player hit us!!!!!");
            player.AddForce(transform.up * upward_force, ForceMode2D.Impulse);
        }
    }
}
