using UnityEngine;

public class playerSpawnff : MonoBehaviour
{

    public GameObject leftspawn;
    public GameObject middlespawn;
    public GameObject rightspawn;
    public GameObject centerspawn;
    public GameObject cs1spawn;
    public GameObject cs2spawn;
    public GameObject labspawn;
    public GameObject taofficespawn;

    public camera cam;
    public GameObject playerprefab;
    private GameObject newplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawnpoint = PlayerPrefs.GetInt("spawn");

        switch (spawnpoint)
        {
            case 0:
                newplayer = Instantiate(playerprefab, leftspawn.transform);
                break;
            case 1:
                newplayer = Instantiate(playerprefab, taofficespawn.transform);
                break;
            case 2:
                newplayer = Instantiate(playerprefab, labspawn.transform);
                break;
            case 3:
                newplayer = Instantiate(playerprefab, cs1spawn.transform);
                break;
            case 4:
                newplayer = Instantiate(playerprefab, middlespawn.transform);
                break;
            case 5:
                newplayer = Instantiate(playerprefab, cs2spawn.transform);
                break;
            case 6:
                newplayer = Instantiate(playerprefab, rightspawn.transform);
                break;
            default:
                newplayer = Instantiate(playerprefab, centerspawn.transform);
                break;
        }

        cam.player = newplayer;
    }


}
