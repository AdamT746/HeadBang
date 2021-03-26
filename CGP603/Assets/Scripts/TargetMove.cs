using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TargetMove : MonoBehaviour
{
    public GameObject Target; //list for multiple skull bits with getcomponentsinchildren?
    public GameObject Player;
    public GameObject notesVFX;
    private int YellowRange;
    private int GreenRange;
    public float Speed;
    bool perfectHit;

    // Start is called before the first frame update
    void Start()
    {
        YellowRange = 4;
        GreenRange = 1;

        Target = this.gameObject;
        Target.GetComponent<Renderer>().material.color = Color.red;
        //gameObject.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Target.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
        Target.transform.Translate(Vector3.forward * -Speed * Time.deltaTime);

        float dist = Mathf.Abs(Target.transform.position.z - Player.transform.position.z);

        //Debug.Log("Distance = " + dist);

        if (dist <= YellowRange && dist > GreenRange)
        {
            Target.GetComponent<Renderer>().material.color = Color.yellow;
            perfectHit = false;
        }
        else if (dist <= GreenRange)
        {
            Target.GetComponent<Renderer>().material.color = Color.green;
            perfectHit = true;
        }
        else if (dist >= YellowRange)
        {
            Target.GetComponent<Renderer>().material.color = Color.red;
            perfectHit = false;
        }
    }
    void OnDestroy()
    {
        if (perfectHit)
        {
            Instantiate(notesVFX, transform.position, Quaternion.identity);
            Debug.LogWarning("<color=red>BOOM!!!!!!!!!!!!!!! </color>");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(Target);
        }
    }
}