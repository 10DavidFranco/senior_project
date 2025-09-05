using UnityEngine;

public class leftstairs : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name);
    }
}
