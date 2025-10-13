using UnityEngine;

public class gameManager : MonoBehaviour
{

    public int questions;
    public int boss;
    public GameObject halfway;
    public bool upstairs_left;
    public bool upstairs_middle;

    public bool cs1;
    public bool cs2;

    //public GameObject plaque;
    //public Image cs1_p;
    //public Image cs2_p;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questions = PlayerPrefs.GetInt("q"); //Will return 0 if no int value is found. Which is good for a new save/player.
        boss = PlayerPrefs.GetInt("current_boss"); //We only want to get values here, not set them or else we overwrite the player's progress.
        Debug.Log(boss);


        switch (boss)
        {
            case 0:
                //plaque.GetComponent<SpriteRenderer>().sprite = cs1_p;
                cs1 = true;
                break;
            case 1:
                //plaque.GetComponent<SpriteRenderer>().sprite = cs2_p;
                cs1 = false;
                cs2 = true;
                Destroy(halfway);
                break;
            case 2:
                cs2 = false;
                upstairs_left = true;
                break;
            case 3:
                upstairs_middle = true;
                break;
            case 4:
                upstairs_left = true;
                upstairs_middle = true;
                break;

            default:
                break;
        }


        
        //NEXT THING TO DO! Every gameobject that relies on the player's progress should read these variables on start!!!!
        //And then behave accordingly!!! (Camera boundaries, boss fights, TAlab, CSlab)
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
