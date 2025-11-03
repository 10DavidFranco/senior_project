using UnityEngine;
using System.Collections;

public class InteractionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject interactionIcon;
    public player_movement pm;
    


    //Responsible for showing the interact icon to the player
    void Start()
    {
        interactionIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7) //if the player is next to an interactable object, then sure, show the icon.
        {
            Debug.Log("Player is colliding with interactable!");
            interactionIcon.SetActive(true);
            
           
        }
          
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        interactionIcon.SetActive(false); //they left? stop showing it.
    }

    public void SetPlaqueViewOff()
    {
        Debug.Log("Setting plaque view!");
        StartCoroutine(TurnOffView());
        pm = this.transform.parent.gameObject.GetComponent<player_movement>();
        Debug.Log(pm.plaque_view);
    }

    IEnumerator TurnOffView()
    {
        yield return new WaitForSeconds(1.0f);
        pm.plaque_view = false;
    }


}
