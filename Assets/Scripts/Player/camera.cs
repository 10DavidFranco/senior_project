using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject player;
    private bool colliding = false;

    public bool colleft;
    public bool colright;
    public bool colup;
    public bool coldown;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colleft = false; 
        colright = false; 
        colup = false; 
        coldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!colliding)
        {
            transform.position = player.transform.position + new Vector3(0f, 0f, -6f);
        }
        else
        {
            if(colleft && coldown || colleft && colup) //if we are at the corner of the map, camera should not move. But we should still check for when we leave the area to restore control.
            {
                Debug.Log("Corner collision");
                
                checkLeft();
                checkDown();
                checkUp();
            }
            else
            {
                checkCollisions();
            }
            /*if(colleft && colup)
            {
                Debug.Log("Up left!");
                
                checkLeft();
                checkUp();
            }
            else
            {
                checkCollisions();
            }*/
            //set public varaibles to detect collsions from different directions
            //assignscripts toscreen boundaries to modify their respective direction collision
            //if a certain direction collision hastriggered, check player.transform.position.x or y value to see if it goes above threshold
            //to give cam control back to player.

            

            

            checkNoCollisions();
        }
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        colliding = true; //if we collide with camera boundaries, start checking which boundaries we collided with
        //Debug.Log("colliding");
    }

    void checkNoCollisions()
    {
        if(!colleft && !colright && !colup && !coldown) //if no collisions are occurring on any axis, restore control to follow player freely
        {
            Debug.Log("Youre not colliding with anything!");
            colliding = false;
        }
    }

    void checkCollisions()
    {
        if (colleft)
        {

            transform.position = new Vector2(0f, player.transform.position.y); //execute the movement of the camera
            checkLeft(); //make sure the camera does not go out of map boundaries

        }
        if (coldown)
        {
            transform.position = new Vector2(player.transform.position.x, 0f);
            checkDown();
        }
        if (colright)
        {
            transform.position = new Vector2(72f, player.transform.position.y); 
            checkRight();
        }
        if (colup)
        {
            transform.position = new Vector2(player.transform.position.x, 12.8f); //these hardcoded values are close to the limits where the camera meets the walls, get it just right to reduce jumpiness

            checkUp();
        }
    }

    void checkLeft()
    {
        if (player.transform.position.x > -0.16f) //If no longer colliding with wall, set direction collision to false
        {
            colleft = false;
            //colliding = false;
        }
    }

    void checkUp()
    {
        if (player.transform.position.y < 12.4f)
        {
            colup = false;
            //colliding = false;
        }
    }

    void checkDown()
    {
        if (player.transform.position.y > 0f)
        {
            coldown = false;
            //colliding = false;
        }
    }

    void checkRight()
    {
        if (player.transform.position.x < 72f)
        {
            colright = false;
            //colliding = false;
        }
    }
  
}
