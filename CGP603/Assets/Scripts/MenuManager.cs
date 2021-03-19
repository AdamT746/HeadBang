using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
	// Start is called before the first frame update
	public Button StartButton;
	public Button QuitButton;
	public Button MenuButton;

	void Start()
	{
		Button Start = StartButton.GetComponent<Button>();
		Start.onClick.AddListener(StartGame);

		Button Quit = QuitButton.GetComponent<Button>();
		Quit.onClick.AddListener(QuitGame);

		Button Exit2Menu = MenuButton.GetComponent<Button>();
		Exit2Menu.onClick.AddListener(ExitToMenu);

	}

	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}
	public void QuitGame()
    {
		Application.Quit(); 
    }
	public void ExitToMenu()
    {
		SceneManager.LoadScene("StartMenu");
		Debug.Log("Pressed");
	}
}
