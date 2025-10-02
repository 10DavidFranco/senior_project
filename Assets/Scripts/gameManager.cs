using UnityEngine;

public class gameManager : MonoBehaviour
{

    public int currency;
    public int boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currency = PlayerPrefs.GetInt("Currency"); //Will return 0 if no int value is found. Which is good for a new save/player.
        boss = PlayerPrefs.GetInt("Boss"); //We only want to get values here, not set them or else we overwrite the player's progress.


        //NEXT THING TO DO! Every gameobject that relies on the player's progress should read these variables on start!!!!
        //And then behave accordingly!!! (Camera boundaries, boss fights, TAlab, CSlab)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
