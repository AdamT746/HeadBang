using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool MenuToggle;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Toggle);
            MenuToggle = true;
        Menu.SetActive(MenuToggle);
    }

    // Update is called once per frame
    void Toggle ()
    {
        MenuToggle ^= true;
        Menu.SetActive(MenuToggle);
    }
}
