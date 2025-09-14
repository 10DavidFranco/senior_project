using UnityEngine;

public class f_spawn : MonoBehaviour
{

    public GameObject funcA;
    public GameObject funcB;
    public GameObject funcC;

    public Transform spawn_point;
    
    public void A()
    {
        Instantiate(funcA, spawn_point);
    }

    public void B()
    {
        Instantiate(funcB, spawn_point);
    }

    public void C()
    {
        Instantiate(funcC, spawn_point);
    }
}
