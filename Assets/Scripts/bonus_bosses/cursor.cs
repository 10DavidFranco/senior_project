using UnityEngine;
using UnityEngine.SceneManagement;

public class cursor : MonoBehaviour
{
    public Transform boss1_pos;
    public Transform boss2_pos;
    public Transform boss3_pos;
    //public Transform exit_pos;


    private bool still_pressing_button;
    private int current_pos;
    private Rigidbody2D rb;

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
            SceneChange();
        }

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("start_menu");
        }
    }

    void SceneChange()
    {
        switch (current_pos)
        {
            case 0:
                //SceneManager.LoadScene("first_floor");
                break;
            case 1:
                //SceneManager.LoadScene("bonus_bosses");
                break;
            case 2:
                //Debug.Log("OPTIONS MENU");
                break;
            default:
                break;
        }
    }

    void MovePos()
    {
        if (current_pos > 2)
        {
            current_pos = 0;
        }
        else if (current_pos < 0)
        {
            current_pos = 2;
        }

        switch (current_pos)
        {
            case 0:
                this.transform.position = boss1_pos.position;
                break;
            case 1:
                this.transform.position = boss2_pos.position;
                break;
            case 2:
                this.transform.position = boss3_pos.position;
                break;
            default:
                break;
        }


        Debug.Log("You are now at position: " + current_pos);
    }
}
