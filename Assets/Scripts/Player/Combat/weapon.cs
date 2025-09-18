using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    private GameObject new_b;
    //Animator animator;
    //AudioSource AudioSource;
    void Start()
    {
        //animator = GetComponent<Animator>();
       // AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Firing up");
            ShootUp();
        }
        else if (Input.GetButtonDown("Fire1")) //make if else branches/send signal to bullet for path
        {
            //animator.SetBool("isAttacking", true);
            Shoot();
            //AudioSource.Play();
        }
        else
        {

        }
    }

    void Shoot()
    {
        new_b = Instantiate(bulletPrefab, firepoint.position + new Vector3(2f, 0f, -2f), firepoint.rotation);
        new_b.GetComponent<player_bullet>().Shoot();
    }

    void ShootUp()
    {
        new_b = Instantiate(bulletPrefab, firepoint.position + new Vector3(0f, 2f, -2f), firepoint.rotation);
        new_b.GetComponent<player_bullet>().ShootUp();
    }

    /*public void endAttack()
    {
        animator.SetBool("isAttacking", false);
    }*/
}
