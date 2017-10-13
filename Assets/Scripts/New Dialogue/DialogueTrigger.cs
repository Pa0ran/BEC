using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public int optionChoice = -1;
	public bool doneConversation;
	DialogueManager DM;
	public Dialogue dialogue;
	public void TriggerDialogue()
	{
		DM = FindObjectOfType<DialogueManager> ();
		DM.StartDialogue (dialogue);
		DM.DT = GetComponent <DialogueTrigger> ();
	}
}
