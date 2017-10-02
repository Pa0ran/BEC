using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueDone : MonoBehaviour {

	public Dictionary <string,List<string>> DoneDialogue;
	DialogueList DL;
	void Start()
	{
		DoneDialogue = new Dictionary<string,List<string>> ();
		DL = FindObjectOfType<DialogueList> ();
	}
	public void AddToDoneDialogue(string listName, List<string> name)
	{
		DoneDialogue.Add (listName,name);
	}


}
