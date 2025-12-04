using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ramos : MonoBehaviour
{
    public int health;
    public Animator anim;

    [Header("Arc Shot Attack")]
    public GameObject arcBulletPrefab;
    public float arcMinAngle = 100f;
    public float arcMaxAngle = 160f;
    public float arcShotInterval = 0.5f;


    public Sword[] swords;   // assign 3 swords in inspector
    public float minDelay = 1f;
    public float maxDelay = 3f;

  

    [Header("Finger Attack")]
    public Transform[] arcPoints;
    public GameObject fingerPrefab;

    private List<Finger> spawnedFingers = new List<Finger>();

    private Transform player;

    public battle_cam bc;
    private bool dieonce;

    void Start()
    {
        dieonce = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BossPhases());
        

    }

    IEnumerator BossPhases()
    {
        // PHASE 1 (health > 60)
        while (health > 60)
        {
           
                StartCoroutine(RandomSwordAttack());
            
            ShootArcBullet();
            StartCoroutine(FingerFireSequence());


            yield return new WaitForSeconds(2f);
        }

        // PHASE 2 (health > 30)
        while (health < 60 && health > 30)
        {
            //to shoot in bounce mode
            var b = ShootArcBullet();
            var bullet = b.GetComponent<ram0s_bullet>();
            bullet.bouncemode = true;
            b.GetComponent<Rigidbody2D>().gravityScale = 0f;

            yield return new WaitForSeconds(2f); 
        }


    }



    GameObject ShootArcBullet()
    {
        float angle = Random.Range(arcMinAngle, arcMaxAngle);
        Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        Vector3 spawnpos = transform.position + new Vector3(0f, 1.5f, 0f);

        GameObject b = Instantiate(arcBulletPrefab, spawnpos, Quaternion.identity);

        // Requires your bullet to have Rigidbody2D
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        rb.linearVelocity = dir * 10f;    // customize speed
        return b;
    }






    IEnumerator RandomSwordAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            // Pick random sword
            Sword pick = swords[Random.Range(0, swords.Length)];

            pick.StartSwing();   // swing it
        }
    }


    // finger attack 


    IEnumerator FingerFireSequence()
    {
        spawnedFingers.Clear();

        Debug.Log("FingerFireSequence started, arcPoints = " + arcPoints.Length);



        // sequential spawn
        for (int i = 0; i < arcPoints.Length; i++)
        {

            Debug.Log("Spawning finger at: " + arcPoints[i].position);

            GameObject f = Instantiate(fingerPrefab, arcPoints[i].position, Quaternion.identity);
            Finger fp = f.GetComponent<Finger>();

            Vector2 dir = (player.position - arcPoints[i].position).normalized;
            fp.SetDirection(dir);

            spawnedFingers.Add(fp);

            yield return new WaitForSeconds(0.15f);
        }

        // delay before firing
        yield return new WaitForSeconds(0.4f);

        // fire all at once
        foreach (var fp in spawnedFingers)
            fp.Fire();
    }











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
