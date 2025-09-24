using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    private GameObject new_b;
    public player_move pm;

    private float xdirection;
    private float ydirection;
    //Animator animator;
    //AudioSource AudioSource;
    void Start()
    {

        xdirection = 1f;
        ydirection = 0f;
        //animator = GetComponent<Animator>();
       // AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightControl) && pm.isGrounded)
        {
            pm.isAiming = true;

            if (Input.GetButtonDown("Fire1"))
            {
                if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    xdirection = 1f;
                    ydirection = 1f;
                    Shoot();
                }
                else if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
                {
                    xdirection = -1f;
                    ydirection = 1f;
                    Shoot();
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    xdirection = 0f;
                    ydirection = 1f;
                    Shoot();
                }else if (Input.GetKey(KeyCode.RightArrow))
                {
                    xdirection = 1f;
                    ydirection = 0f;
                    Shoot();
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    xdirection = -1f;
                    ydirection = 0f;
                    Shoot();
                }

            }
        }
        else
        {
            pm.isAiming = false;

            if (Input.GetButtonDown("Fire1"))
            {

                if (pm.isFacingRight)
                {
                    xdirection = 1f;
                    ydirection = 0f;
                    Shoot();
                }
                else
                {
                    xdirection = -1f;
                    ydirection = 0f;
                    Shoot();
                }

            }
        }

        
       
    }


    //IDEA: Have each direction manipulate some sort of x and y direction variable. These variables will be used to both set the spawn direction 
    //of the bullet, and also the direction of the vector

    void Shoot()
    {
        new_b = Instantiate(bulletPrefab, firepoint.position + new Vector3(xdirection * 1.5f, ydirection* 1.5f, -2f), firepoint.rotation); //spawning just outside of player sprite
        new_b.GetComponent<player_bullet>().Shoot(new Vector3(xdirection, ydirection, -2f).normalized);
    }

    
}
