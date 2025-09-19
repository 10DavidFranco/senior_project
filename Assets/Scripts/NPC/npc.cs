using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class npc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;


    public GameObject ContButton;
    public float wordspeed;
    public bool playerIsClose;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
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

         if (dialogueText.text == dialogue[index]) { 

        ContButton.SetActive(true);
         }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.CompareTag("Player"))
       // {
            playerIsClose = true;
        //}
    }
    private void OnTriggerExit2D(Collider2D other1)
    {
        //if (other1.CompareTag("Player"))
        //{
            playerIsClose = false;
            zeroText();
        //}
    }



    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }

    public void Nextline()
    {
        ContButton.SetActive(false);

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
   
