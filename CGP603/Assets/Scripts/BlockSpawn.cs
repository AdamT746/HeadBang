using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public GameObject Target;
    public GameObject Position;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(3f,7f);
        print(timer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0) //Input.GetKeyDown("f"))
        {
            Instantiate(Target, Position.transform.position, transform.rotation);
            timer = Random.Range(3f,7f);
            print(timer);
        }
    }
}
