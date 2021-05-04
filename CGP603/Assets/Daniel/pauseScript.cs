using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    Animator animator;
    public AudioSource audioSource;
    public GameObject PauseMenu;
    public RotateGun rotateScript;
    public Shooting shootingScript;
    public LineRenderer lazer;
    public Text countdown;
    public static bool paused;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Pause()
    {
        paused = true;
        animator.SetTrigger("Toggle");
        Time.timeScale = 0;
        audioSource.Pause();
        PauseMenu.SetActive(true);
        rotateScript.enabled = false;
        shootingScript.enabled = false;
        lazer.enabled = false;
    }
    public void ResumeLevel()
    {
        animator.SetTrigger("Toggle");
        PauseMenu.SetActive(false);
        StartCoroutine(ResumeCountdown(false));
    }
    public void ResumeTime()
    {
        animator.SetTrigger("Toggle");
        PauseMenu.SetActive(false);
        StartCoroutine(ResumeCountdown(true));
    }
    IEnumerator ResumeCountdown(bool sceneChange) //true if changing scene to menu to skip countdwon
    {
        float pauseTime = 0;
        if (sceneChange == false)
        {
            pauseTime = Time.realtimeSinceStartup + 3f;
        }
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
        rotateScript.enabled = true;
        shootingScript.enabled = true;
        audioSource.Play();
        paused = false;
    }
}
