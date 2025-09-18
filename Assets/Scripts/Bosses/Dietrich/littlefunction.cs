using UnityEngine;

public class littlefunction : MonoBehaviour
{

    public Animator anim;

    public void positionLeft()
    {
        transform.position = new Vector3(3.98f, 5.73f, -3);
        anim.SetBool("drop", true);
    }

    public void positionRight()
    {
        transform.position = new Vector3(10.95f, 5.73f, -3);
        anim.SetBool("drop", true);
    }

    public void finishDrop()
    {
        anim.SetBool("drop", false);
    }

}
