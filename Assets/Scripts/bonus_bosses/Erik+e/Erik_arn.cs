using UnityEngine;

public class ArmAttack : MonoBehaviour
{
    public Vector3 offScreenPos;
    public Vector3 attackPos;
    public float speed = 10f;

    private bool attacking;

    void Start()
    {
        transform.position = offScreenPos;
    }

    void Update()
    {
        if (attacking)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                attackPos,
                speed * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                offScreenPos,
                speed * Time.deltaTime
            );
        }
    }

    public void Attack()
    {
        attacking = true;
    }

    public void Retract()
    {
        attacking = false;
    }
}
