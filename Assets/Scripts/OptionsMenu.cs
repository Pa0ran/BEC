using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	Canvas optionsCanvas;
	Canvas menuCanvas;
	Button back;
	Text MasterVolumeText;
	// Use this for initialization
	void Start () {
		menuCanvas = GameObject.Find ("PauseCanvas").GetComponent <Canvas> ();
		optionsCanvas = GameObject.Find ("OptionsMenu").GetComponent <Canvas> ();
		back = GameObject.Find ("ButtonBackToMenu").GetComponent <Button> ();
		MasterVolumeText = GameObject.Find ("MasterVolumeText").GetComponent <Text> ();
		back.onClick.AddListener (() => DoButtonThing (0));
	}
	
	// Update is called once per frame
	void DoButtonThing (int choice) {

		if(choice == 0)
		{
			menuCanvas.enabled = true;
			optionsCanvas.enabled = false;
		}
	}
}
