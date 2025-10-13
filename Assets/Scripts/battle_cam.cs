using UnityEngine;

public class battle_cam : MonoBehaviour
{
    public GameObject p_screen;
    public GameObject f_screen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pass()
    {
        Instantiate(p_screen, this.transform);
    }


    public void Fail()
    {
        Instantiate(f_screen, this.transform);
    }
}
