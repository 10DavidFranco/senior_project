using UnityEngine;

public class playerSpawnsf : MonoBehaviour
{

    public GameObject leftspawn;
    public GameObject middlespawn;
    public GameObject rightspawn;
    public GameObject centerspawn;
    public GameObject cs3spawn;
    public GameObject cs4spawn;

    public camera cam;
    public GameObject playerprefab;
    private GameObject newplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawnpoint = PlayerPrefs.GetInt("spawn");

        switch (spawnpoint)
        {
            case 7:
                newplayer = Instantiate(playerprefab, leftspawn.transform);
                break;
            case 8:
                newplayer = Instantiate(playerprefab, cs3spawn.transform);
                break;
            case 9:
                newplayer = Instantiate(playerprefab, middlespawn.transform);
                break;
            case 10:
                newplayer = Instantiate(playerprefab, cs4spawn.transform);
                break;
            case 11:
                newplayer = Instantiate(playerprefab, rightspawn.transform);
                break;
            default:
                newplayer = Instantiate(playerprefab, centerspawn.transform);
                break;
        }

        cam.player = newplayer;
    }

    
}
