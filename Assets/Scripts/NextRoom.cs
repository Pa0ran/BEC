using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour {
	string sceneName;
	// when the trigger is colided with
	void Start(){
		

	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//retrieve name of scene
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;
		//if the trigger is entered by player
		if (coll.gameObject.tag == "Player") 
		{	//load next level from dungeon
			Debug.Log("hit");
			Debug.Log(sceneName);
			if (sceneName == "Dungeon")
			{
				SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
			}
		}
	}
}
