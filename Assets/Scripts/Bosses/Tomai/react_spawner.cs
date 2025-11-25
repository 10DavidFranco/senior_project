using UnityEngine;
using System.Collections;

public class react_spawner : MonoBehaviour
{
    public Transform low_pos;
    public Transform mid_pos;
    public Transform high_pos;
    


    public Transform react_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLow()
    {
        Instantiate(react_prefab, low_pos.position, low_pos.rotation);
    }

    public void SpawnMid()
    {
        Instantiate(react_prefab, mid_pos.position, mid_pos.rotation);
    }

    public void SpawnHigh()
    {
        Instantiate(react_prefab, high_pos.position, high_pos.rotation);
    }

    public void LowToHigh(float delay)
    {
        StartCoroutine(LTH(delay));
    }

    IEnumerator LTH(float d)
    {
        SpawnLow();
        yield return new WaitForSeconds(d);
        SpawnMid();
        yield return new WaitForSeconds(d);
        SpawnHigh();
    }
}
