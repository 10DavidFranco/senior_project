using UnityEngine;

public class jump_check : MonoBehaviour
{
    public player_move pm;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        pm.Jumping();

    }
}
