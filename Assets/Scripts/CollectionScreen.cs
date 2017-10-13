using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScreen : MonoBehaviour {

	Canvas CollectionCanvas;
	Canvas menuCanvas;
	Button backButton;
	Text notesText;
	// Use this for initialization
	void Start () {
		CollectionCanvas = GameObject.Find ("CollectionCanvas").GetComponent <Canvas> ();
		menuCanvas = GameObject.Find ("PauseCanvas").GetComponent <Canvas> ();
		backButton = GameObject.Find ("ButtonToMenuFromCollection").GetComponent <Button> ();
		notesText= GameObject.Find ("NoteText").GetComponent <Text> ();
		backButton.onClick.AddListener (() => ButtonClick());
	}

	// Update is called once per frame
	void ButtonClick () {
		CollectionCanvas.enabled = false;
		menuCanvas.enabled = true;

	}
}