using UnityEngine;
using UnityEngine.SceneManagement;

public class cs1door : MonoBehaviour
{
    private bool able_to_enter = false;
    public gameManager gm;
    public camera cam;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name); //check if on player layer


        if (col.gameObject.layer == 10) // is the player next to me?
        {
            if (gm.cs1)
            {
                able_to_enter = true;
            }
            
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
            //changeScene();
            PlayerPrefs.SetInt("spawn", 3);
            cam.showPlaque();
        }

    }

    
}
