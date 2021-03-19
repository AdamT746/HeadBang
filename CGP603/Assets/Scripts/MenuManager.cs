using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
	// Start is called before the first frame update


	void Start()
	{
		

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
	public void Next()
    {
		SceneManager.LoadScene("LevelEnd");
    }
}
