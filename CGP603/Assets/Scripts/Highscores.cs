using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    
    public int highScore;
    public int highCombo;
    public Text ScoreText;
    public Text ComboText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score " + Shooting.m_score;
        ComboText.text = "Combo " + Shooting.HCombo;
    }
}
