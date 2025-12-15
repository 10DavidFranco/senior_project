using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        public int correct;
        public bool answered = false;
        public int subject;
        public int subject_index;
    }


    //for grid
    public int columns = 4; // Number of columns in your grid
    public GameObject[] items; // Assign all your grid items in order
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

    //checking subject
    public int subject;
    public Image img;
    public GameObject text;

    private int cs1;
    private int cs2;
    private int cs3;
    private int cs4;

    private int current_subject_index;

    [Header("Audio")]
    public AudioSource sfxSource;
    public AudioClip moveClip;


    void Start()
    {
        subject = PlayerPrefs.GetInt("current_boss");
        cs1 = PlayerPrefs.GetInt("cs1_q");
        cs2 = PlayerPrefs.GetInt("cs2_q");
        cs3 = PlayerPrefs.GetInt("cs3_q");
        cs4 = PlayerPrefs.GetInt("cs4_q");

        switch (subject)//Find the subject the player is currently on and find the question they are currently on.
        {
            case 0:
                current_subject_index = cs1;
                break;
            case 1:
                current_subject_index = cs2;
                break;
            case 2:
                current_subject_index = cs3;
                break;
            case 3:
                current_subject_index = cs4;
                break;
            default:
                break;
        }
        UpdateSelectorPosition();
        QuestionBoxes = new QuestionData[]
   {
        new QuestionData {
            question = "Question 1: Which is an example of an int data type?",
            answers = new string[] { "car", "2.22", "1", "false" },
            correct = 2, //index of correct answer
            subject = 0, //cs1
            subject_index = 0
        },
        new QuestionData {
            question = "Question 1: A pointer is used to store an address in memory.",
            answers = new string[] { "True", "False", "", "" },
            correct = 0,
            subject = 1, //cs2
            subject_index = 0
        },
         new QuestionData {
            question = "Question 1: A runtime of O(n*n) is faster than O(log n)?",
            answers = new string[] { "True", "False", "", "" },
            correct = 0,
            subject = 2, //dsa
            subject_index = 0
        },
         new QuestionData {
            question = "Question 1: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" },
            correct = 1,
            subject = 3, //automata
            subject_index = 0
        },
          new QuestionData {
            question = "Question 2: Which of the following is NOT a control structure?",
            answers = new string[] { "Array", "For loop", "If-else", "While loop"},
            correct = 0,
            subject = 0,
            subject_index = 1
        },
        new QuestionData {
            question = "Question 2: What is the base case in a recursive function?",
            answers = new string[] { "Where the function loops forever", "Where the function no longer relies on arguments", "Where the function calls itself", "Where the function stops calling itself" },
            correct = 3,
            subject = 1,
            subject_index = 1

        },
         new QuestionData {
            question = "Question 2: What is the runtime of Breadth-First-Search in terms of a graphs vertices and edges?",
            answers = new string[] { "O(V+E)", "O(V*V)", "O(V log(V))", "O((V+E)log(V))" },
            correct = 0,
            subject = 2,
            subject_index = 1

        },
         new QuestionData {
            question = "Question 2: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" },
            correct = 0,
            subject = 3,
            subject_index = 1

        },
          new QuestionData {
            question = "Question 3: Void functions are used to return values.",
            answers = new string[] { "True", "False", "", "" },
            correct = 1,
            subject = 0,
            subject_index = 2

        },
        new QuestionData {
            question = "Question 3: What is a doubly linked list?",
            answers = new string[] { "A linked list that refers to a separate array for storage", "A linked list whose nodes point to the previous and next node", "Two linked lists. Their data keeps track of the other.", "None of the above." },
            correct = 1,
            subject = 1,
            subject_index = 2

        },
         new QuestionData {
            question = "Question 3: What is dynamic programming? (If you don't know this, it is extremely worth looking into.)",
            answers = new string[] { "Storing and referring to answers we've already found", "Implementing pointers and heap memory into your solution", "Increasing efficiency using your computer's cache", "Overclocking your computer to run programs more effectively"},
            correct = 0,
            subject= 2,
            subject_index = 2

        },
         new QuestionData {
            question = "Question 3: What is 2 + 2?",
            answers = new string[] { "3", "4", "1", "22" },
            correct = 0,
            subject = 3,
            subject_index = 2

        },
          new QuestionData {
            question = "Question 4: What portion of a class is used to initialize newly created objects?",
            answers = new string[] { "Initializer", "Instantiater", "Creator", "Constructor" },
            correct = 3,
            subject = 0,
            subject_index = 3

        },
        new QuestionData {
            question = "Question 4: What is a leaf in terms of a tree data structure.",
            answers = new string[] { "A node with no children", "A node with no parent", "A node with no data", "A node whose child connects back to the root node" },
            correct = 0,
            subject = 1,
            subject_index = 3

        },
         new QuestionData {
            question = "Question 4: Bubble sort?",
            answers = new string[] { "YESSS!", "Eww Eww Ewwww!", "It's fine.", "What? Bubbles? Isn't this CS?" },
            correct = 1,
            subject = 2,
            subject_index = 3

        },
         new QuestionData {
            question = "Question 4: P = NP?",
            answers = new string[] { "True", "False", "", "" },
            correct = 0,
            subject = 3,
            subject_index = 3

        },

   };




        ReturnToGrid();
    }

    void Update()
    {
        HandleInput();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("first_floor");
        }

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
                //IF the question matches the players current subject AND they have not answered the question yet...then interact with the question
                if (QuestionBoxes[currentIndex].subject == subject && !QuestionBoxes[currentIndex].answered)
                {

                    //Now...before the user can interact we need to make sure they aren't given access to a question they've already answered.
                    //We need to give each question their own subject index,
                    //Only the question that matches the index can be selected and answered.

                    if (QuestionBoxes[currentIndex].subject_index == current_subject_index)
                    {
                        answers.SetActive(true);
                        selector.gameObject.SetActive(false);
                        whiteboard.SetActive(false);
                        titles.SetActive(false);
                        dialoguePanel.SetActive(true);
                        StartCoroutine(Typing());
                    }
                    
                }
                
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

        int previousIndex = currentIndex;

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

        if (currentIndex != previousIndex)
        {
            sfxSource.PlayOneShot(moveClip);
            UpdateSelectorPosition();
        }
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
            btnText.text = qData.answers[i]; //this query is going out of bounds for t/f questions
            
            
        }

    }



    void OnAnswerSelected(int answerIndex)
    {
        //Debug.Log("Player chose: " + QuestionBoxes[currentIndex].answers[answerIndex]);
        //Debug.Log("Player chose: " + answerIndex);
        //Debug.Log("Correct answer: " + QuestionBoxes[currentIndex].correct);


        if(answerIndex == QuestionBoxes[currentIndex].correct)
        {
            Debug.Log("CORRECT");
            PlayerPrefs.SetInt("q", PlayerPrefs.GetInt("q") + 1);
            QuestionBoxes[currentIndex].answered = true;

            //NOw we also need to handle the input for our local playerprefs in this scene
            //we need to increment the individual subjects so that questions cannot be re-answered upon exit and entrance back into the scene.
            switch (subject)
            {
                //cs1
                case 0:
                    PlayerPrefs.SetInt("cs1_q", ++cs1);

                    current_subject_index = cs1;
                    break;
                //cs2
                case 1:
                    PlayerPrefs.SetInt("cs2_q", ++cs2);
                    current_subject_index = cs2;
                    break;
                //cs3
                case 2:
                    PlayerPrefs.SetInt("cs3_q", ++cs3);
                    current_subject_index = cs3;
                    break;
                //cs4
                case 3:
                    PlayerPrefs.SetInt("cs4_q", ++cs4);
                    current_subject_index = cs4;
                    break;
            }

            //Now that we have incremented...we need to act on this information when giving the user the chance to pick a question.
        }
        else
        {
            Debug.Log("WRONG!!!");
        }
        // Check correctness, give points, etc.
    }

    public void ReturnToGrid()
    {
        // Hide the question UI
        answers.SetActive(false);
        dialoguePanel.SetActive(false);

        // Show the grid UI
        whiteboard.SetActive(true);

        for(int i = 0; i < QuestionBoxes.Length; i++)
        {
            if (subject != QuestionBoxes[i].subject) //The player is currently not on this subject, so how should we display it?
            {
                text = items[i].transform.GetChild(0).gameObject;
                text.SetActive(false);
                img = items[i].GetComponent<Image>();
                img.color = Color.black;
            }
            else if (QuestionBoxes[i].subject_index < current_subject_index)
            {

                //Make the text green
                text = items[i].transform.GetChild(0).gameObject;
                text.GetComponent<TMP_Text>().color = Color.green;
            }//Also make a clause for the player is currently not on this question, so how should it be displayed. (maybe a less than greater then scenario, to display correctly answered q's
            else
            {

            }
        }

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
