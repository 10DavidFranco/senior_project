using UnityEngine;
using UnityEngine.SceneManagement;

public class character_selector : MonoBehaviour
{ 

    public Transform player1_pos;
    public Transform player2_pos;

    private bool still_pressing_button;
    private int current_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {


            if (!still_pressing_button)
            {
                current_pos--;
                MovePos();
                still_pressing_button = true;
            }

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!still_pressing_button)
            {
                current_pos++;
                MovePos();
                still_pressing_button = true;
            }

        }
        else
        {
            still_pressing_button = false;
        }

        if (Input.GetButton("Submit"))
        {
            //set playerskin value so that map and combat can refer to and load.
            PlayerPrefs.SetInt("player_skin", current_pos);
            //load firstfloor
            SceneManager.LoadScene("first_floor");
        }

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("start_menu");
        }
    }


void MovePos()
{
    if (current_pos > 2) //Start menu will check if value has not been set (i.e. returns 0)
    {
        current_pos = 1;
    }
    else if (current_pos < 1)
    {
        current_pos = 2;
    }

    switch (current_pos)
    {
        case 1:
            this.transform.position = player1_pos.position;
            break;
        case 2:
            this.transform.position = player2_pos.position;
            break;
        default:
            break;
    }


    Debug.Log("You are now at position: " + current_pos);
}

}
