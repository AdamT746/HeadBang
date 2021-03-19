using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    // Assign both of these in the editor.
    public GameObject Options;
    public GameObject Menu;
    public Button Optionsbutton;
    public Button Menubutton;


    void Start()
    {
        Optionsbutton.onClick.AddListener(() =>
        {
            Options.SetActive(true);
            Menu.SetActive(false);
        });
        Menubutton.onClick.AddListener(() =>
        {
            Options.SetActive(false);
            Menu.SetActive(true);
        });
    }      
       
}