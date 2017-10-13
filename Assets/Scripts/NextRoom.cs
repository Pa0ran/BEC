using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour {
	List <int> sceneNumber;
	GameController GC;
	public string id;
	RoomController RC;
	Collider2D temp;
	// when the trigger is colided with
	void Start(){
		GC = FindObjectOfType<GameController> ();
		RC = FindObjectOfType<RoomController> ();
		sceneNumber= new List<int> ();
		Scene[] currentScenes = SceneManager.GetAllScenes ();
		foreach (Scene sc in currentScenes) {
			
			if (sc.buildIndex != 0) 
			{
				sceneNumber.Add (sc.buildIndex);

			}
		}
	
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		temp = coll;
		StartCoroutine (Wait ());
		GC.SaveScene ();

	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (0.1f);
		RC.GoToRoom (id,temp);
	}
}
