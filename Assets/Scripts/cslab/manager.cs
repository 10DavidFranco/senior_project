using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class manager : MonoBehaviour
{

    public class lang
    {
        //Animator to play proper animations
        public Animator anim;
        //to show download text
        public bool unlocked;
        //to show installed text
        public bool installed;

        public lang(Animator a, bool b, bool i)
        {
            
            anim = a;
            unlocked = b;
            installed = i;
        }
    }
    /*
     Alright, let's try to illustrate how this will work.
     
    -The scene loads, python is automatically on the computer screen, installed.
    -Right arrow key intiates one pan-out and one pan-in
    (And perhaps a left arrow key will need to be implemented as well later on.)
    -The exit sign is not selected until the player keys upward. (keying upward again or back downward will focus back on the screen.
    -Once a language is unlockable, pressing enter on it will register the language as a language the player has unlocked.
     */


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //exit should not be selected
    //all other languages should not be activated
    //python should show on screen
    //installed should show on screen
    private int cursor;
    private int max_length;

    public GameObject locked;
    public GameObject installed;
    public GameObject download;

    private Animator assembly;
    private Animator cplusplus;
    private Animator javascript;
    private Animator python;
    //IF ADDING NEW LANGUAGE, ADD HERE

    public Animator exitsign;

    //private List<Animator> langs = new List<Animator>();
    private lang[] langs;
    

    void Start()
    {
        cursor = 0;
        //Setting the appropriate starting text
        locked.SetActive(false);
        download.SetActive(false);

        //Finding language object animators
        python = GameObject.Find("python").GetComponent<Animator>();
        javascript = GameObject.Find("javascript").GetComponent<Animator>();
        cplusplus = GameObject.Find("cplusplus").GetComponent<Animator>();
        assembly = GameObject.Find("assembly").GetComponent<Animator>();
        //IF ADDING NEW LANGUAGE ADD HERE

        //creating lang objects for easier manipulation
        lang py = new lang(python, true, true);
        lang js = new lang(javascript, false, false);
        lang cpp = new lang(cplusplus, false, false);
        lang asmb = new lang(assembly, false, false);
        //IF ADDING NEW LANGUAGE ADD HERE
        
        //initializing langs array
        langs = new lang[] { py, js, cpp, asmb };

        /*for(int i = 0; i < langs.Length; i++)
        {
            Debug.Log(langs[i].anim);
        }*/

        max_length = langs.Length;
    }

    // Update is called once per frame


    //if exit selected
        //if press enter, change scene
        //else if press (up or down key) not selected
        //else
    //else
    //if player moves right arrow, pan current language out, pan next language in, load appropriate text.
    void Update()
    {
        checkExit();
        //checkLangs();
    }

    void checkExit()
    {
        if (exitsign.GetBool("hover"))//Don't want the player to be able to navigate the languages while hovering over exit sign
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) //What to do if we are toggling through the exit sign
            {
                exitsign.SetBool("hover", false);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("first_floor");
            }
            else
            {

            }
        }
        else
        {
            checkLangs();

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) //What to do if we are toggling through the exit sign
            {
                exitsign.SetBool("hover", true);
            }
        }


    }

    void checkLangs()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            langs[cursor].anim.SetBool("in", false);

            if(cursor + 1 == max_length) //We've reached the end, time to cycle back.
            {
                cursor = 0;
            }
            else
            {
                cursor++;
            }
            
            langs[cursor].anim.SetBool("in", true);

            if (langs[cursor].installed)
            {
                installed.SetActive(true);
                download.SetActive(false);
                locked.SetActive(false);
            }
            else if (langs[cursor].unlocked)
            {
                installed.SetActive(false);
                download.SetActive(true);
                locked.SetActive(false);
            }
            else
            {
                installed.SetActive(false);
                download.SetActive(false);
                locked.SetActive(true);
            }
        }


        //Things left to do

        //Missing "Enter" logic to play proper animations and alter player prefs to reflect newly unlocked language.
        //Perhaps we use an int to set unlocked and installed values for all languages
        //ON start, check player prefs value, and update langs accordingly
        //ON Enter pressed, if not unlocked, do nothing
        //ON Enter pressed, if unlocked, playing animation (make loading bar animation, have it get stuck at 99%)
        //ON Enter pressed, if installed, do nothing.

        //Also, spawn player in proper place after exiting computer lab.
    }
}
