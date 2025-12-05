using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{

    public GameObject player;
    private bool colliding = false;
    private bool plaque_switch;

    public bool colleft;
    public bool colright;
    public bool colup;
    public bool coldown;

    public float leftbound;
    public float rightbound;
    public float upbound;
    public float downbound;

    public GameObject plaque_prefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colleft = false;
        colright = false;
        colup = false;
        coldown = false;
        plaque_switch = false;
        PlayerPrefs.SetInt("python", 1);
        //player = GameObject.Find("Player");
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
            if (colleft && coldown || colleft && colup || coldown && colright) //if we are at the corner of the map, camera should not move. But we should still check for when we leave the area to restore control.
            {
                //Debug.Log("Corner collision");
                checkRight();
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


        if(player.GetComponent<player_movement>().plaque_view == false && plaque_switch)
        {
            plaque_switch = !plaque_switch;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        colliding = true; //if we collide with camera boundaries, enable us to start checking which boundaries we collided with
        //Debug.Log("colliding");
    }

    void checkNoCollisions()
    {
        if (!colleft && !colright && !colup && !coldown) //if no collisions are occurring on any axis, restore control to follow player freely
        {
            //Debug.Log("Youre not colliding with anything!");
            colliding = false;
        }
    }

   

    void checkCollisions()
    {
        if (colleft)
        {

            transform.position = new Vector3(leftbound, player.transform.position.y, -6f); //execute the movement of the camera, stay constant with the left buondary of the map, but move vertically with the player
            checkLeft(); //make sure the camera does not go out of map boundaries

        }
        if (coldown)
        {
            transform.position = new Vector3(player.transform.position.x, downbound, -6f);
            checkDown();
        }
        if (colright)
        {
            transform.position = new Vector3(rightbound, player.transform.position.y, -6f);
            checkRight();
        }
        if (colup)
        {
            transform.position = new Vector3(player.transform.position.x, upbound, -6f); //these hardcoded values are close to the limits where the camera meets the walls, get it just right to reduce jumpiness

            checkUp();
        }
    }

    void checkLeft()
    {
        //These bounds are thresholds for the player!!!!!! they should be set to the halfway point of the camera when collidng with a wall to ensure a smooth detachment
        //The blueon the left of the screen is not related to these bounds...


        //No no no, these arrreeee thresholds for the camera, so we just need to reduce the left threshold so no outside area shows.
        if (player.transform.position.x > leftbound) //If no longer colliding with wall, set that direction collision to false
        {
            colleft = false;
            //colliding = false;
        }
    }

    void checkUp()
    {
        if (player.transform.position.y < upbound)
        {
            colup = false;
            //colliding = false;
        }
    }

    void checkDown()
    {
        if (player.transform.position.y > downbound)
        {
            coldown = false;
            //colliding = false;
        }
    }

    void checkRight()
    {
        if (player.transform.position.x < rightbound)
        {
            colright = false;
            //colliding = false;
        }
    }

   

    public void showPlaque()
    {

        if (!plaque_switch)
        {
            player.GetComponent<player_movement>().plaque_view = true;
            StartCoroutine(spawnPlaque());
            
            plaque_switch = !plaque_switch;
        }
       
    } 
        
    IEnumerator spawnPlaque()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(plaque_prefab, this.transform);
    }
}
