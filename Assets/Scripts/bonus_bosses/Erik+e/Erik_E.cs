using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Erik_E : MonoBehaviour
{
    public int health;
    public Animator anim;

    [Header("Arms")]
    public ArmAttack[] Phase1Arms;
    public ArmAttack[] Phase2Arms;


    [Header("Bees")]
    public GameObject beePrefab;
    public Transform[] spawnPoints;

    public battle_cam bc;
    private bool dieonce;

    void Start()
    {
        dieonce = false;
        StartCoroutine(BossPhases());
    }

    IEnumerator BossPhases()
    {
        // PHASE 1 (health > 60)
        while (health > 60)
        {
            SpawnBeesPhase1();
            RandomArmAttack(Phase1Arms);

            yield return new WaitForSeconds(2f);
        }

        // PHASE 2 (health > 30)
        while (health <60 && health > 30)
        {
            SpawnBeesPhase2();
            RandomArmAttack(Phase2Arms);
            yield return new WaitForSeconds(1.5f);
        }

        
    }

    void RandomArmAttack(ArmAttack[] arms)
    {
        int r = Random.Range(0, arms.Length);
        StartCoroutine(ArmAttackRoutine(arms[r]));
    }

    IEnumerator ArmAttackRoutine(ArmAttack arm)
    {
        arm.Attack();
        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(1.2f);

        arm.Retract();
    }











    void SpawnBeesPhase1()
    {
        // first spawn point only
        Instantiate(beePrefab, spawnPoints[0].position, Quaternion.identity);
    }

    void SpawnBeesPhase2()
    {
        // random spawn point
        int r = Random.Range(0, spawnPoints.Length);
        Instantiate(beePrefab, spawnPoints[r].position, Quaternion.identity);
    }

    // Existing hit detection & death logic
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            health--;
            checkDeath();
        }
    }

    void checkDeath()
    {
        if (health <= 0 && !dieonce)
        {
            dieonce = true;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        bc.Pass();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("first_floor");
    }
}
