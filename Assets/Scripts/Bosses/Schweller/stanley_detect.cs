using UnityEngine;

public class stanley_detect : MonoBehaviour
{
    public stanley st;
    public bool player_near;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_near = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 10)//player
        {
            st.Attack();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 10)//player
        {
            st.StopAttack();
        }
    }
}
