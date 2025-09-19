using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class GridSelection : MonoBehaviour
{
    //for grid
    public int columns = 4; // Number of columns in your grid
    public Image[] items; // Assign all your grid items in order
    public RectTransform selector; // Visual indicator (like a highlight box)

    private int currentIndex = 0;

    //for dialog
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[][] dialoguesPerBox; // Each element is an array of dialogue lines for that box
    public string[] dialogue;

    private int index;

    //public GameObject ContButton;
    public float wordspeed;
   

    void Start()
    {
        UpdateSelectorPosition();
        dialoguesPerBox = new string[][]
   {
        new string[] { "Question 1: What is 2 + 2? " },
        new string[] { "Question 2:"},
        new string[] { "Question 3:" },
        new string[] { "Question 4:" },
        new string[] { "Question 5:" },
        new string[] { "Question 6:" },
        new string[] { "Question 7:" },
        new string[] { "Question 8:" },
        new string[] { "Question 9:" },
        new string[] { "Question 10:" },
        new string[] { "Question 11:" },
        new string[] { "Question 12:"},
        new string[] { "Question 13:" },
        new string[] { "Question 14:" },
        new string[] { "Question 15:" },
        new string[] { "Question 16:" },

   };
    }

    void Update()
    {
        HandleInput();

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        //if (dialogueText.text == dialogue[index])
        //{

           // ContButton.SetActive(true);
       // }


    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((currentIndex + 1) % columns != 0 && currentIndex + 1 < items.Length)
                currentIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentIndex % columns != 0)
                currentIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentIndex - columns >= 0)
                currentIndex -= columns;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentIndex + columns < items.Length)
                currentIndex += columns;
        }

        UpdateSelectorPosition();
    }

    void UpdateSelectorPosition()
    {
        selector.position = items[currentIndex].transform.position;
    }



    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        dialogue = dialoguesPerBox[currentIndex];
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }

    public void Nextline()
    {
        //ContButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();

        }

    }

}
