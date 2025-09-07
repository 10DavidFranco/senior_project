using UnityEngine;

public class bb : MonoBehaviour
{
    public camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        cam.coldown = true;
        Debug.Log("colliding down");
    }
}
