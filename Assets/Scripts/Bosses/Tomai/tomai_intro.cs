using UnityEngine;

public class tomai_intro : MonoBehaviour
{
    public GameObject tomai;
    public GameObject player;
    public player_move pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tomai.SetActive(false);
       
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnableAll()
    {
        tomai.SetActive(true);
        
        player.SetActive(true);
        pm = player.GetComponent<player_move>();
        pm.DecideSkin();
    }
}
