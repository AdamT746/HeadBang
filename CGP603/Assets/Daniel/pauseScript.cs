using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    Animator animator;
    public AudioSource audioSource;
    public GameObject PauseMenu;
    public Text countdown;
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
        PauseMenu.SetActive(true);
    }
    public void Resume()
    {
        animator.SetTrigger("Toggle");
        StartCoroutine(StartResume());
        PauseMenu.SetActive(false);
    }
    IEnumerator StartResume()
    {    
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            for (int i = 3; i > 0; i--)//cooldown Timer
            {
                countdown.text = i.ToString();
                yield return new WaitForSecondsRealtime(1f);
            }
            yield return 0;
        }

        countdown.text = null;
        Time.timeScale = 1;
        audioSource.Play();
    }
}
