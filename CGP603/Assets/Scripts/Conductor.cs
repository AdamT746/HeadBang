using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Conductor : MonoBehaviour
{
    //Static song info
    public float songBpm;
    private float secPerBeat;
    public float firstBeatOffset;
    private AudioSource musicSource;
    
    //Dynamic song info
    internal float songPosition;
    internal float songPosInBeats;
    internal float songTime;
    
    //Pause info
    public static bool paused = false;
    public static float pauseTimeStamp = -1f;
    public static float pausedTime = 0;
    public GameObject PauseCanvas;

    //Targets
    public List<GameObject> spawnPoints;
    public GameObject targetPrefab;
    public float gap = 4;
    private float timer;

    public float SongLength;
    public Text Timeleft;
    

    void Start()
    {
        //Music
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        songTime = musicSource.time;//dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();

        //Target management
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));
        timer = gap;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (pauseScript.paused == false)
        {
            //Song tracking
            songPosition = (float)(musicSource.time - songTime - firstBeatOffset); //songPosition = (float)(AudioSettings.dspTime - songTime - firstBeatOffset);//seconds since song start
            songPosInBeats = songPosition / secPerBeat;//beats since song start

            //Target spawning
            if (timer < songPosInBeats)
            {
                Instantiate(targetPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity);
                timer += gap;
                Debug.Log(songPosInBeats);
            }
        }
        if (songPosition >= SongLength)
        {
            SceneManager.LoadScene("LevelEnd");
        }
        Timeleft.text = songPosition + "/" + SongLength;
    }
}
