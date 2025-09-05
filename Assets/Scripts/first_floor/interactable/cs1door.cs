using UnityEngine;

public class cs1door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name);
    }
}
