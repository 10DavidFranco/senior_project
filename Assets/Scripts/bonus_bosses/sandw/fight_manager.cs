using UnityEngine;
using UnityEngine.SceneManagement;

public class fight_manager : MonoBehaviour
{
    public bool s_dead;
    public bool w_dead;
    public battle_cam bc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        s_dead = false;
        w_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkDead()
    {
        if(s_dead && w_dead)
        {
            bc.Pass();
            SceneManager.LoadScene("bonus_bosses");
        }
    }
}
