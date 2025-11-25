using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;

public class ayati_control : MonoBehaviour
{
    public floor_generator floor_spawner;
    public int health;
    public battle_cam bc;
    private bool dieonce;
    public Animator anim;
    public AnimationClip ground_hit_clip;

    private float arm_decider;
    public GameObject ll_arm_prefab;
    public GameObject new_arm;
    public Transform left_arm_pos;
    public Transform mid_arm_pos;
    public Transform right_arm_pos;

    public pointer_spawner p_s;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(ground_hit_clip);
        settings.loopTime = false;
        AnimationUtility.SetAnimationClipSettings(ground_hit_clip, settings);
        StartCoroutine(FirstPhase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FirstPhase()
    {


            p_s.SpawnThreePointers(.5f);
            Debug.Log("Start phase");
            floor_spawner.FourCorners();
            yield return new WaitForSeconds(5.0f);
            floor_spawner.BlinkOut();
            floor_spawner.HorizontalLine();
            yield return new WaitForSeconds(1.0f);
            floor_spawner.DeleteCells();
            floor_spawner.HorizontalLine();
           
        

        StartCoroutine(SecondPhase());


    }

    IEnumerator SecondPhase()
    {

        floor_spawner.HorizontalLine();

        while(health > 5)
        {
            Debug.Log("Middle phase");
            StartArmAttack();
            yield return new WaitForSeconds(3.0f);
            EndArmAttack();
            yield return new WaitForSeconds(1.0f);
        }
        AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(ground_hit_clip);
        settings.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(ground_hit_clip, settings);
        while (health > 0)
        {
            Debug.Log("LAST PHASE");
            StartArmAttack();
            yield return new WaitForSeconds(1.0f);
            EndArmAttack();
            yield return new WaitForSeconds(1.0f);
        }
        
    }

    void StartArmAttack()
    {
        anim.SetBool("hit", true);
    }

    public void SpawnArm()
    {
        arm_decider = Random.Range(0f, 1f);

        if (arm_decider < 0.33f)
        {
            new_arm = Instantiate(ll_arm_prefab, left_arm_pos.position, left_arm_pos.rotation);
        }
        else if (arm_decider < 0.66f)
        {
            new_arm = Instantiate(ll_arm_prefab, mid_arm_pos.position, mid_arm_pos.rotation);
        }
        else
        {
            new_arm = Instantiate(ll_arm_prefab, right_arm_pos.position, right_arm_pos.rotation);
        }
    }

    void EndArmAttack()
    {
        anim.SetBool("hit", false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            health--;
            checkDeath();
            Debug.Log("HIT!");
        }

    }

    IEnumerator Die()
    {
        //Player wins!!!
        AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(ground_hit_clip);
        settings.loopTime = false;
        AnimationUtility.SetAnimationClipSettings(ground_hit_clip, settings);
        bc.Pass();
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("current_boss", 2);
        SceneManager.LoadScene("first_floor");
    }

    void checkDeath()
    {
        if (health <= 0 && !dieonce)
        {

            dieonce = !dieonce;
            StartCoroutine(Die());

        }
    }
}
