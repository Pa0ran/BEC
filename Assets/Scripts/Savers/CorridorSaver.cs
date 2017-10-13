using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorridorSaver : MonoBehaviour {

	public Item lockpick;
	public DialogueTrigger StorageWorker;
	public bool StorageTalk;
	// true is open, false is closed

	public Inventory inv;
	// Use this for initialization
	void Start () {
		inv = FindObjectOfType<Inventory> ();


	}

	// Update is called once per frame
	void Update () {
		Scene[] currentScenes = SceneManager.GetAllScenes ();
		foreach (Scene sc in currentScenes) {

			if(sc.buildIndex == 5){
				if (StorageWorker == null) {
					StorageWorker = GameObject.Find ("Storage Worker").GetComponent <DialogueTrigger> ();
				}
			}

		}
			

		



	}
		public void CorridorLoad()
	{

		Debug.Log ("Loading Corridor");

		StartCoroutine (DoInSeconds (0.2f));

	}

	IEnumerator DoInSeconds(float seconds)
	{
		
		yield return new WaitForSecondsRealtime (0.2f);
		if(StorageTalk == true){
			StorageWorker.doneConversation = true;
		}
	
	}
}
