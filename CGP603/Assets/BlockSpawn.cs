using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public GameObject Target;
    public GameObject Position;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            Instantiate(Target, Position.transform.position, Quaternion.identity);
        }
    }
}
