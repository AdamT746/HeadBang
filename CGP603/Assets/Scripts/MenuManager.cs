using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
	// Start is called before the first frame update
	public Button StartButton;

	void Start()
	{
		Button btn = StartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
