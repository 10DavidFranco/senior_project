using UnityEngine;

public class lightning : MonoBehaviour
{

    public GameObject hb;

    void Start()
    {
        hb.SetActive(false);
    }

    public void EnableHB()
    {
        hb.SetActive(true);
    }

    public void DisableHB()
    {
        hb.SetActive(false);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
