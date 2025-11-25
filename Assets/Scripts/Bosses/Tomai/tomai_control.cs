using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class tomai_control : MonoBehaviour
{
    public int health;
    private int cast_hook_low = 0;
    private int cast_hook_mid = 1;

    public battle_cam bc;
    private bool dieonce;



    public block_generator b_g;
    public hook_generator hk;
    public react_spawner rg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(first_phase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator first_phase() 
    {
        yield return new WaitForSeconds(1.0f);
        b_g.spawnHTML();
        yield return new WaitForSeconds(1.0f);
        hk.CastHook(cast_hook_low);
        yield return new WaitForSeconds(5.0f);
        rg.SpawnLow();
        //b_g.spawnUpwards();
        //hk.CastHook(cast_hook_low);
        //rg.LowToHigh(1.0f);
        yield return new WaitForSeconds(5.0f);
        b_g.spawnHTML();
        yield return new WaitForSeconds(2.0f);
        rg.SpawnLow();
        yield return new WaitForSeconds(4.0f);
        b_g.MidStairs();
        yield return new WaitForSeconds(4.0f);
        hk.CastHook(cast_hook_mid);
        yield return new WaitForSeconds(3.0f);
        rg.SpawnLow();
        yield return new WaitForSeconds(5.0f);
        rg.LowToHigh(1.0f);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(SecondPhase());
        
        
        //rg.LowToHigh(.5f);
        //hk.CastHook(cast_hook_mid);
        //b_g.spawnDownwards();
    }

    IEnumerator SecondPhase()
    {
        while(health > 0)
        {
            rg.LowToHigh(1.0f);
            yield return new WaitForSeconds(5.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            health--;
            checkDeath();
            Debug.Log("HIT!");
        }

    }

    IEnumerator Die()
    {
        //Player wins!!!
        bc.Pass();
        //Graduate????
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("current_boss", 5);
        SceneManager.LoadScene("start_menu");
    }

    void checkDeath()
    {
        if (health <= 0 && !dieonce)
        {

            dieonce = !dieonce;
            StartCoroutine(Die());

        }
    }
}
