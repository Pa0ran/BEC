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
	VolumeController VC;
	PlayerMovement PM;
	DungeonSaver DS;
	CorridorSaver CS;
	public int LoadThisScene = 1;
	int LoadSceneIndex = 1;
	Transform playerPosition;
	Inventory inv;
	DialogueList dia;
	List <string> sceneName;
	List <int> sceneNumber;
	Button option1;
	Button option2;
	Button option3;
	Button finishButton;
	Text finishText;
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
	public string position;
	string noteString;
	Text noteText;
	// for saving dungeon state
	bool pickupLock;
	bool doorStatus;
	bool cellTalked ;
	bool guardTalked; 
	// save corridor state
	bool storageTalk;
	// controls the dialogue box on and off
	Canvas interactCanvas;
	Canvas cnvs;
	string what;
	public bool collimage1;
	public bool collimage2;
	public bool collimage3;
	public bool collimage4;
	public bool collimage5;
	public bool collimage6;
	public bool collimage7;
	public bool collimage8;
	public bool collimage9;
	public bool collimage10;
	public GameObject collpic1;
	public GameObject collpic2;
	public GameObject collpic3;
	public GameObject collpic4;
	public GameObject collpic5;
	public GameObject collpic6;
	public GameObject collpic7;
	public GameObject collpic8;
	public GameObject collpic9;
	public GameObject collpic10;
	public bool CollectAll;


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
		AddScene (LoadThisScene);
		//enables the dialogue canvas.
		dia = gameObject.GetComponent <DialogueList>();
		sceneName = new List<string> ();
		sceneNumber = new List<int> ();
		finishButton = GameObject.Find ("FinishButton").GetComponent<Button> ();
		finishText = GameObject.Find ("FinishText").GetComponent<Text> ();
		// connecting gameObjects to the gamecontroller.
		CS = FindObjectOfType<CorridorSaver> ();
		ChatText = (Text)GameObject.Find ("TextDialogue").GetComponent <Text> ();
		/*option1 = (Button)GameObject.Find ("ButtonSel1").GetComponent <Button> ();
		option2 = (Button)GameObject.Find ("ButtonSel2").GetComponent <Button> ();
		option3 = (Button)GameObject.Find ("ButtonSel3").GetComponent <Button> ();
		choice1 = (Text)GameObject.Find ("TextSel1").GetComponent <Text> ();
		choice2 = (Text)GameObject.Find ("TextSel2").GetComponent <Text> ();
		choice3 = (Text)GameObject.Find ("TextSel3").GetComponent <Text> ();*/
		currentRoom = (Text)GameObject.Find ("TextCurrentRoom").GetComponent <Text> ();
		currentKarma = (Text)GameObject.Find ("TextKarma").GetComponent <Text> ();
		//find the pictures for collection items
		collpic1 = GameObject.Find ("CollImage1");
		collpic2 = GameObject.Find ("CollImage2");
		collpic3 = GameObject.Find ("CollImage3");
		collpic4 = GameObject.Find ("CollImage4");
		collpic5 = GameObject.Find ("CollImage5");
		collpic6 = GameObject.Find ("CollImage6");
		collpic7 = GameObject.Find ("CollImage7");
		collpic8 = GameObject.Find ("CollImage8");
		collpic9 = GameObject.Find ("CollImage9");
		collpic10 = GameObject.Find ("CollImage10");
		collpic1.SetActive (false);
		collpic2.SetActive (false);
		collpic3.SetActive (false);
		collpic4.SetActive (false);
		collpic5.SetActive (false);
		collpic6.SetActive (false);
		collpic7.SetActive (false);
		collpic8.SetActive (false);
		collpic9.SetActive (false);
		collpic10.SetActive (false);










	}
	void Start()
	{

		VC = FindObjectOfType<VolumeController> ();
		interactCanvas = GameObject.Find ("InteractDialogue").GetComponent<Canvas> ();
		inv = GameObject.Find ("Inventory").GetComponent <Inventory>();
		cnvs = GameObject.Find ("CanvasDialogue").GetComponent <Canvas> ();
		noteText = GameObject.Find ("NoteText").GetComponent <Text> ();

		currentKarma.text = "Karma: "+ karma.ToString ();
		playerPosition = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform>();
		PM = FindObjectOfType<PlayerMovement> ();
		GetCurrentScenes ();
		currentRoom.text = sceneName[0];
		//if player is in dungeon
		if(sceneName[0] == "Dungeon"){
			DS = FindObjectOfType<DungeonSaver> ();
		}

	}
	void Update()
	{
		if (playerPosition == null) {
			playerPosition = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
		}

		currentKarma.text = "Karma: "+ karma.ToString ();
		if(collpic1.activeInHierarchy == true){
			if(collpic2.activeInHierarchy == true){
				if(collpic3.activeInHierarchy == true){
					if(collpic4.activeInHierarchy == true){
						if(collpic5.activeInHierarchy == true){
							if(collpic6.activeInHierarchy == true){
								if(collpic7.activeInHierarchy == true){
									if(collpic8.activeInHierarchy == true){
										if(collpic9.activeInHierarchy == true){
											if(collpic10.activeInHierarchy == true){
												CollectAll = true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		finishButton.onClick.AddListener (() => switchFinishText());

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
	public void GetCurrentScenes(){
		Scene[] currentScenes = SceneManager.GetAllScenes ();
		foreach (Scene sc in currentScenes) {
			if (sc.name != "PersistentCanvas") 
			{
				sceneName.Clear ();
				sceneName.Add (sc.name);
				LoadSceneIndex = sc.buildIndex;

			}
		}
		currentRoom.text = sceneName[0];
	}
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
	void switchFinishText() {
		finishButton.onClick.RemoveAllListeners();
		Time.timeScale = 0;

		if (karma < 40) {
			finishText.text = "You managed to anger half the people in Eldford";
		}
		if (karma >= 41) {
			finishText.text = "You didn't cause that much of a hassle in Eldford, you found new friends " +
			"and managed home safely.";
		}
		finishButton.onClick.AddListener (() => Application.Quit());

	}
	public void EnableDialogueCanvas(bool b){
		cnvs.enabled = b;
	}
	public void EnableInteractCanvas(bool b){
		interactCanvas.enabled = b;
	}
	void AddItemSave()
	{
		ItemSave.Add ("Lockpick",Lockpick);
	}
	public void SaveScene()
	{
		// index == 1
		if (sceneName[0] == "Dungeon")
		{

			pickupLock = DS.pickupLock;
			doorStatus = DS.doorStatus;
			cellTalked = DS.Cellmate.doneConversation;
			guardTalked = DS.Guard.doneConversation;

		}
		// index == 2
		if (sceneName [0] == "Outside") 
		{

		}
		// index == 3
		if (sceneName [0] == "Upstairs") 
		{

		}
		// index == 4
		if (sceneName [0] == "Priest's House") 
		{

		}
		// index == 5
		if (sceneName [0] == "Corridor") 
		{
			storageTalk = CS.StorageWorker.doneConversation;
		}
		// index == 6
		if (sceneName [0] == "Queen's Bedroom") 
		{

		}


	}
	public void LoadScene(int i)
	{
		if (i == 1) {
			DS.doorStatus = doorStatus;
			DS.pickupLock = pickupLock;
			DS.CellTalk = cellTalked;
			DS.GuardTalk = guardTalked;
			DS.DungeonLoad ();
		}
		if (i == 2) {

		}
		if (i == 3) {

		}
		if (i == 4) {

		}
		if (i == 5) {
			CS.StorageTalk = storageTalk;
			CS.CorridorLoad ();
		}
		if (i == 6) {

		}

	}
	public void Save()
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

		data.noteString = noteText.text;


		data.Karma = karma;
		data.playerPosx = playerPosx;
		data.playerPosy = playerPosy;
		data.playerPosz = playerPosz;
		data.playerRotx = playerRoty;
		data.playerRoty = playerRoty;
		data.playerRotz = playerRotz;
		data.playerRotw = playerRotw;
		data.roomIndex = LoadSceneIndex;
		data.MasterVolume = VC.MasterVolume.value;
		if (sceneName[0] == "Dungeon")
		{

			data.pickupLock = DS.pickupLock;
			data.doorStatus = DS.doorStatus;
			data.cellTalked = DS.Cellmate.doneConversation;
			data.guardTalked = DS.Guard.doneConversation;

		}
		if (sceneName [0] == "Corridor") {
			data.storageTalk = CS.StorageWorker.doneConversation;
		}
		//collection bools
		data.collimage1 = collimage1;
		data.collimage2 = collimage2;
		data.collimage3 = collimage3;
		data.collimage4 = collimage4;
		data.collimage5 = collimage5;
		data.collimage6 = collimage6;
		data.collimage7 = collimage7;
		data.collimage8 = collimage8;
		data.collimage9 = collimage9;
		data.collimage10 = collimage10;



		bf.Serialize (file, data);
		file.Close ();
	}
	public void Load()
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
			LoadSceneIndex = data.roomIndex;
			Scene[] currentScenes = SceneManager.GetAllScenes ();
			foreach (Scene sc in currentScenes) {

				if (sc.name != "PersistentCanvas") 
				{
					sceneNumber.Clear ();
					sceneNumber.Add (sc.buildIndex);
					Debug.Log (sceneNumber[0]); 

				}

			}

			SceneManager.UnloadSceneAsync (sceneNumber[0]);
			//SceneManager.LoadScene (LoadSceneIndex);
			SceneManager.LoadScene (LoadSceneIndex,LoadSceneMode.Additive);

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
			VC.MasterVolume.value = data.MasterVolume;
			noteText.text = data.noteString;
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

			// collection loading
			collimage1 = data.collimage1;
			collimage2 = data.collimage2;
			collimage3 = data.collimage3;
			collimage4 = data.collimage4;
			collimage5 = data.collimage5;
			collimage6 = data.collimage6;
			collimage7 = data.collimage7;
			collimage8 = data.collimage8;
			collimage9 = data.collimage9;
			collimage10 = data.collimage10;
			Debug.Log("You have loaded a saved game");
			//when loading dungeon

			DS.doorStatus = data.doorStatus;
			DS.pickupLock = data.pickupLock;
			DS.CellTalk = data.cellTalked;
			DS.GuardTalk = data.guardTalked;

			if (LoadSceneIndex == 1)
			{
				DS.DungeonLoad ();

			}
			if(LoadSceneIndex == 2){

			}
			if(LoadSceneIndex == 3){

			}
			if(LoadSceneIndex == 4){

			}
			//when loading corridor
			CS.StorageTalk = data.storageTalk;
			if(LoadSceneIndex == 5){
				CS.CorridorLoad ();
			}
			if(LoadSceneIndex == 6){

			}
			collpic1.SetActive (collimage1);
			collpic2.SetActive (collimage2);
			collpic3.SetActive (collimage3);
			collpic4.SetActive (collimage4);
			collpic5.SetActive (collimage5);
			collpic6.SetActive (collimage6);
			collpic7.SetActive (collimage7);
			collpic8.SetActive (collimage8);
			collpic9.SetActive (collimage9);
			collpic10.SetActive (collimage10);










		}
	}

}
[Serializable]
class SaveData
{
	public int Karma;
	//player Position
	public float playerPosx;
	public float playerPosy;
	public float playerPosz;
	public float playerRotx;
	public float playerRoty;
	public float playerRotz;
	public float playerRotw;
	// the scene
	public int roomIndex;
	//items in inventory
	public string Item0;
	public string Item1;
	public string Item2;
	public string Item3;
	// dungeon room savestates
	public bool pickupLock;
	public bool doorStatus;
	public bool guardTalked;
	public bool cellTalked;
	// corridor room savestae
	public bool storageTalk;
	// MasterVolume savestate
	public float MasterVolume;
	public string noteString;
	// collectable items
	public bool collimage1;
	public bool collimage2;
	public bool collimage3;
	public bool collimage4;
	public bool collimage5;
	public bool collimage6;
	public bool collimage7;
	public bool collimage8;
	public bool collimage9;
	public bool collimage10;



}