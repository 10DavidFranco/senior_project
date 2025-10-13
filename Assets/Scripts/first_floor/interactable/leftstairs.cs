using UnityEngine;
using UnityEngine.SceneManagement;

public class leftstairs : MonoBehaviour
{
    
    private bool able_to_up = false;
    public gameManager gm;


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name); //check if on player layer


        if(col.gameObject.layer == 10) // is the player next to me?
        {

            if (gm.upstairs_left)
            {
                able_to_up = true;
            }
            
        }

        
    }

    void OnTriggerExit2D(Collider2D col) //did the player leave?
    {
        //Debug.Log("Hello" + col.name);
        able_to_up = false;
    }

    void Update()
    {

        if (able_to_up) //they are next to me
        {
            checkExecute();
        }
    }

    void checkExecute()
    {
        
            if (Input.GetKeyDown(KeyCode.Return))//Did they press enter
            {
                changeScene();
            }
        
    }

    void changeScene()
    {
        Debug.Log("Changing floors from left"); //Coolm, change scenes
        PlayerPrefs.SetInt("spawn",7);
        SceneManager.LoadScene("second_floor");
    }
}
