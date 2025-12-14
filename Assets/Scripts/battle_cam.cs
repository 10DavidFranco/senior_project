using UnityEngine;

public class battle_cam : MonoBehaviour
{
    public GameObject p_screen;
    public GameObject f_screen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public AudioSource sfxSource;
    public AudioClip passClip;
    public AudioClip failClip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pass()
    {
        sfxSource.PlayOneShot(passClip);
        Instantiate(p_screen, transform);
    }

    public void Fail()
    {
        sfxSource.PlayOneShot(failClip);
        Instantiate(f_screen, transform);
    }

}
