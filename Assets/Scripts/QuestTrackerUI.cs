using UnityEngine;
using TMPro;
using System.Text;

public class QuestTrackerUI : MonoBehaviour
{
    public TextMeshProUGUI questListText;


    //private void Start()
    //{
        
    //}
    void Update()
    {
        if (gameManager.Instance == null) return;

        StringBuilder sb = new StringBuilder();
        foreach (QuestSO quest in gameManager.Instance.activeQuests)
        {
            sb.AppendLine($"{quest.title}: {quest.currentAmount}/{quest.targetAmount}");
        }
        questListText.text = sb.ToString();
    }
}
