using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int Health;
    public int Damage;
    public int CurHealth;

    // Start is called before the first frame update
    void Start()
    {
        Damage = 20;
        Health = 100;

        CurHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        CurHealth = Health;

        if (CurHealth <= 0)
        {
            Debug.Log("Dead");
        }


    }

    void TakeDamage(int damage)
    {
        CurHealth = CurHealth - damage;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            TakeDamage(20);
            Debug.Log(CurHealth);
        }
    }
}
