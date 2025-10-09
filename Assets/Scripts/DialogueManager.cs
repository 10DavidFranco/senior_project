using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Image npcPortrait;
    public Button continueButton;
    public float wordSpeed = 0.03f;

    private string[] currentDialogue;
    private int index;
    private Coroutine typingCoroutine;

    public static DialogueManager Instance; // singleton for easy access

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        dialoguePanel.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }

    public void StartDialogue(string[] dialogueLines, Sprite portrait)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        currentDialogue = dialogueLines;
        npcPortrait.sprite = portrait;
        index = 0;
        dialogueText.text = "";
        dialoguePanel.SetActive(true);
        continueButton.gameObject.SetActive(false);

        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";
        foreach (char c in currentDialogue[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(wordSpeed);
        }

        continueButton.gameObject.SetActive(true);
    }

    public void NextLine()
    {
        continueButton.gameObject.SetActive(false);

        if (index < currentDialogue.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        currentDialogue = null;
    }
}
