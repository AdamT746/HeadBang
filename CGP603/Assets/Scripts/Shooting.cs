using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private LineRenderer m_line;
    public float m_destroyTime;

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
}
