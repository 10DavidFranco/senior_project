using UnityEngine;

public class npc_spawner : MonoBehaviour
{


    public GameObject hector_dsa;
    public GameObject rudy_dsa;
    public GameObject sean_dsa;
    public GameObject fernie_dsa;
    public GameObject manny_dsa;
    public GameObject steven_dsa;
    public GameObject guillermo_dsa;

    public Transform h_dsa;
    public Transform r_dsa;
    public Transform s_dsa;
    public Transform f_dsa;
    public Transform m_dsa;
    public Transform st_dsa;
    public Transform g_dsa;

    public GameObject hector;
    public GameObject rudy;
    public GameObject sean;
    public GameObject fernie;
    public GameObject manny;
    public GameObject steven;
    public GameObject guillermo;

    public Transform h;
    public Transform r;
    public Transform s;
    public Transform f;
    public Transform m;
    public Transform st;
    public Transform g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("fought_schweller") == 0)
        {
            spawnline();
        }
        else
        {
            spawnfloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnline()
    {
        Instantiate(hector_dsa, h_dsa.position, h_dsa.rotation);
        Instantiate(rudy_dsa, r_dsa.position, r_dsa.rotation);
        Instantiate(sean_dsa, s_dsa.position, s_dsa.rotation);
        Instantiate(fernie_dsa, f_dsa.position, f_dsa.rotation);
        Instantiate(manny_dsa, m_dsa.position, m_dsa.rotation);
        Instantiate(steven_dsa, st_dsa.position, st_dsa.rotation);
        Instantiate(guillermo_dsa, g_dsa.position, g_dsa.rotation);
    }

    void spawnfloor()
    {
        Instantiate(hector, h.position, h.rotation);
        Instantiate(rudy, r.position, r.rotation);
        Instantiate(sean, s.position, s.rotation);
        Instantiate(fernie, f.position, f.rotation);
        Instantiate(manny, m.position, m.rotation);
        Instantiate(steven, st.position, st.rotation);
        Instantiate(guillermo, g.position, g.rotation);
    }
}
