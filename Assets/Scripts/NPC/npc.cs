using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    [TextArea(3, 10)]
    public string[] dialogueLines;
    public Sprite portrait;

    private bool playerIsClose;

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.Instance.StartDialogue(dialogueLines, portrait, npcName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player"))
            playerIsClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.CompareTag("Player"))
        //{
            playerIsClose = false;
            DialogueManager.Instance.EndDialogue();
        //}
    }
}
