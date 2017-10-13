using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameController GC;
	public PlayerMovement PM;
	public Canvas canvas;
	Canvas notesCanvas;
	Canvas collectCanvas;
	GameObject openMenu;
	Canvas optionsCanvas;
	Button resume;
	Button save;
	Button load;
	Button options;
	Button exit;
	Button menu;
	Button notes;
	Button collectables;
	Text resumeText;
	void Start()
	{
		optionsCanvas = GameObject.Find ("OptionsMenu").GetComponent <Canvas> ();
		notesCanvas = GameObject.Find ("NotesCanvas").GetComponent <Canvas> ();
		collectCanvas = GameObject.Find ("CollectionCanvas").GetComponent <Canvas> ();

		GC = FindObjectOfType<GameController> ();
		PM = FindObjectOfType<PlayerMovement> ();
		openMenu = GameObject.Find ("ButtonOpenMenu");
		resume = GameObject.Find ("ButtonResume").GetComponent <Button> ();
		save = GameObject.Find ("ButtonSave").GetComponent <Button> ();
		load = GameObject.Find ("ButtonLoad").GetComponent <Button> ();
		options = GameObject.Find ("ButtonOptions").GetComponent <Button> ();
		exit = GameObject.Find ("ButtonExit").GetComponent <Button> ();
		menu = GameObject.Find ("ButtonOpenMenu").GetComponent <Button> ();
		collectables = GameObject.Find ("ButtonCollectables").GetComponent <Button> ();
		notes = GameObject.Find ("ButtonNotes").GetComponent <Button> ();
		resumeText = GameObject.Find ("ResumeText").GetComponent <Text> ();
		resume.onClick.AddListener (() => DoButtonAction ("Resume"));
		collectables.onClick.AddListener (() => DoButtonAction ("Collectables"));
		notes.onClick.AddListener (() => DoButtonAction ("Notes"));
		save.onClick.AddListener (() => DoButtonAction ("Save"));
		load.onClick.AddListener (() => DoButtonAction ("Load"));
		options.onClick.AddListener (() => DoButtonAction ("Options"));
		exit.onClick.AddListener (() => DoButtonAction ("Exit"));
		menu.onClick.AddListener (() => DoButtonAction ("Menu"));
	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (optionsCanvas.isActiveAndEnabled == false) {
				Pause ();
			}
			else
			{
				optionsCanvas.enabled = false;
				canvas.enabled = true;
			}
		
		}
		/*if (PM.mobile == false) {
			openMenu.SetActive (false);
		} 
		else 
		{
			openMenu.SetActive (true);

		}*/
	}
	public void Pause ()
	{
		
			if (canvas.GetComponent <Canvas>().isActiveAndEnabled == false) {
				canvas.GetComponent <Canvas> ().enabled = true;
				Time.timeScale = 0;
			} else 
			{
				canvas.GetComponent <Canvas> ().enabled = false;
				Time.timeScale = 1;
			}


	}
	public void DoButtonAction(string action)
	{
		if (action == "Resume") {
			resumeText.text = "Resume";
			canvas.GetComponent <Canvas> ().enabled = false;
			Time.timeScale = 1;
		}
		else if (action == "Save") 
		{
			GC.Save ();
		} 
		else if (action == "Load")
		{
			GC.Load ();

		}
		else if (action == "Options")
		{
			canvas.enabled = false;
			optionsCanvas.enabled = true;
		}
		else if (action == "Exit")
		{
			Application.Quit ();
		}
		else if (action == "Menu")
		{
			Pause ();
		}
		else if(action == "Notes")
		{
			canvas.enabled = false;
			notesCanvas.enabled = true;
		}
		else if(action == "Collectables" )
		{
			canvas.enabled = false;
			collectCanvas.enabled = true;
		}
	}
}
