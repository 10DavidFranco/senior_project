using UnityEngine;
using UnityEngine.SceneManagement;

public class cs2door : MonoBehaviour
{
    private bool able_to_enter = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name); //check if on player layer


        if (col.gameObject.layer == 10) // is the player next to me?
        {
            able_to_enter = true;
        }


    }

    void OnTriggerExit2D(Collider2D col) //did the player leave?
    {
        //Debug.Log("Hello" + col.name);
        able_to_enter = false;
    }

    void Update()
    {

        if (able_to_enter) //they are next to me
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
        Debug.Log("Going into cs2"); //Coolm, change scenes
    }
}
