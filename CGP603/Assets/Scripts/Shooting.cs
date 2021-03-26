using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private LineRenderer m_line;
    public float m_destroyTime;
    public Text m_comboText, m_scoreText, m_scoreMultiplier;
    static public int m_score;
    public int m_combo;

    static public int HScore, HCombo;

    public bool using_anim;
    

    [Header("Needed Variables")]
    public Transform m_barrel;
    public Material m_gunMat;

    // Start is called before the first frame update
    void Start()
    {
        m_line = GetComponent<LineRenderer>();

        m_score = 0;
        m_combo = 0;

        HScore = PlayerPrefs.GetInt("Player HighScore");
        HCombo = PlayerPrefs.GetInt("Player HighCombo");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name != "Pause Collider")
                {
                    //Add score and combo, destroy target  --//Assuming yellow is perfect and green is great//--
                    if (hit.collider.gameObject.tag == "Target")
                    {
                        Color targetMaterial = hit.collider.GetComponent<Renderer>().material.color;

                        ScoreAndCombo(targetMaterial);

                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        m_combo = 0;
                        m_comboText.text = "" + m_combo;
                    }

                    StartCoroutine(DestroyLine());
                    SetupLine(hit);
                    if(using_anim)
                    GetComponent<Animator>().SetTrigger("Shoot");
                }
            }
        }
        HighScoreAndHighCombo();
    }

    void SetupLine(RaycastHit hito)
    {
        m_line.sortingLayerName = "OnTop";
        m_line.sortingOrder = 5;
        m_line.positionCount=2;
        m_line.SetPosition(0, m_barrel.position);
        m_line.SetPosition(1, hito.point);
        m_line.startWidth=0.02f;
        m_line.endWidth = 0.035f;
        m_line.useWorldSpace = true;
        m_line.material = m_gunMat;
    }

    IEnumerator DestroyLine()
    {
        m_line.enabled = !m_line.enabled;

        yield return new WaitForSeconds(m_destroyTime);

        m_line.enabled = !m_line.enabled;
    }

    private void ScoreAndCombo(Color target)
    {
        m_combo++;
        if (target == Color.red)
            m_combo = 0;
        m_comboText.text = "" + m_combo;


        if (m_combo < 10)
        {
            m_scoreMultiplier.text = null;

            if (target == Color.yellow)
                m_score += 1;
            else if (target == Color.green)
                m_score += 3;
        }
        else if (m_combo >= 20)
        {
            m_scoreMultiplier.text = "x3";

            if (target == Color.yellow)
                m_score += 3;
            else if (target == Color.green)
                m_score += 9;
        }
        else if (m_combo >= 10)
        {
            m_scoreMultiplier.text = "x2";

            if (target == Color.yellow)
                m_score += 2;
            else if (target == Color.green)
                m_score += 6;
        }

        m_scoreText.text = "" + m_score;
    }

    private void HighScoreAndHighCombo()
    {
        if (m_score > HScore)
        {
            HScore = m_score;
            PlayerPrefs.SetInt("Player HighScore", HScore);
        }
        if (m_combo > HCombo)
        {
            HCombo = m_combo;
            PlayerPrefs.SetInt("Player HighCombo", HCombo);
        }
    }
}
