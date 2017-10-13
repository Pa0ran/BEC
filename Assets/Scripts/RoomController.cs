using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {
	GameController GC;
	RoomController RC;
	List <int> sceneNumber;
	Scene[] currentScenes;
	public Transform goTo;
	GameObject Player;
	// Use this for initialization
	void Start () {
		GC = FindObjectOfType<GameController> ();
		RC = FindObjectOfType<RoomController> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
		sceneNumber= new List<int> ();
		currentScenes = SceneManager.GetAllScenes ();
		foreach (Scene sc in currentScenes) {

			if (sc.buildIndex != 0) 
			{
				sceneNumber.Add (sc.buildIndex);

			}
		}
	}
	
	public void GoToRoom(string id,Collider2D coll)
	{
		//retrieve name of scene
		//if the trigger is entered by player
	
		if (coll.gameObject.tag == "Player") 
		{	//load next level from dungeon


			// Dungeon buildindex = 1

			if (sceneNumber[0] == 1)
			{
				if (id == "DungeonToCorridor") 
				{


					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					//corridor Buildindex = 5
					SceneManager.LoadScene (5, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromDungeonToCorridor").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
					GC.LoadScene (5);



				}
			}
			if(sceneNumber[0] == 5)
			{
				if(id == "CorridorToDungeon")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// Outside Buildindex = 3
					SceneManager.LoadScene (1, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromCorridorToDungeon").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
					GC.LoadScene (1);
				}
			}
			//corrudir buildindex = 5
			if(sceneNumber[0] == 5)
			{
				if(id == "CorridorToOutside")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// Outside Buildindex = 3
					SceneManager.LoadScene (2, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromCorridorToOutside").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
					GC.LoadScene (2);

				}
			}
			if(sceneNumber[0] == 2)
			{
				if(id == "OutsideToCorridor")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// Outside Buildindex = 3
					SceneManager.LoadScene (5, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromOutsideToCorridor").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
					GC.LoadScene (5);
				}
			}
			if(sceneNumber[0] == 5)
			{
				if(id == "CorridorToUpstairs")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// upstairs Buildindex = 3
					SceneManager.LoadScene (3, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromCorridorToUpstairs").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
					GC.LoadScene (3);


				}
				}
			}
			if(sceneNumber[0] == 3)
			{
				if(id == "UpstairsToCorridor")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// Outside Buildindex = 3
					SceneManager.LoadScene (5, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();	
					goTo = GameObject.Find ("FromUpstairsToCorridor").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
				GC.LoadScene (5);

				}
			}
			if(sceneNumber[0] == 3)
			{
				if(id == "UpstairsToQueens")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// Outside Buildindex = 3
					SceneManager.LoadScene (6, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromUpstairsToQueens").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
				GC.LoadScene (6);
				}
			}
			// queens bedroom = 6
			if(sceneNumber[0] == 6)
			{
				if(id == "QueensToUpstairs")
				{
					SceneManager.UnloadSceneAsync (sceneNumber [0]);
					// Outside Buildindex = 3
					SceneManager.LoadScene (3, LoadSceneMode.Additive);
					GC.GetCurrentScenes ();
					goTo = GameObject.Find ("FromQueensToUpstairs").GetComponent <Transform> ();
					Vector3 pos = goTo.position;
					Quaternion rot = goTo.rotation;
					Player.transform.position = pos;
					Player.transform.rotation = rot;
				GC.LoadScene (3);
				}
			}
		if(sceneNumber[0] == 4)
		{
			if(id == "PriestToOutside")
			{
				SceneManager.UnloadSceneAsync (sceneNumber [0]);
				// Outside Buildindex = 3
				SceneManager.LoadScene (2, LoadSceneMode.Additive);
				GC.GetCurrentScenes ();
				goTo = GameObject.Find ("FromPriestToOutside").GetComponent <Transform> ();
				Vector3 pos = goTo.position;
				Quaternion rot = goTo.rotation;
				Player.transform.position = pos;
				Player.transform.rotation = rot;
				GC.LoadScene (2);
			}
		}
		if(sceneNumber[0] == 4)
		{
			if(id == "PriestToGraveyard")
			{
				SceneManager.UnloadSceneAsync (sceneNumber [0]);
				// Outside Buildindex = 3
				SceneManager.LoadScene (2, LoadSceneMode.Additive);
				GC.GetCurrentScenes ();
				goTo = GameObject.Find ("FromPriestToGraveyard").GetComponent <Transform> ();
				Vector3 pos = goTo.position;
				Quaternion rot = goTo.rotation;
				Player.transform.position = pos;
				Player.transform.rotation = rot;
				GC.LoadScene (2);
			}
		}
		if(sceneNumber[0] == 2)
		{
			if(id == "OutsideToPriest")
			{
				SceneManager.UnloadSceneAsync (sceneNumber [0]);
				// Outside Buildindex = 3
				SceneManager.LoadScene (4, LoadSceneMode.Additive);
				GC.GetCurrentScenes ();
				goTo = GameObject.Find ("FromOutsideToPriest").GetComponent <Transform> ();
				Vector3 pos = goTo.position;
				Quaternion rot = goTo.rotation;
				Player.transform.position = pos;
				Player.transform.rotation = rot;
				GC.LoadScene (4);
			}
		}
		if(sceneNumber[0] == 2)
		{
			if(id == "GraveyardToPriest")
			{
				SceneManager.UnloadSceneAsync (sceneNumber [0]);
				// Outside Buildindex = 3
				SceneManager.LoadScene (4, LoadSceneMode.Additive);
				GC.GetCurrentScenes ();
				goTo = GameObject.Find ("FromGraveyardToPriest").GetComponent <Transform> ();
				Vector3 pos = goTo.position;
				Quaternion rot = goTo.rotation;
				Player.transform.position = pos;
				Player.transform.rotation = rot;
				GC.LoadScene (4);
			}
		}
		if(id == "GoDown"){
			goTo = GameObject.Find ("GoDown").GetComponent <Transform> ();
			Vector3 pos = goTo.position;
			Quaternion rot = goTo.rotation;
			Player.transform.position = pos;
			Player.transform.rotation = rot;
		}
		if(id == "GoUp"){
			goTo = GameObject.Find ("GoUp").GetComponent <Transform> ();
			Vector3 pos = goTo.position;
			Quaternion rot = goTo.rotation;
			Player.transform.position = pos;
			Player.transform.rotation = rot;
		}
			currentScenes = SceneManager.GetAllScenes ();
			sceneNumber.Clear();
			foreach (Scene sc in currentScenes) {

				if (sc.buildIndex != 0) 
				{
					sceneNumber.Add (sc.buildIndex);

				}
			}

		}


}
