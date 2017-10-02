using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	 Button playButton;
	 Button optionsButton;
	 Button exitButton;

	void Start()
	{

		playButton = (Button)GameObject.Find ("PlayButton").GetComponent<Button> ();
		playButton.onClick.AddListener (() => (DoOnClick ("Play")));
		optionsButton = (Button)GameObject.Find ("OptionsButton").GetComponent<Button> ();
		optionsButton.onClick.AddListener (() => (DoOnClick("Options")));
		exitButton = (Button)GameObject.Find ("ExitButton").GetComponent<Button> ();
		exitButton.onClick.AddListener (() => (DoOnClick ("Exit")));
	}
	void DoOnClick(string buttons)
	{
		if (buttons == "Play") {
			Debug.Log ("You launched the game");
			SceneManager.LoadScene ("PersistentCanvas",LoadSceneMode.Single);
		
		}
		if (buttons == "Options") 
		{
			Debug.Log ("Options menu");
		}
		if (buttons == "Exit") {
			Debug.Log ("You have quit the game");
			Application.Quit ();
		}

	}

}
