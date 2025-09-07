using UnityEngine;

public class playerSpawnff : MonoBehaviour
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
            case 3:
                newplayer = Instantiate(playerprefab, leftspawn.transform);
                break;
            case 4:
                newplayer = Instantiate(playerprefab, middlespawn.transform);
                break;
            case 5:
                newplayer = Instantiate(playerprefab, rightspawn.transform);
                break;
            default:
                newplayer = Instantiate(playerprefab, centerspawn.transform);
                break;
        }

        cam.player = newplayer;
    }


}
