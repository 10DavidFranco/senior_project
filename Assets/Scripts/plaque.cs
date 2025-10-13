using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class plaque : MonoBehaviour
{
    public SpriteRenderer logo;
    public Sprite cs1;
    public Sprite cs2;
    public Sprite cs3;
    public Sprite cs4;

    public Sprite python;
    public Sprite javascript;
    public Sprite cplusplus;
    public Sprite assembly;


    private SpriteRenderer sp;
    private int boss;
    private bool exit;

    private int[] langs;

    private int index = 0;

    private bool exit_switch;

    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss = PlayerPrefs.GetInt("current_boss");
        sp = this.GetComponent<SpriteRenderer>();
        exit_switch = false;
        langs = new int[] { PlayerPrefs.GetInt("python"), PlayerPrefs.GetInt("javascript"), PlayerPrefs.GetInt("cplusplus"), PlayerPrefs.GetInt("assembly") };

        Debug.Log(langs);
        Debug.Log(langs.Length);
        Debug.Log(PlayerPrefs.GetInt("python") + PlayerPrefs.GetInt("javascript") + PlayerPrefs.GetInt("cplusplus") + PlayerPrefs.GetInt("assembly"));

        switch (boss)
        {
            case 0:
                sp.sprite = cs1;
                break;
            case 1:
                sp.sprite = cs2;
                break;
            case 2:
                sp.sprite = cs3;
                break;
            case 3:
                sp.sprite = cs4;
                break;
            default:
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !exit_switch)
        {
            exit_switch = !exit_switch;
            Debug.Log("pressing escape");
            Exit();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CycleLangs();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadBoss();
        }


    }

    void CycleLangs()
    {
        //Debug.Log("index started at: " + index);
        index++;
        //Debug.Log("index got incremented by 1");
        if(index >= langs.Length)
        {
            index = 0;
        }

        if (langs[index] == 0)
        {
            //not unlocked, cycle until unlocked found
            for (int i = index; i < langs.Length; i++)
            {
                if (langs[i] == 0)
                {
                    //Debug.Log("bump");
                    if(i == langs.Length - 1)
                    {
                        //Debug.Log("nope, none left, I'll reset you");
                        index = 0;
                    }
                }
                else
                {
                    index = i;
                    break;
                }
            }
        }
        else
        {
            //wow it is unlocked! Great job! Lets show it to you and update stuff...
        }


        //Debug.Log("Im on index: " + index);
        //Now show that image!
        switch (index)
        {
            case 0:
                logo.sprite = python; //python
                break;
            case 1:
                logo.sprite = javascript; //javascript
                break;
            case 2:
                logo.sprite = cplusplus; //cplusplus
                break;
            case 3:
                logo.sprite = assembly; //assembly
                break;
            default:
                break;
        }


        //cycle through an array of all unlocked langauges????
        //each languaeg will store a lang_index 0,1,2,3,4
        //eventually we will pass the selected languages true_lang_index as the current_lang PlayerPref to decide the weapon.

        //So we need to gather all installed languages, ad store them in a language array...
        //Once enter is pressed -> langArray[index].true_lang_inddex

        //get all unlocked langauges

        //keep track of index, and display lanfguages accordingly
    }


    void LoadBoss()
    {

        switch (index)//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Refer to this variable for weapon loading
        {
            case 0:
                PlayerPrefs.SetInt("weapon_lang", 0); //going into the fight with python
                Debug.Log("PYTHON");
                break;
            case 1:
                PlayerPrefs.SetInt("weapon_lang", 1); //javascript
                Debug.Log("JAVASCRIPT");
                break;
            case 2:
                PlayerPrefs.SetInt("weapon_lang", 2); //cplusplus
                Debug.Log("CPLUSPLUS");
                break;
            case 3:
                PlayerPrefs.SetInt("weapon_lang", 3); //assembly
                Debug.Log("ASSEMBLY");
                break;
            default:
                break;
        }//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Whatever index is currently on, set current_lang to that value...
        switch (boss)
        {
            case 0:
                SceneManager.LoadScene("cs1");
                break;
            case 1:
                SceneManager.LoadScene("cs2");
                break;
            case 2:
                SceneManager.LoadScene("cs3");
                break;
            case 3:
                SceneManager.LoadScene("cs4");
                break;
            default:
                break;

        }
    }

    void Exit()
    {
        Debug.Log("Exit is executing");
        Debug.Log(this.transform.parent.gameObject.name);
        Debug.Log(GameObject.Find("Player(Clone)").name);
        player = GameObject.Find("Player(Clone)");
        Debug.Log(player.GetComponent<player_movement>().plaque_view);
        player.GetComponent<player_movement>().plaque_view = false;
        Debug.Log(player.GetComponent<player_movement>().plaque_view);
        StartCoroutine(Destroy());
       
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
