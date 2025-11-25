using UnityEngine;

public class hook_generator : MonoBehaviour
{

    public Transform low_spawn;
    public Transform mid_spawn;
    public GameObject hook_prefab;
    public hook new_hook;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastHook(int pos)
    {
        switch (pos)
        {
            case 0:
                new_hook = Instantiate(hook_prefab, low_spawn.position, low_spawn.rotation).GetComponent<hook>();
                new_hook.center_line = low_spawn.position.y;
                break;
            case 1:
                new_hook = Instantiate(hook_prefab, mid_spawn.position, mid_spawn.rotation).GetComponent<hook>();
                new_hook.center_line = mid_spawn.position.y;
                break;
            default:
                break;
        }
    }
}
