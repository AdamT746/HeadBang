using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
	// Start is called before the first frame update
	public Button StartButton;
	public Button MenuButton;
	public Button QuitButton;

	void Start()
	{
		Button Start = StartButton.GetComponent<Button>();
		Start.onClick.AddListener(StartGame);

		Button Quit = QuitButton.GetComponent<Button>();
		Quit.onClick.AddListener(QuitGame);

		Button Menu = MenuButton.GetComponent<Button>();
		Menu.onClick.AddListener(QuitToMenu);

	}

	void StartGame()
	{
		SceneManager.LoadScene("Game");
	}
	void QuitGame()
    {
		Application.Quit(); 
    }
	void QuitToMenu()
    {
		SceneManager.LoadScene("StartMenu");
		Debug.Log("Pressed");
	}
}
