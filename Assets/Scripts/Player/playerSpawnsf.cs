using UnityEngine;

public class playerSpawnsf : MonoBehaviour
{

    public GameObject leftspawn;
    public GameObject middlespawn;
    public GameObject rightspawn;
    public GameObject centerspawn;

    public camera cam;
    public GameObject playerprefab;
    private GameObject newplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawnpoint = PlayerPrefs.GetInt("stairs");

        switch (spawnpoint)
        {
            case 0:
                newplayer = Instantiate(playerprefab, leftspawn.transform);
                break;
            case 1:
                newplayer = Instantiate(playerprefab, middlespawn.transform);
                break;
            case 2:
                newplayer = Instantiate(playerprefab, rightspawn.transform);
                break;
            default:
                newplayer = Instantiate(playerprefab, centerspawn.transform);
                break;
        }

        cam.player = newplayer;
    }

    
}
