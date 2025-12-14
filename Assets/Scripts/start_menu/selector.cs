using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class selector : MonoBehaviour
{
    public Transform start_pos;
    public Transform bonus_pos;
    public Transform option_pos;
    public Transform exit_pos;


    private bool still_pressing_button;
    private int current_pos;
    private Rigidbody2D rb;


    [Header("Audio")]
    public AudioSource sfxSource;
    public AudioClip clip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        still_pressing_button = false;
        current_pos = 0;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Vertical"));



        if(Input.GetAxisRaw("Vertical") < 0)
        {


            if (!still_pressing_button)
            {
                current_pos++;
                MovePos(); 
                still_pressing_button = true;
            }
            
        }else if(Input.GetAxisRaw("Vertical") > 0)
        {
            if (!still_pressing_button)
            {
                current_pos--;
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
            SceneChange();
        }
    }

    void SceneChange()
    {
        switch (current_pos)
        {
            case 0:
                //Add if condition to check if player has already selected a player previously!!!!
                //0 should be no player has been selected, any value greater means a skin has already been set.
                if(PlayerPrefs.GetInt("player_skin") == 0)
                {
                    SceneManager.LoadScene("character_select");
                }
                else
                {
                    SceneManager.LoadScene("first_floor");
                }
                
                break;
            case 1:
                SceneManager.LoadScene("bonus_bosses");
                break;
            case 2:
                Debug.Log("OPTIONS MENU");
                break;
            case 3:
                Application.Quit();
                break;
            default:
                break;
        }
    }

    void MovePos()
    {
        if(current_pos > 3)
        {
            current_pos = 0;
        }else if(current_pos < 0)
        {
            current_pos = 3;
        }

        switch (current_pos)
        {
            case 0:
                this.transform.position = start_pos.position;
                break;
            case 1:
                this.transform.position = bonus_pos.position;
                break;
            case 2:
                this.transform.position = option_pos.position;
                break;
            case 3:
                this.transform.position = exit_pos.position;
                break;
            default:
                break;
        }

        sfxSource.PlayOneShot(clip);
        Debug.Log("You are now at position: " + current_pos);
    }
}
