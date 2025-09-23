using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class GridSelection : MonoBehaviour
{

    //for questions and answers system 
    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string[] answers = new string[4]; // number of answers
    }


    //for grid
    public int columns = 4; // Number of columns in your grid
    public Image[] items; // Assign all your grid items in order
    public RectTransform selector; // Visual indicator (like a highlight box)

    private int currentIndex = 0;

    //for dialog
    public GameObject whiteboard;
    public GameObject titles;
    public GameObject answers;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private QuestionData[] QuestionBoxes; // Each element is an array of dialogue lines for that box
    public Button[] AnswerButtons;

    private int index;

    //public GameObject ContButton;
    public float wordspeed;
   

    void Start()
    {
        
        UpdateSelectorPosition();
        QuestionBoxes = new QuestionData[]
   {
        new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
        new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "5", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
          new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
        new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "5", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
          new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
        new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "5", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
          new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
        new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "5", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" }
        },

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
                whiteboard.SetActive(true);
                selector.gameObject.SetActive(true);
                titles.SetActive(true);
            }
            else
            {
                answers.SetActive(true);
                selector.gameObject.SetActive(false);
                whiteboard.SetActive(false);
                titles.SetActive(false);
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            int indexCopy = i; // important for closures
            AnswerButtons[i].onClick.RemoveAllListeners();
            AnswerButtons[i].onClick.AddListener(() => {
                OnAnswerSelected(indexCopy);
                ReturnToGrid();
            });
       
        }

        //if (dialogueText.text == dialogue[index])
        //{

        // ContButton.SetActive(true);
        // }


    }

    void HandleInput()
    {
        if (!whiteboard.activeSelf) return;

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
        // for whiteboard/ question
        QuestionData qData = QuestionBoxes[currentIndex];
        foreach (char letter in qData.question.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }

        //for answers
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            TextMeshProUGUI btnText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = qData.answers[i];
        }

    }



    void OnAnswerSelected(int answerIndex)
    {
        Debug.Log("Player chose: " + QuestionBoxes[currentIndex].answers[answerIndex]);
        // Check correctness, give points, etc.
    }

    public void ReturnToGrid()
    {
        // Hide the question UI
        answers.SetActive(false);
        dialoguePanel.SetActive(false);

        // Show the grid UI
        whiteboard.SetActive(true);
        titles.SetActive(true);
        selector.gameObject.SetActive(true);

        // Reset dialogue text for next question
        dialogueText.text = "";
        index = 0;
    }


    /*public void Nextline()
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

    }*/

}
