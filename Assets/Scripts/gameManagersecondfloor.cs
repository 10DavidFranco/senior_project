using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagersecondfloor : MonoBehaviour
{

    
    public int boss;
    public GameObject halfway;
    

    public bool cs3;
    public bool cs4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        boss = PlayerPrefs.GetInt("current_boss"); //We only want to get values here, not set them or else we overwrite the player's progress.
        Debug.Log("This is your boss number: " + boss);


        switch (boss)
        {
            case 2:
                //plaque.GetComponent<SpriteRenderer>().sprite = cs1_p;
                cs3 = true;
                cs4 = false;
                break;
            case 3:
                //plaque.GetComponent<SpriteRenderer>().sprite = cs2_p;
                cs3 = false;
                cs4 = true;
                Destroy(halfway);
                break;
            case 4:
                cs3 = false;
                cs4 = false;
                Destroy(halfway);
                finalboss();
                break;
            

            default:
                break;
        }



        //NEXT THING TO DO! Every gameobject that relies on the player's progress should read these variables on start!!!! NOT ON START!!! ON INTERACTION...what was I thinking....
        //And then behave accordingly!!! (Camera boundaries, boss fights, TAlab, CSlab)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void finalboss()
    {
        SceneManager.LoadScene("final_boss");
        return;
    }
}
