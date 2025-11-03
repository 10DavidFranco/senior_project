using UnityEngine;
using UnityEngine.SceneManagement;

public class cs2door : MonoBehaviour
{
    private bool able_to_enter = false;
    public gameManager gm;
    public camera cam;
    public InteractionDetector id;
    


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name); //check if on player layer


        if (col.gameObject.layer == 10) // is the player next to me?
        {
            
            id = col.gameObject.GetComponent<InteractionDetector>();
            Debug.Log(id);
            if (gm.cs2)
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
            PlayerPrefs.SetInt("spawn", 5);
            cam.showPlaque();
            //id.SetPlaqueView();
            //changeScene();
        }

    }

   
}
