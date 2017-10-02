using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class GameController : MonoBehaviour {

	public static GameController control;
	public int karma = 50;
	public Dictionary <string,Item> ItemSave;
	public Item Lockpick;
	public PlayerMovement PM;
	public DialogueDone DD;
	Transform playerPosition;
	Inventory inv;
	DialogueList dia;
	List <string> sceneName;
	Button option1;
	Button option2;
	Button option3;
	Text ChatText;
	Text choice1;
	Text choice2;
	Text choice3;
	Text currentRoom;
	Text currentKarma;
	float playerPosx;
	float playerPosy;
	float playerPosz;
	float playerRotx;
	float playerRoty;
	float playerRotz;
	float playerRotw;
	// controls the dialogue box on and off
	Canvas cnvs;
	string what;
	//lists for the dialogue.


	// placeholder list

	List <string>holder;
	// Creates the Dictionary dialogue which stores information of what the npc says.


	// Use this for initialization
	void Awake () {
		if (control == null) 
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if(control !=this)
		{
			Destroy (gameObject);
		}

		// Getting inventory for saving;
		ItemSave = new Dictionary<string, Item>();
		AddItemSave ();
		//add scene by index
		AddScene (1);
		//enables the dialogue canvas.
		dia = gameObject.GetComponent <DialogueList>();
		sceneName = new List<string> ();
	
		// connecting gameObjects to the gamecontroller.

		ChatText = (Text)GameObject.Find ("TextDialogue").GetComponent <Text> ();
		/*option1 = (Button)GameObject.Find ("ButtonSel1").GetComponent <Button> ();
		option2 = (Button)GameObject.Find ("ButtonSel2").GetComponent <Button> ();
		option3 = (Button)GameObject.Find ("ButtonSel3").GetComponent <Button> ();
		choice1 = (Text)GameObject.Find ("TextSel1").GetComponent <Text> ();
		choice2 = (Text)GameObject.Find ("TextSel2").GetComponent <Text> ();
		choice3 = (Text)GameObject.Find ("TextSel3").GetComponent <Text> ();*/

		//connects dialogue done
		DD = FindObjectOfType<DialogueDone> ();


	
		Scene[] currentScenes = SceneManager.GetAllScenes ();
		foreach (Scene sc in currentScenes) {
			Debug.Log (sc.name);
			if (sc.name != "PersistentCanvas") 
			{
				sceneName.Add (sc.name);

			}
		}
	






	}
	void Start()
	{
		
		inv = GameObject.Find ("Inventory").GetComponent <Inventory>();
		cnvs = GameObject.Find ("CanvasDialogue").GetComponent <Canvas> ();
		currentRoom = (Text)GameObject.Find ("TextCurrentRoom").GetComponent <Text> ();
		currentKarma = (Text)GameObject.Find ("TextKarma").GetComponent <Text> ();
		currentRoom.text = sceneName[0];
		currentKarma.text = "Karma: "+ karma.ToString ();
		playerPosition = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform>();
		PM = FindObjectOfType<PlayerMovement> ();

	}
	void Update()
	{
		
		currentKarma.text = "Karma: "+ karma.ToString ();


	}

	// GetDialogue gets the key in the dictionary which corresponds to character name and a number
	/*public void GetDialogue(string name)
	{
		//pulls the list from the dictionary
		holder = dia.Dialogue [name];
		//changes the text to list items
		ChatText.text = holder [0];
		if (holder.Count > 1) 
		{ 
			option1.gameObject.SetActive (true);
			choice1.text = holder [1];
		}
		else
		{
			option1.gameObject.SetActive (false);
		}
		if (holder.Count > 2) 
		{ 
			option2.gameObject.SetActive (true);
			choice2.text = holder [2];
		}
		else{
			option2.gameObject.SetActive (false);
		}
		if (holder.Count > 3) 
		{
			option3.gameObject.SetActive (true);
			choice3.text = holder [3];
		}
		else
		{
			option3.gameObject.SetActive (false);
		}
		// adds listeners to the buttons that runs NextDialogue
		option1.onClick.AddListener (() =>NextDialogue(0,name,holder));
		option2.onClick.AddListener (() =>NextDialogue(1,name,holder));
		option3.onClick.AddListener (() =>NextDialogue(2,name,holder));



	}

	void NextDialogue(int choice, string who, List<string> theList ){
		// decides which button is pressed and if the next piece of Dialogue exists.

		if (choice == 0 && dia.Dialogue.ContainsKey (who + "0") && !DD.DoneDialogue.ContainsKey (who)) {
			what = who + "0";
			RemoveListeners ();
			DD.AddToDoneDialogue (who, theList);
			Debug.Log (who);
			// Runs getDialogue again
			GetDialogue (what);
	
		} 
		else if (choice == 1 && dia.Dialogue.ContainsKey (who + "1") && !DD.DoneDialogue.ContainsKey (who)) {
			what = who + "1";
			RemoveListeners();
			DD.AddToDoneDialogue (who, theList);
			GetDialogue (what);
		

		} 
		else if (choice == 2 && dia.Dialogue.ContainsKey (who + "2") && !DD.DoneDialogue.ContainsKey (who)) {
			what = who + "2";
			RemoveListeners();
			DD.AddToDoneDialogue (who, theList);
			GetDialogue (what);


		} 
		else
		{
			
			Debug.Log ("No dictionary of this name exists");
		}

	}*/

	//remove the listeners from  all the buttons
	void RemoveListeners(){
		option1.onClick.RemoveAllListeners ();
		option2.onClick.RemoveAllListeners ();
		option3.onClick.RemoveAllListeners ();
	}
	// adds persistent canvas to the scene
	void AddScene(int index){
		SceneManager.LoadScene (index,LoadSceneMode.Additive);
	}
	void RemoveScene(int index){
		SceneManager.UnloadSceneAsync (index);
	}
	public void EnableDialogueCanvas(bool b){
		cnvs.enabled = b;
	}
	void AddItemSave()
	{
		ItemSave.Add ("Lockpick",Lockpick);
	}
	public void Save(string name)
	{
		name ="/playerInfo.dat";
		playerPosx = playerPosition.transform.position.x;
		playerPosy = playerPosition.transform.position.y;
		playerPosz = playerPosition.transform.position.x;
		playerRotx = playerPosition.transform.rotation.x;
		playerRoty = playerPosition.transform.rotation.y;
		playerRotz = playerPosition.transform.rotation.z;
		playerRotw = playerPosition.transform.rotation.w;
		Debug.Log("You have saved the game");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + name);

		SaveData data = new SaveData ();
		// What is saved
		if (inv.items [0] != null) 
		{
			data.Item0 = inv.items [0].name;
		}
		if (inv.items [1] != null) 
		{
			data.Item1 = inv.items [1].name;
		}
		if (inv.items [2] != null) {
			data.Item2 = inv.items [2].name;
		}
		if (inv.items [3] != null) 
		{
			data.Item3 = inv.items [3].name;
		}
			
		
		data.Karma = karma;
		data.playerPosx = playerPosx;
		data.playerPosy = playerPosy;
		data.playerPosz = playerPosz;
		data.playerRotx = playerRoty;
		data.playerRoty = playerRoty;
		data.playerRotz = playerRotz;
		data.playerRotw = playerRotw;



		bf.Serialize (file, data);
		file.Close ();
	}
	public void Load(string name)
	{
		name ="/playerInfo.dat";
		if(File.Exists (Application.persistentDataPath + name ))
		{
			Transform temp = new GameObject ().transform;
			BinaryFormatter bf =  new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
			SaveData data = (SaveData)bf.Deserialize (file);
			file.Close ();
			//what is loaded
			for(int i = 0; i<inv.items.Length;i++)
			{
				inv.items [i] = null;
				inv.itemImages[i].sprite = null;
				inv.itemImages[i].enabled = false;
			}
			try{
				
			
				if(ItemSave[data.Item0]!= null)
				{
					
					if (data.Item0 != null) 
					{
						
							inv.AddItem (ItemSave [data.Item0]);


					}
				}

			}
			catch(KeyNotFoundException e)
			{
				Debug.Log("Ha, caught zero " +e.Message);
			}
			catch(ArgumentNullException a){
				Debug.Log ("Another one bits the dust" + a.Message);
			}
			try{


				if(ItemSave[data.Item1]!= null)
				{
					
					if (data.Item1 != null) 
					{

						inv.AddItem (ItemSave [data.Item1]);


					}
				}
			}
			catch(KeyNotFoundException e)
			{
				Debug.Log("Ha, caught one " +e.Message);
			}
			catch(ArgumentNullException a){
				Debug.Log ("Another one bits the dust" + a.Message);
			}
			try{


				if(ItemSave[data.Item2]!= null)
				{
					
					if (data.Item2 != null) 
					{

						inv.AddItem (ItemSave [data.Item2]);


					}
				}
			}
			catch(KeyNotFoundException e)
			{
				Debug.Log("Ha, caught one " +e.Message);
			}
			catch(ArgumentNullException a){
				Debug.Log ("Another one bits the dust" + a.Message);
			}
			try{


				if(ItemSave[data.Item3]!= null)
				{
					if (data.Item3 != null) 
					{

						inv.AddItem (ItemSave [data.Item3]);


					}
				}
			}
			catch(KeyNotFoundException e)
			{
				Debug.Log("Ha, caught one " +e.Message);
			}
			catch(ArgumentNullException a){
				Debug.Log ("Another one bits the dust" + a.Message);
			}
			karma = data.Karma;
			playerPosx = data.playerPosx;
			playerPosy = data.playerPosy;
			playerPosz = data.playerPosz;
			playerRotx = data.playerRoty;
			playerRoty = data.playerRoty;
			playerRotz = data.playerRotz;
			playerRotw = data.playerRotw;
			playerPosition.transform.position = new Vector3(playerPosx,playerPosy,playerPosz);
			temp.rotation = new Quaternion (playerRotx, playerRoty, playerRotz, playerRotw);
			playerPosition.transform.rotation = temp.rotation;
			Debug.Log (inv.items [0]);
			Debug.Log("You have loaded a saved game");

		}
	}
}
[Serializable]
class SaveData
{
	public int Karma;
	public float playerPosx;
	public float playerPosy;
	public float playerPosz;
	public float playerRotx;
	public float playerRoty;
	public float playerRotz;
	public float playerRotw;
	public int roomIndex;
	public string Item0;
	public string Item1;
	public string Item2;
	public string Item3;





}