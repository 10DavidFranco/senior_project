using UnityEngine;

public class middlestairs : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name);
    }
}
