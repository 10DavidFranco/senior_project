using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class wylie_control : MonoBehaviour
{
    //General
    public Animator anim;
    public Transform player;
    

    //Paper Attack
    public Transform paper_spawn;
    public GameObject paper_prefab;
    public GameObject paper_object;
    public float paper_speed;
    private float position_difference;
    //



    //Death
    private bool dieonce;
    public battle_cam bc;
    public int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(first_phase());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator first_phase()
    {
        yield return new WaitForSeconds(3.0f);
        ThrowPaper();
        yield return new WaitForSeconds(3.0f);
        ThrowPaper();
        yield return new WaitForSeconds(3.0f);
        ThrowPaper();
        yield return new WaitForSeconds(3.0f);
        SwingPencil();
    }
    //Pencil Attack
    void SwingPencil()
    {
        anim.SetBool("pencil_swing", true);
    }

    void StopSwinging()
    {
        anim.SetBool("pencil_swing", false);
    }
    //

    //Paper Attack
    void ThrowPaper()
    {
        anim.SetBool("paper_throw", true);
    }

    void SpawnPaper()
    {
        GetPositionDifference();
        if(position_difference <= 0)
        {
            position_difference = 5;//Don't throw paper backwards
           
        }
        else if(position_difference > 10)
        {
            //Default speed of 250 is sufficient to hit the back portion of the tape.
        }
        else
        {
            
            paper_speed = 100f; //Generally a good number to hit the center of the tape while not in extremes.
            
        }
        paper_object = Instantiate(paper_prefab, paper_spawn.position, paper_spawn.rotation);
        paper_object.GetComponent<Rigidbody2D>().AddForce(Vector3.left * paper_speed * (position_difference / 10f)); ;
        anim.SetBool("paper_throw", false);
    }

    void GetPositionDifference()
    {

        position_difference = this.transform.position.x - player.position.x;
        return;
    }
    //

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
        PlayerPrefs.SetInt("current_boss", 4);
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
