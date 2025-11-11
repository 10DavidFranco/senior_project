using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest")]
public class QuestSO : ScriptableObject
{
    public string questID;
    public string title;
    [TextArea] public string description;

    public int targetAmount;
    public int currentAmount;
    public string targetName;
    public bool isActive;
    public bool isCompleted;

    public void StartQuest()
    {
        isActive = true;
        currentAmount = 0;
    }

    public void AddProgress(int amount = 1)
    {
        if (!isActive || isCompleted) return;
        currentAmount += amount;
        if (currentAmount >= targetAmount)
            CompleteQuest();
    }

    public void CompleteQuest()
    {
        isCompleted = true;
        isActive = false;
        Debug.Log($"Quest '{title}' completed!");
    }
}
