using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    private GameObject new_b;
    public player_move pm;

    public Sprite[] singleShotSprites;

    private float xdirection;
    private float ydirection;
    //Animator animator;
    //AudioSource AudioSource;

    // controll the firing mode
    // 

    [Header("Bullet Colors")]
    private Color singleShotColor = Color.gray;
    private Color shotgunColor = Color.magenta;
    private Color boomerangColor = Color.cyan;
    private Color lobColor = Color.red;


    public enum FireMode
    {
        SingleShot,
        Shotgun,
        Boomerang,
        lob
    }
    public FireMode currentMode;




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
        switch (currentMode)
        {
            case FireMode.SingleShot:
                SingleShot();
                break;
            case FireMode.Shotgun:
                Shotgun();
                break;
            case FireMode.Boomerang:
                Boomerang();
                break;
            case FireMode.lob:
                Lob();
                break;
        }
    }


    void SingleShot()
    {
        new_b = Instantiate(bulletPrefab, firepoint.position + new Vector3(xdirection * 1.5f, ydirection* 1.5f, -2f), firepoint.rotation); //spawning just outside of player sprite
        var bullet = new_b.GetComponent<player_bullet>();
        bullet.bulletSprites = singleShotSprites;

        new_b.GetComponent<SpriteRenderer>().color = singleShotColor;

        // fire it
        bullet.Shoot(new Vector3(xdirection, ydirection, -2f).normalized);

        //trying stuff out to make the sprites bigger.
        //new_b.transform.localScale = Vector3.one * 1.5f; // make 1.5× larger

    }





    void Shotgun()
    {
        // Base direction 
        Vector3 baseDir = new Vector3(xdirection, ydirection, 0f).normalized;

        // The angle spread
        float spreadAngle = 15f; // can change for a wider/narrower cone

        // Create 3 bullets: center, left, right
        for (int i = -1; i <= 1; i++)
        {
            // Calculate rotation for each bullet
            float angle = spreadAngle * i;
            Vector3 rotatedDir = Quaternion.Euler(0, 0, angle) * baseDir;

            // Spawn bullet
            GameObject new_bullet = Instantiate(
                bulletPrefab,
                firepoint.position + rotatedDir * 1.5f,
                Quaternion.identity
            );

          
            var bullet = new_bullet.GetComponent<player_bullet>();
            bullet.bulletSprites = singleShotSprites;


            new_bullet.GetComponent<SpriteRenderer>().color = shotgunColor;

            // Fire it in its rotated direction
            bullet.Shoot(rotatedDir);


            //just destroys shortly after being shot 
            Destroy(new_bullet, 0.25f);

        }
    }
    void Boomerang()
    {
        Vector3 dir = new Vector3(xdirection, ydirection, 0f).normalized;

        GameObject new_b = Instantiate(bulletPrefab,firepoint.position + dir * 1.5f,Quaternion.identity );

        var bullet = new_b.GetComponent<player_bullet>();
        bullet.bulletSprites = singleShotSprites;
        bullet.isBoomerang = true; // tell the bullet to come back

        new_b.GetComponent<SpriteRenderer>().color = boomerangColor;

        bullet.Shoot(dir);
    }
    void Lob()
    {
        Vector3 dir = new Vector3(xdirection, ydirection, 0f).normalized;

        GameObject new_b = Instantiate(bulletPrefab, firepoint.position + dir * 1.5f, Quaternion.identity);

        var bullet = new_b.GetComponent<player_bullet>();
        bullet.bulletSprites = singleShotSprites;
        bullet.isLob = true; // tell the bullet to lob back


        new_b.GetComponent<SpriteRenderer>().color = lobColor;

        bullet.Shoot(dir);
    }



}
