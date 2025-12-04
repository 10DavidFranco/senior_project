using UnityEngine;

public class Sword : MonoBehaviour
{
    public float swingAngle = 210f;      // quarter circle
    public float swingTime = 0.75f;     // speed of swing
    public bool swingLeft = true;       // flip swing direction

        // assign your collider here

    float startAngle;
    float targetAngle;
    bool swinging = false;

    void Awake()
    {
        
        gameObject.SetActive(false);  // sword hidden until attack
    }

    public void StartSwing()
    {
        gameObject.SetActive(true);

          

        swinging = true;

        // set angles
        startAngle = transform.localEulerAngles.z;
        targetAngle = startAngle + (swingLeft ? swingAngle : -swingAngle);

        StartCoroutine(SwingRoutine());
    }

    System.Collections.IEnumerator SwingRoutine()
    {
        float t = 0f;

        while (t < swingTime)
        {
            t += Time.deltaTime;
            float progress = t / swingTime;

            float angle = Mathf.Lerp(startAngle, targetAngle, progress);
            transform.localEulerAngles = new Vector3(0, 0, angle);

            yield return null;
        }

           // stop hitting after swing
        swinging = false;

        // hide or return sword to starting rotation
        gameObject.SetActive(false);
    }

    
}
