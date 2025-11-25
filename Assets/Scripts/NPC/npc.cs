using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    [TextArea(3, 10)] public string[] dialogueLines;
    public Sprite portrait;


    [Header("Optional Quest")]
    public QuestSO questToGive;
    public QuestSO questToUpdate;


    private bool playerIsClose;

    [Header("Npc Movement")]
    public float movespeed = 2f;
    public float moveamount;
    public bool moveVert;  // True means up/down false means left/right


    private Vector2 startPos;
    private Vector2 endPos;
    private bool isTalking = false;
    private Rigidbody2D rb;
    private bool movingfoward = true;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        if (moveVert)
        {
            endPos = startPos + new Vector2(0, moveamount);
        }
        else
        {
            endPos = startPos + new Vector2(moveamount, 0);
        }

    }


    void Update()
    {
        Talking();
        Movement();
    }


    void Talking()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {

            isTalking = true;
            DialogueManager.Instance.StartDialogue(dialogueLines, portrait, npcName);
            // to give
            if (questToGive != null && !questToGive.isActive && !questToGive.isCompleted)
            {
                gameManager.Instance.AddQuest(questToGive);
            }

            //to update
            if (questToUpdate != null && questToUpdate.isActive && !questToUpdate.isCompleted)
            {
                questToUpdate.AddProgress();
            }

        }
    }

    void Movement()
    {
        if (isTalking) {

            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 target = movingfoward ? endPos : startPos;
        Vector2 newpos = Vector2.MoveTowards(transform.position, target, movespeed * Time.fixedDeltaTime);

        rb.MovePosition(newpos);

        if ((Vector2)transform.position == target) {
            movingfoward = !movingfoward;
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
