using UnityEngine;
using UnityEngine.SceneManagement;

public class sf_leftstairs : MonoBehaviour
{
    private bool able_to_down = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hello" + col.name); //check if on player layer


        if (col.gameObject.layer == 10) // is it the player that is next to me?
        {
            able_to_down = true;
        }


    }

    void OnTriggerExit2D(Collider2D col) //did the player leave
    {
        //Debug.Log("Hello" + col.name);
        able_to_down = false;
    }

    void Update()
    {

        if (able_to_down) //okay they are next to me
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
        Debug.Log("Changing floors down left"); //cool, go upstairs
        PlayerPrefs.SetInt("stairs", 3);
        SceneManager.LoadScene("first_floor");
    }
}
