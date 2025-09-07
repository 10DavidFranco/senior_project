using UnityEngine;

public class lb : MonoBehaviour
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
        cam.colleft = true;
        Debug.Log("colliding left");
    }
}
