using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
	
	string name;

	public GameController gController;
	DialogueList dia;


	void Start () {
		gController = FindObjectOfType<GameController> ();
		dia = FindObjectOfType<DialogueList> ();
	}


	/*public void GiveDialogue(string name)
	{
		

		if (dia.Dialogue.ContainsKey (name)) {
			gController.GetDialogue (name);
		}

	}*/






}
