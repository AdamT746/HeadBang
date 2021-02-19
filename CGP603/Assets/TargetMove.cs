using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{

    public GameObject Target;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Target.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(Target);
        }
    }
}
