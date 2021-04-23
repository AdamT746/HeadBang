using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    public Text HScoreText;
    public Text ScoreText;
    public Text ComboText;

    // Start is called before the first frame update
    void Start()
    {
        HScoreText.text = "HighScore " + Shooting.HScore;
        ScoreText.text = "Score " + Shooting.m_score;
        ComboText.text = "Combo " + Shooting.m_combo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
