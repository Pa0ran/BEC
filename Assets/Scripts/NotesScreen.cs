using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesScreen : MonoBehaviour {

	Canvas noteCanvas;
	Canvas menuCanvas;
	Button backButton;
	Text notesText;
	// Use this for initialization
	void Start () {
		noteCanvas = GameObject.Find ("NotesCanvas").GetComponent <Canvas> ();
		menuCanvas = GameObject.Find ("PauseCanvas").GetComponent <Canvas> ();
		backButton = GameObject.Find ("ButtonToMenuFromNotes").GetComponent <Button> ();
		notesText= GameObject.Find ("NoteText").GetComponent <Text> ();
		backButton.onClick.AddListener (() => ButtonClick());
	}
	
	// Update is called once per frame
	void ButtonClick () {
		noteCanvas.enabled = false;
		menuCanvas.enabled = true;
		
	}
}
