using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameController GC;
	public PlayerMovement PM;
	public Canvas canvas;
	GameObject openMenu;
	Button resume;
	Button save;
	Button load;
	Button options;
	Button exit;
	Button menu;
	void Start()
	{

		GC = FindObjectOfType<GameController> ();
		PM = FindObjectOfType<PlayerMovement> ();
		openMenu = GameObject.Find ("ButtonOpenMenu");
		resume = GameObject.Find ("ButtonResume").GetComponent <Button> ();
		save = GameObject.Find ("ButtonSave").GetComponent <Button> ();
		load = GameObject.Find ("ButtonLoad").GetComponent <Button> ();
		options = GameObject.Find ("ButtonOptions").GetComponent <Button> ();
		exit = GameObject.Find ("ButtonExit").GetComponent <Button> ();
		menu = GameObject.Find ("ButtonOpenMenu").GetComponent <Button> ();
		resume.onClick.AddListener (() => DoButtonAction ("Resume"));
		save.onClick.AddListener (() => DoButtonAction ("Save"));
		load.onClick.AddListener (() => DoButtonAction ("Load"));
		options.onClick.AddListener (() => DoButtonAction ("Options"));
		exit.onClick.AddListener (() => DoButtonAction ("Exit"));
		menu.onClick.AddListener (() => DoButtonAction ("Menu"));
	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
		if (PM.mobile == false) {
			openMenu.SetActive (false);
		} 
		else 
		{
			openMenu.SetActive (true);

		}
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
			canvas.GetComponent <Canvas> ().enabled = false;
			Time.timeScale = 1;
		}
		else if (action == "Save") 
		{
			GC.Save ("something");
		} 
		else if (action == "Load")
		{
			GC.Load ("something");
		}
		else if (action == "Options")
		{
			// open options
		}
		else if (action == "Exit")
		{
			Application.Quit ();
		}
		else if (action == "Menu")
		{
			Pause ();
		}
	}
}
