using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public GameObject Target;
    public GameObject Player;
    private int YellowRange;
    private int GreenRange;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        YellowRange = 5;
        GreenRange = 2;

        Target.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Target.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);

        float dist = Mathf.Abs(Target.transform.position.z - Player.transform.position.z);

        Debug.Log("Distance = " + dist);

        if (dist <= YellowRange && dist > GreenRange)
        {
            Target.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (dist <= GreenRange)
        {
            Target.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (dist >= YellowRange)
        {
            Target.GetComponent<Renderer>().material.color = Color.red;
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