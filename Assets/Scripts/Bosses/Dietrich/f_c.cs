using UnityEngine;

public class f_c : MonoBehaviour
{
    private dietrich d_script;
    public Animator anim;
    private bool attack_executed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        d_script = GameObject.Find("Dietrich").GetComponent<dietrich>();
    }

    // Update is called once per frame
    void Update()
    {
        if (d_script.call)
        {
            anim.SetBool("call", true);
            if (!attack_executed)
            {
                Attack();

            }
        }
        else
        {
            attack_executed = false;
            anim.SetBool("call", false);
        }
    }

    private void Attack()
    {
        attack_executed = true;
        Debug.Log("C_attacking");
    }
}
