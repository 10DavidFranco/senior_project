using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private bool npc_exempt;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject namePanel;
    public TextMeshProUGUI nameText;
    public Image npcPortrait;
    public Button continueButton;
    public float wordSpeed = 0.03f;

    private string[] currentDialogue;
    private int index;
    private Coroutine typingCoroutine;

    public AudioSource dialogueSource;
    public AudioClip typingClip;


    public static DialogueManager Instance; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            //Destroy(gameObject);

        namePanel.SetActive(false);
        dialoguePanel.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }


    //Limit the dialogue lines to the current_boss number
    public void StartDialogue(string[] dialogueLines, Sprite portrait, string name, bool exempt)
    {
        npc_exempt = exempt;
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        currentDialogue = dialogueLines;
        npcPortrait.sprite = portrait;
        index = 0;
        dialogueText.text = "";
        dialoguePanel.SetActive(true);
        namePanel.SetActive(true);
        nameText.text = name;
        continueButton.gameObject.SetActive(false);

        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";

        if (typingClip != null)
            dialogueSource.PlayOneShot(typingClip);

        int soundCounter = 0;

        foreach (char c in currentDialogue[index])
        {
            dialogueText.text += c;

            if (c != ' ' && soundCounter % 2 == 0)
                dialogueSource.PlayOneShot(typingClip, 0.6f);

            soundCounter++;
            yield return new WaitForSeconds(wordSpeed);
        }


        continueButton.gameObject.SetActive(true);
    }


    public void NextLine()
    {
        continueButton.gameObject.SetActive(false);
        //

        if (npc_exempt) //Some characters will say all their dialogue all at once.
        {
            if (index < currentDialogue.Length - 1)
            {
                index++;
                Debug.Log(index);
                StartCoroutine(TypeLine());
            }
            else
            {
                EndDialogue();
            }
        }
        else
        {
            if (index < PlayerPrefs.GetInt("current_boss") + 1) //so that collectible quote can be included
            {
                index++;
                Debug.Log(index);
                StartCoroutine(TypeLine());
            }
            else
            {
                EndDialogue();
            }
        }

        

        
    }

    public void EndDialogue()
    {
        Debug.Log("ENDING DIALOGUE!");
        dialoguePanel.SetActive(false);
        namePanel.SetActive(false);
        dialogueText.text = "";
        nameText.text = "";
        currentDialogue = null;
    }
}
