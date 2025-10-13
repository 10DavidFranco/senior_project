using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class dietrich : MonoBehaviour
{
    public int health = 24;
    public littlefunction lf;
    public Animator anim;
    public f_spawn spawn;
    public bool call = false;
    public int functionsinplay = 0;

    public GameObject tennis_ball;
    public GameObject tb_spawn;

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


    /////Phases
    ///

    IEnumerator firstphase()
    {

        while(health > 25)
        {
            DeclareFunc();
            yield return new WaitForSeconds(3.0f);
            
            /*AnimCall();
            yield return new WaitForSeconds(3.0f);
            
            LittleFunc(true);
            yield return new WaitForSeconds(2.0f);
            LittleFunc(false);
            yield return new WaitForSeconds(2.0f);*/
        }


        StartCoroutine(secondphase());
        
    }

    IEnumerator secondphase() {


        anim.SetBool("second", true);
        yield return new WaitForSeconds(2.0f);
        Swing1(); //2balls
        yield return new WaitForSeconds(2.5f);
        Swing2(); //1ball
        yield return new WaitForSeconds(2.0f);
        Swing1(); //2balls

    }



    ///////////////TENNIS PHASE///////////////////////////////////////////////////////////////
    private void Swing1()
    {
        anim.SetBool("swing1", true);
    }

    private void Swing2()
    {
        anim.SetBool("swing2", true);
    }

    public void TurnOffSwing1()
    {
        anim.SetBool("swing1", false);
        
    }

    public void TurnOffSwing2()
    {
        anim.SetBool("swing2", false);
    }

    public void SpawnBall()
    {
        Instantiate(tennis_ball, new Vector3(13.84f, 4.45f, -3f), Quaternion.identity);
    }


    //////////////////////////////////////////////////////////////////////////////////////////



    //LITTLE FUNCTION//////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
   
    private void LittleFunc(bool left)
    {
        if (left)
        {
            //play true
            anim.SetBool("left", true);
        }
        else
        {
            //play false
            anim.SetBool("right", true);
        }
    }
    
    private void LittleFuncLeft() //call these during true animation
    {
        
        lf.positionLeft();
        anim.SetBool("left", false);
        
    }

    private void LittleFuncRight() //call these during false animation
    {
        lf.positionRight();
        anim.SetBool("right", false);
    }

    


    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////












    
    ////////////////////////////////////////////////////////////////////////////////////////////
    /////FUNCTION ATTACKS //////////////////////////////////////////////////////////////////////
    ///

    
    

    ///FUNCTION DECLARE (ATTACK)
    private void DeclareFunc()
    {
        anim.SetBool("dec", true);
        
  
    }

    public void StopDeclare() //Animator will call on this to stop looping animation
    {
        anim.SetBool("dec", false);
    }

    public void spawnFunc() //Animator will call this to spawn function at correct time.
    {
        float r = Random.Range(0f, 0.9f); //Rest to 0.0 to 1.0
        Debug.Log("r is " + r);

        if(r < 0.3f)
        {
            spawnA();
        }else if(r < 0.6f)
        {
            spawnB();
        }else if(r < 0.9f)
        {
            spawnC();
        }
        else
        {

        }

        functionsinplay++;
    }

    private void spawnA()
    {
        spawn.A();
    }

    private void spawnB()
    {
        spawn.B();
    }

    private void spawnC()
    {
        spawn.C();
    }

    
    /// ///////////////////////////////////////////////////////////////////////////////////////
    ///FUNCTION CALL (ATTACK)

    public void AnimCall() //USE ANIM CALL TO START CALL CHAIN start the animation**********Calls next two functions through animation 
    {
        anim.SetBool("call", true);
    }

    public void CallFunc() //have the animation call this function when speech bubble appears
    {
        call = true; //create several call variables for each function
    }

    public void StopCall() //and then the animator will call this when the speech bubble is gone
    {
        anim.SetBool("call", false);
        call = false;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////
    ///CHECKING FOR PLAYER BULLETS


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 13)
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
        PlayerPrefs.SetInt("current_boss", 1);
        SceneManager.LoadScene("first_floor");
    }

    void checkDeath()
    {
        if(health <= 0 && !dieonce)
        {

            dieonce = !dieonce;
            StartCoroutine(Die());
            
        }
    }
}
