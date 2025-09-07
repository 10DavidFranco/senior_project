using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject interactionIcon;

    void Start()
    {
        interactionIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
          interactionIcon.SetActive(true);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionIcon.SetActive(false);
    }
}
