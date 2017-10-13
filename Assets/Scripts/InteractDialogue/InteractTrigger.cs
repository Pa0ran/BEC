using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour {

	public Item item;
	public bool GetItem;
	public bool doneConversation;
	InteractManager IM;
	public ObjectDialogue dialogue;
	public void TriggerInteract()
	{
		FindObjectOfType<InteractManager> ().StartDialogue(dialogue);
		IM = FindObjectOfType<InteractManager> ();
		IM.StartDialogue (dialogue);
		IM.IT = GetComponent <InteractTrigger> ();
	}
}
