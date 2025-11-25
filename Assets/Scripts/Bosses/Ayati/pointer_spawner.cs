using UnityEngine;
using System.Collections;

public class pointer_spawner : MonoBehaviour
{
    public GameObject pointer_prefab;
    public Transform left_spawn;
    public Transform right_spawn;
    public Transform mid_spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnOnePointer()
    {
        Instantiate(pointer_prefab, mid_spawn);
    }

    public void SpawnThreePointers(float delay)
    {
        StartCoroutine(sthp(delay));
    }

    IEnumerator sthp(float d)
    {
        Instantiate(pointer_prefab, left_spawn.position, left_spawn.rotation);
        yield return new WaitForSeconds(d);
        Instantiate(pointer_prefab, mid_spawn.position, mid_spawn.rotation);
        yield return new WaitForSeconds(d);
        Instantiate(pointer_prefab, right_spawn.position, right_spawn.rotation);
    }
}
