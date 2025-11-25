using UnityEngine;

public class floor_generator : MonoBehaviour
{
    

    public GameObject tl;
    public GameObject tm;
    public GameObject tr;
    public GameObject ml;
    public GameObject mm;
    public GameObject mr;
    public GameObject bl;
    public GameObject bm;
    public GameObject br;

    

    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FourCorners()
    {
        tl.SetActive(true);
        tr.SetActive(true);
        bl.SetActive(true);
        br.SetActive(true);
    }

    public void X()
    {
        tl.SetActive(true);
        tr.SetActive(true);
        bl.SetActive(true);
        br.SetActive(true);
        mm.SetActive(true);
    }

    public void HorizontalLine()
    {
        ml.SetActive(true);
        mm.SetActive(true);
        mr.SetActive(true);
    }

    public void DeleteCells()
    {
        tl.SetActive(false);
        tm.SetActive(false);
        tr.SetActive(false);
        ml.SetActive(false);
        mm.SetActive(false);
        mr.SetActive(false);
        bl.SetActive(false);
        bm.SetActive(false);
        br.SetActive(false);
    }

    public void BlinkOut()
    {
        tl.GetComponent<Animator>().SetBool("blink_out", true);
        tm.GetComponent<Animator>().SetBool("blink_out", true);
        tr.GetComponent<Animator>().SetBool("blink_out", true);
        ml.GetComponent<Animator>().SetBool("blink_out", true);
        mm.GetComponent<Animator>().SetBool("blink_out", true);
        mr.GetComponent<Animator>().SetBool("blink_out", true);
        bl.GetComponent<Animator>().SetBool("blink_out", true);
        bm.GetComponent<Animator>().SetBool("blink_out", true);
        br.GetComponent<Animator>().SetBool("blink_out", true);
    }

    public void TurnOffBlink() {
        tl.GetComponent<Animator>().SetBool("blink_out", false);
        tm.GetComponent<Animator>().SetBool("blink_out", false);
        tr.GetComponent<Animator>().SetBool("blink_out", false);
        ml.GetComponent<Animator>().SetBool("blink_out", false);
        mm.GetComponent<Animator>().SetBool("blink_out", false);
        mr.GetComponent<Animator>().SetBool("blink_out", false);
        bl.GetComponent<Animator>().SetBool("blink_out", false);
        bm.GetComponent<Animator>().SetBool("blink_out", false);
        br.GetComponent<Animator>().SetBool("blink_out", false);
    }
}
