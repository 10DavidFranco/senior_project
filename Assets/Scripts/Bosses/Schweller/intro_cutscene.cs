using UnityEngine;

public class intro_cutscene : MonoBehaviour
{
    public GameObject schweller;
    public GameObject stanley;
    public GameObject player;
    public player_move pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        schweller.SetActive(false);
        stanley.SetActive(false);   
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableAll()
    {
        schweller.SetActive(true);
        stanley.SetActive(true);
        player.SetActive(true);
        pm = player.GetComponent<player_move>();
        pm.DecideSkin();
    }
}
