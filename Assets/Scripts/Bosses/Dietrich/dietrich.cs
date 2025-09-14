using UnityEngine;
using System.Collections;

public class dietrich : MonoBehaviour
{
    public Animator anim;
    public f_spawn spawn;
    public bool call = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        DeclareFunc();
        yield return new WaitForSeconds(3.0f);
        AnimCall();
        yield return new WaitForSeconds(3.0f);
        AnimCall();
    }


    
    ////////////////////////////////////////////////////////////////////////////////////////////
    /////FUNCTION ATTACKS //////////////////////////////////////////////////////////////////////
    

    ///FUNCTION DECLARE
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
        float r = Random.Range(0.0f, 1.0f);
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
    ///FUNCTION CALL

    public void AnimCall() //USE ANIM CALL TO START CALL CHAIN start the animation**********Calls next two functions through animation 
    {
        anim.SetBool("call", true);
    }

    public void CallFunc() //have the animation call this function when speech bubble appears
    {
        call = true;
    }

    public void StopCall() //and then the animator will call this when the speech bubble is gone
    {
        anim.SetBool("call", false);
        call = false;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////
}
