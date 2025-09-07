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
<<<<<<< HEAD
        if(collision.gameObject.layer == 7)
        {
            interactionIcon.SetActive(true);
        }
          
=======
      
          interactionIcon.SetActive(true);
>>>>>>> 2f9c063539a78a1ff7f0632cbfe578cfd8635128
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionIcon.SetActive(false);
    }
}
