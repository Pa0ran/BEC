using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonGuard01 : MonoBehaviour {

	ReactionController RC;
	DialogueTrigger DT;
	// Use this for initialization
	void Start () {
		RC = FindObjectOfType<ReactionController> ();
		DT = GetComponent <DialogueTrigger> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(DT.optionChoice ==  0)
		{
			RC.AddKarma (-5);
		
		}
		if(DT.optionChoice ==  1)
		{
			RC.AddKarma (-5);
		}
		if(DT.optionChoice ==  2)
		{
			RC.AddKarma (-5);
		}
		DT.optionChoice = -1;
	}
}
