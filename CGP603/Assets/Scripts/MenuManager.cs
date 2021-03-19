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

	void Start()
	{
		Button Start = StartButton.GetComponent<Button>();
		Start.onClick.AddListener(StartGame);

		Button Quit = QuitButton.GetComponent<Button>();
		Quit.onClick.AddListener(QuitGame);



	}

	void StartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	void QuitGame()
    {
		Application.Quit(); 
    }
}
