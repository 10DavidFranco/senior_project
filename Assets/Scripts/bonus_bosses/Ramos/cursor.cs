using UnityEngine;
using UnityEngine.SceneManagement;

public class cursor : MonoBehaviour
{
    public Transform boss1_pos;
    public Transform boss2_pos;
    public Transform boss3_pos;
    //public Transform exit_pos;

    public GameObject boss1_label;
    public GameObject boss2_label;
    public GameObject boss3_label;

    public int collectible_count;
    private bool still_pressing_button;
    private int current_pos;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectible_count = PlayerPrefs.GetInt("collectibles");
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
                if(collectible_count > 1)
                {
                    SceneManager.LoadScene("ramos");
                }
              
                break;
            case 1:
                if(collectible_count > 4)
                {
                    SceneManager.LoadScene("erik");
                }
              
                break;
            case 2:
                if(collectible_count > 6)
                {
                    SceneManager.LoadScene("s&w");
                }
               
                break;
            default:
                break;
        }
    }

    void MovePos()
    {
        boss1_label.SetActive(false);
        boss2_label.SetActive(false);
        boss3_label.SetActive(false);

        if (current_pos > 2)
        {
            current_pos = 0;
            boss1_label.SetActive(true);
        }
        else if (current_pos < 0)
        {
            boss3_label.SetActive(true);
            current_pos = 2;
        }

        switch (current_pos)
        {
            case 0:
                boss1_label.SetActive(true);
                this.transform.position = boss1_pos.position;
                break;
            case 1:
                boss2_label.SetActive(true);
                this.transform.position = boss2_pos.position;
                break;
            case 2:
                boss3_label.SetActive(true);
                this.transform.position = boss3_pos.position;
                break;
            default:
                break;
        }


        Debug.Log("You are now at position: " + current_pos);
    }
}
