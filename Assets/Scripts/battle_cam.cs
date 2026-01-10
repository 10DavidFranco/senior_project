using UnityEngine;

public class battle_cam : MonoBehaviour
{
    public GameObject p_screen;
    public GameObject f_screen;
    public bool pass;
    public bool fail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public AudioSource sfxSource;
    public AudioClip passClip;
    public AudioClip failClip;

    void Start()
    {
        pass = false;
        fail = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pass()
    {
        if (!fail)
        {
            pass = true;
            sfxSource.PlayOneShot(passClip);
            Instantiate(p_screen, transform);
        }
     
    }

    public void Fail()
    {

        if (!pass)
        {
            fail = true;
            sfxSource.PlayOneShot(failClip);
            Instantiate(f_screen, transform);
        }
    
    }

}
