using UnityEngine;

public class cslab : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name);
    }
}
