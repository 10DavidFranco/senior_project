using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class gameManager : MonoBehaviour
{

    public static gameManager Instance; 

    public int questions;
    public int boss;
    public GameObject halfway;
    public bool upstairs_left;
    public bool upstairs_middle;

    public bool cs1;
    public bool cs2;

    //public GameObject plaque;
    //public Image cs1_p;
    //public Image cs2_p;

    [Header("Quest System")] public bool upstairs_right;
    public List<QuestSO> allQuests = new();
    public List<QuestSO> activeQuests = new();
    public List<QuestSO> completedQuests = new();




    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps it between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questions = PlayerPrefs.GetInt("q"); //Will return 0 if no int value is found. Which is good for a new save/player.
        boss = PlayerPrefs.GetInt("current_boss"); //We only want to get values here, not set them or else we overwrite the player's progress.
        Debug.Log("This is your boss number: " + boss);


        //Quest talk2me = new Quest
        //{
        //    questID = "Example",
        //    title = "talking to second guy",
        //    description = "talk to second npc please",
        //    targetName = "dummy2",
        //    targetAmount = 0
        //};

        //allQuests.Add(talk2me);

        switch (boss)
        {
            case 0:
                //plaque.GetComponent<SpriteRenderer>().sprite = cs1_p;
                cs1 = true;
                break;
            case 1:
                //plaque.GetComponent<SpriteRenderer>().sprite = cs2_p;
                cs1 = false;
                cs2 = true;
                Destroy(halfway);
                break;
            case 2:
                cs1 = false;
                cs2 = false;
                upstairs_left = true;
                upstairs_middle = false;
                Destroy(halfway);
                break;
            case 3:
                cs1 = false;
                cs2 = false;
                upstairs_left = true;
                upstairs_middle = true;
                Destroy(halfway);
                break;
            case 4:
                cs1 = false;
                cs2 = false;
                upstairs_left = true;
                upstairs_middle = true;
                Destroy(halfway);
                break;

            default:
                break;

             

        }


        
        //NEXT THING TO DO! Every gameobject that relies on the player's progress should read these variables on start!!!! NOT ON START!!! ON INTERACTION...what was I thinking....
        //And then behave accordingly!!! (Camera boundaries, boss fights, TAlab, CSlab)
    }

    public void AddQuest(QuestSO newQuest)
    {
        if (!activeQuests.Contains(newQuest) && !newQuest.isCompleted)
        {
            newQuest.StartQuest();
            activeQuests.Add(newQuest);
            Debug.Log($"Started Quest: {newQuest.title}");

        }
    }

    public void UpdateQuestProgress(string targetName, int amount = 1)
    {
        foreach (QuestSO quest in activeQuests)
        {
            if (quest.targetName == targetName && quest.isActive)
            {
                quest.AddProgress(amount);
                if (quest.isCompleted)
                {
                    completedQuests.Add(quest);
                }
            }
        }

        // Remove completed quests from active
        activeQuests.RemoveAll(q => q.isCompleted);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
