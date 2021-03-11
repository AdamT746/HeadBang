using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    Animator animator;
    public AudioSource audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Pause()
    {
        animator.SetTrigger("Toggle");
        Time.timeScale = 0;
        audioSource.Pause();
    }
    public void Resume()
    {
        animator.SetTrigger("Toggle");
        StartCoroutine(StartResume());
    }
    IEnumerator StartResume()
    {    
        float pauseTime = Time.realtimeSinceStartup + 1f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;     
        Time.timeScale = 1;
        audioSource.Play();
    }
}
