using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TargetMove : MonoBehaviour
{
    public GameObject Target; //list for multiple skull model parts with getcomponentsinchildren?
    public GameObject Player;
    public GameObject[] notesVFX;
    private int YellowRange;
    private int GreenRange;
    public float Speed;
    bool ShowParicles,perfectHit;

    public int Health;
    public int Damage;
    public int CurHealth;

    public AudioSource sound;
    public AudioClip[] destroy;

    // Start is called before the first frame update
    void Start()
    {
        YellowRange = 4;
        GreenRange = 1;

        
        Damage = 20;
        Health = 100;

        CurHealth = Health;

        Target = gameObject;
        Target.GetComponent<Renderer>().material.color = Color.red;
        //gameObject.GetComponentsInChildren<Renderer>();

        sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CurHealth = Health;

        //Debug.Log(CurHealth);

        //Target.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
        Target.transform.Translate(Vector3.back * Speed * Time.deltaTime);

        float dist = Mathf.Abs(Target.transform.position.z - Player.transform.position.z);

        //Debug.Log("Distance = " + dist);
        if (CurHealth <= 0)
        {
            Debug.Log("Dead");
        }

        // if (dist <= YellowRange && dist > GreenRange)
        // {
        //     Target.GetComponent<Renderer>().material.color = Color.yellow;
        //     perfectHit = false;
        // }
        // else if (dist <= GreenRange)
        // {
        //     Target.GetComponent<Renderer>().material.color = Color.green;
        //     perfectHit = true;
        // }
        // else if (dist >= YellowRange)
        // {
        //     Target.GetComponent<Renderer>().material.color = Color.red;
        //     perfectHit = false;
        // }
        if (this.gameObject.transform.position.z >= -10 && Target.transform.position.z <= -7)
            perfectHit = true;
        else
            perfectHit = false;
        
    }

    void TakeDamage(int damage)
    {
        CurHealth = CurHealth - damage;
        
    }


    void OnDestroy()
    {
        sound.clip = destroy[Random.Range(0, destroy.Length)];
        sound.Play();
        
        if (perfectHit)
        {
            Instantiate(notesVFX[0], transform.position, Quaternion.identity);
            //Debug.LogWarning("<color=red>BOOM!!!!!!!!!!!!!!! </color>");
        }
        else
            Instantiate(notesVFX[1], transform.position, Quaternion.identity); 
    }
    IEnumerator PerfectHit()
    {
        perfectHit = true;
        yield return new WaitForSeconds(0.5f);
        perfectHit = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            TakeDamage(20);
            Debug.Log(CurHealth);

            Destroy(Target);
        }
    }
}