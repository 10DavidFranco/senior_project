using UnityEngine;

public class collectible : MonoBehaviour
{
    //public Collectible_Overlay co;
    public GameObject c_overlay;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(this.gameObject.name);
        if(PlayerPrefs.GetString(this.gameObject.name) == "")
        {
            this.gameObject.SetActive(false); //if not started dont spawn in
        }
        else if(PlayerPrefs.GetString(this.gameObject.name) == "active")
        {
            this.gameObject.SetActive(true); //if started, spawn in the collectible
        }
        else
        {
            //collectible has been collected and this no longer exists
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("You collected me!");
            PlayerPrefs.SetInt("collectibles", PlayerPrefs.GetInt("collectibles") + 1);
            PlayerPrefs.SetString(this.gameObject.name, "complete");
            //co.PlayCollectible();
            c_overlay.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
