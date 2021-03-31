using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int Health;
    public int CurHealth;
    public Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;

        CurHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurHealth <= 0)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene("LevelEnd");
        }

        HealthText.text = "Health " + CurHealth;
    }

    void TakeDamage(int damage)
    {
        CurHealth -= damage;
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
