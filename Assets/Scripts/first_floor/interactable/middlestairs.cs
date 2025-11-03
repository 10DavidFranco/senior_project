using UnityEngine;
using UnityEngine.SceneManagement;

public class middlestairs : MonoBehaviour
{
    
    private bool able_to_up = false;
    public gameManager gm;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name); //check if on player layer


        if (col.gameObject.layer == 10) // is it the player that is next to me?
        {
            if (gm.upstairs_middle)
            {
                able_to_up = true;
            }
            
        }


    }

    void OnTriggerExit2D(Collider2D col) //did the player leave
    {
        //Debug.Log("Hello" + col.name);
        able_to_up = false;
    }

    void Update()
    {

        if (able_to_up) //okay they are next to me
        {
            checkExecute();
        }
    }

    void checkExecute()
    {
       
            if (Input.GetKeyDown(KeyCode.Return))//do they want to go upstairs?
            {
                changeScene();
            }
        
    }

    void changeScene()
    {
        Debug.Log("Changing floors up middle"); //cool, go upstairs
        PlayerPrefs.SetInt("spawn",9);
        SceneManager.LoadScene("second_floor");
    }
}
