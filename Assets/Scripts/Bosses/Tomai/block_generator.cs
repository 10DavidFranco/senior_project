using UnityEngine;
using System.Collections;

public class block_generator : MonoBehaviour
{
    public GameObject html_prefab;
    public GameObject css_prefab;
    public GameObject async_prefab;

    public Transform html_spawn;
    public Transform css_spawn;
    public Transform async_spawn;

    public float spawn_delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MidStairs()
    {
        StartCoroutine(twoStairs());
    }

    public void spawnUpwards()
    {
        StartCoroutine(upwardStairs());
    }

    public void spawnDownwards()
    {
        StartCoroutine(downwardStairs());
    }

    public void spawnHTML()
    {
        Instantiate(html_prefab, html_spawn.position, html_spawn.rotation);
    }

    IEnumerator twoStairs()
    {
        Instantiate(html_prefab, html_spawn.position, html_spawn.rotation);
        yield return new WaitForSeconds(spawn_delay);
        Instantiate(css_prefab, css_spawn.position, css_spawn.rotation);
    }

    IEnumerator upwardStairs()
    {
        Instantiate(html_prefab, html_spawn.position, html_spawn.rotation);
        yield return new WaitForSeconds(spawn_delay);
        Instantiate(css_prefab, css_spawn.position, css_spawn.rotation);
        yield return new WaitForSeconds(spawn_delay);
        Instantiate(async_prefab, async_spawn.position, async_spawn.rotation);

    }

    IEnumerator downwardStairs()
    {
        Instantiate(async_prefab, async_spawn.position, async_spawn.rotation);
        yield return new WaitForSeconds(spawn_delay);
        Instantiate(css_prefab, css_spawn.position, css_spawn.rotation);
        yield return new WaitForSeconds(spawn_delay);
        Instantiate(html_prefab, html_spawn.position, html_spawn.rotation);
    }
}
