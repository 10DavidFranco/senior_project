using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class schweller_control : MonoBehaviour
{
    public Animator anim;
    public GameObject plate_prefab;
    public GameObject new_plate;
    public Transform plate_spawn;
    public float plate_speed;
    public float tree_speed;
    private float tree_check;

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject new_tree;

    public Transform treespawn1;
    public Transform treespawn2;
    public Transform treespawn3;

    public int health;
    public battle_cam bc;
    private bool dieonce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dieonce = false;
        StartCoroutine(firstphase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator firstphase()
    {
        yield return new WaitForSeconds(3.0f);
        ThrowPlate();
        yield return new WaitForSeconds(3.0f);
        ThrowPlate();
        yield return new WaitForSeconds(3.0f);
        SpawnTree();
    }

    //Tree Scroll
    void SpawnTree()
    {
        tree_check = Random.Range(0f, 1.0f);
       
        if(tree_check < 0.25)
        {
            new_tree = Instantiate(tree1, treespawn1.position, treespawn1.rotation);
        }else if(tree_check < 0.5)
        {
            new_tree = Instantiate(tree3, treespawn1.position, treespawn1.rotation);
        }else if(tree_check < 0.75)
        {
            new_tree = Instantiate(tree2, treespawn2.position, treespawn2.rotation);
        }
        else
        {
            new_tree = Instantiate(tree4, treespawn3.position, treespawn3.rotation);
        }

        new_tree.GetComponent<Rigidbody2D>().AddForce(Vector3.left * tree_speed);
    }


    //Plate Attack
    void ThrowPlate()
    {
        anim.SetBool("throwing", true);
    }

    void SpawnPlate()
    {
        new_plate = Instantiate(plate_prefab, plate_spawn);
        new_plate.GetComponent<Rigidbody2D>().AddForce(Vector3.left * plate_speed);
    }

    void StopThrow()
    {
        anim.SetBool("throwing", false);
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
        bc.Pass();
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("current_boss", 3);
        SceneManager.LoadScene("second_floor");
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
