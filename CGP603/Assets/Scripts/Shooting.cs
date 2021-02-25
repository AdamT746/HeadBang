using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private LineRenderer m_line;
    public float m_destroyTime;
    public int m_score;
    public int m_combo;

    [Header("Needed Variables")]
    public Transform m_barrel;
    public Material m_gunMat;

    // Start is called before the first frame update
    void Start()
    {
        m_line = GetComponent<LineRenderer>();
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
                //Add score and combo    --//Assuming yellow is perfect and green is great//--
                if (hit.collider.gameObject.name == "Target(Clone)")
                {
                    Color targetMaterial = hit.collider.GetComponent<Renderer>().material.color;

                    ScoreAndCombo(targetMaterial);
                }
                else
                {
                    m_combo = 0;
                }

                StartCoroutine(DestroyLine());   
                SetupLine(hit);

                Destroy(hit.collider.gameObject);
            }
        }
    }

    void SetupLine(RaycastHit hito)
    {
        m_line.sortingLayerName = "OnTop";
        m_line.sortingOrder = 5;
        m_line.positionCount=2;
        m_line.SetPosition(0, m_barrel.position);
        m_line.SetPosition(1, hito.point);
        m_line.startWidth=0.05f;
        m_line.endWidth = 0.05f;
        m_line.useWorldSpace = true;
        m_line.material = m_gunMat;
    }

    IEnumerator DestroyLine()
    {
        m_line.enabled = !m_line.enabled;

        yield return new WaitForSeconds(0.2f);

        m_line.enabled = !m_line.enabled;
    }

    private void ScoreAndCombo(Color target)
    {
        m_combo++;

        if (target == Color.yellow)
            m_score += 50;
        else if (target == Color.green)
            m_score += 25;
    }
}
