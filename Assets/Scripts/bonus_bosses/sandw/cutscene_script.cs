using UnityEngine;

public class cutscene_script : MonoBehaviour
{
    public GameObject schweller;
    public GameObject wylie;
    public GameObject player;
    public player_move pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        schweller.SetActive(false);
        player.SetActive(false);
        wylie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableAll()
    {
        schweller.SetActive(true);
        player.SetActive(true);
        wylie.SetActive(true);
        pm = player.GetComponent<player_move>();
        pm.DecideSkin();
    }
}
