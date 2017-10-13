using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rackham : MonoBehaviour {

	ReactionController RC;
	DialogueTrigger DT;
	Text noteText;
	bool karmaAffected;
	// Use this for initialization
	void Start () {
		karmaAffected = false;
		noteText = GameObject.Find ("NoteText").GetComponent<Text>();
		RC = FindObjectOfType<ReactionController> ();
		DT = GetComponent <DialogueTrigger> ();

	}

	// Update is called once per frame
	void Update () {
		if(DT.optionChoice ==  0)
		{
			if (!karmaAffected) {
				RC.AddKarma (+5);
			}
			DT.doneConversation = false;
			karmaAffected = true;
		}
		if(DT.optionChoice ==  1)
		{
			if (!karmaAffected) {
				RC.AddKarma (+10);
			}
			noteText.text += "A guest at the castle, Rackham, told me there might be something interesting in another guest's room.\n";
			DT.doneConversation = true;
		}
		if(DT.optionChoice ==  2)
		{
			if (!karmaAffected) {
				RC.AddKarma (-10);
			}
			DT.doneConversation = false;
			karmaAffected = true;
		}
		DT.optionChoice = -1;
	}
}
