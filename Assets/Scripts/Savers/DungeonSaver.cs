using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSaver : MonoBehaviour {

	public Item lockpick;
	public GameObject bedWithLockpick;
	public GameObject door;
	public DialogueTrigger Cellmate;
	public DialogueTrigger Guard;
	public bool pickupLock;
	// true is open, false is closed
	public bool doorStatus;
	public bool CellTalk;
	public bool GuardTalk;
	Transform lockSpawn;
	public Inventory inv;
	// Use this for initialization
	void Start () {
		inv = FindObjectOfType<Inventory> ();

		door = GameObject.Find ("CellDoor1");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Cellmate") != null) 
		{
			if (inv.ContainsItem (lockpick)) {
				pickupLock = true;
			}
			if (door == null) {
			
				door = GameObject.Find ("CellDoor1");
			}
			if (Guard == null) {
				Guard = GameObject.Find ("Guard").GetComponent <DialogueTrigger> ();
			}
			if (Cellmate == null) {
				Cellmate = GameObject.Find ("Cellmate").GetComponent <DialogueTrigger> ();

			}
		}
			
	}
	public void DungeonLoad()
	{

		Debug.Log ("Loading Dungeon");

		StartCoroutine (DoInSeconds (0.2f));

	}

	IEnumerator DoInSeconds(float seconds)
	{
		Debug.Log (CellTalk);
		Debug.Log (GuardTalk);
		yield return new WaitForSecondsRealtime (0.2f);
		if (pickupLock == true) {
			
		}
		if (doorStatus == true) {
			
		door.SetActive (false);

		}
		if(CellTalk == true){
			Cellmate.doneConversation = true;
		}
		if(GuardTalk == true){
			Guard.doneConversation = true;
		}
	
	}
}
