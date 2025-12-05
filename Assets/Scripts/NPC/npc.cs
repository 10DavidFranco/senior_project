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

    private Animator anim;

    public bool exempt;

    //Collectible:

   
    public bool has_collectible;
    public GameObject collectible_prefab;
    //public Transform collectible_transform;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            DialogueManager.Instance.StartDialogue(dialogueLines, portrait, npcName, exempt);
            if (has_collectible)
            {

                spawnCollectible();
            }
           
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
        if (isTalking)
        {

            rb.linearVelocity = Vector2.zero;

            anim.SetFloat("MoveX", 0f);
            anim.SetFloat("MoveY", 0f);


            return;
        }
        Vector2 target = movingfoward ? endPos : startPos;
        Vector2 newpos = Vector2.MoveTowards(transform.position, target, movespeed * Time.fixedDeltaTime);


        Vector2 direction = (newpos - (Vector2)transform.position).normalized;

        rb.MovePosition(newpos);

        if ((Vector2)transform.position == target)
        {
            movingfoward = !movingfoward;
        }

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);

        //Debug.Log(direction);


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
        isTalking = false;
        //}
    }

    private void spawnCollectible()
    {

        if(PlayerPrefs.GetString(collectible_prefab.name) != "complete")
        {
            Debug.Log("Activating side quest");
            Debug.Log(collectible_prefab.name);
            Debug.Log("//////////////////////");
            collectible_prefab.SetActive(true);
            PlayerPrefs.SetString(collectible_prefab.name, "active");
        }
        else
        {
            Debug.Log("You already completed my quest so i'm not spawning again.");
        }
        
    }
}
