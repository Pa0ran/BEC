using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public bool mobile = false;
	public float maxspeed = 5f;
	public float rotSpeed = 180f;
	JoyStick moveJoystick;
	GameController GC;
	NPCController npc;
	PlayerData player;
	Inventory inventory;
	DialogueList dia;
	OnItemPickup OIP;
	public GameObject otherObject;
	Text doThingText;
	Button doThingButton;
	GameObject tempObject;
	Canvas doThingCanvas;
	Canvas finishCanvas;
	Animator anim;
	string holdString;
	public Dictionary<GameObject, Item> LinkItem;
	// Use this for initialization
	void Start () {
		GC = FindObjectOfType<GameController> ();
		npc = FindObjectOfType<NPCController> ();
		player = FindObjectOfType<PlayerData> ();
		inventory = FindObjectOfType<Inventory> ();
		dia = FindObjectOfType<DialogueList> ();
		moveJoystick = FindObjectOfType<JoyStick> ();
		OIP = FindObjectOfType<OnItemPickup> ();
		doThingText = GameObject.Find ("DoThingText").GetComponent <Text> ();
		doThingButton = GameObject.Find ("DoThingButton").GetComponent <Button> ();	
		doThingCanvas= GameObject.Find ("DoThingsCanvas").GetComponent <Canvas> ();
		finishCanvas = GameObject.Find ("FinishCanvas").GetComponent<Canvas> ();
		anim = GetComponentInChildren <Animator>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (anim.GetBool ("Moving"));

			
		if (Input.GetAxis ("Vertical") > 0.4 || Input.GetAxis ("Vertical") <-0.4) {
				anim.SetBool ("Moving", true);

			} else {
				anim.SetBool ("Moving", false);
			}


			if(moveJoystick.InputDirection.magnitude > 0){
				anim.SetBool ("Moving", true);
			}
		else if(mobile)
			{
				anim.SetBool ("Moving", false);
			}


		Move (true);

	}
	// if the dialogue collider hits the npcs dialogue trigger create options for the player.
	void OnTriggerEnter2D(Collider2D other)
	{



		if (other.CompareTag ("NPC")){
			tempObject = other.gameObject;
			if (other.gameObject.GetComponent<DialogueTrigger> ().doneConversation == false) {
				doThingCanvas.enabled = true;
				doThingButton.enabled = true;
				doThingText.text = "Talk to " + tempObject.name;
				doThingButton.onClick.RemoveAllListeners ();
				doThingButton.onClick.AddListener (() => PressDoThing("NPC"));
				holdString = tempObject.GetComponent <NPCMovement>().MoveMode;
				tempObject.GetComponent <NPCMovement>().MoveMode = "None";
			}


		}
		if (other.CompareTag ("Interactable")) {
			tempObject = other.gameObject;
			if (other.gameObject.GetComponent <InteractTrigger> ().doneConversation == false) {
				doThingCanvas.enabled = true;
				doThingButton.enabled = true;
				doThingText.text = "Search " + other.gameObject.name;
				doThingButton.onClick.RemoveAllListeners ();
				doThingButton.onClick.AddListener (() => PressDoThing("Interactable"));



			}
		}
		if (other.CompareTag ("Modern")) {
			if(other.gameObject.name == "Foil"){
				Destroy (other.gameObject);
				GC.collpic2.SetActive (true);
				GC.collimage2 = true;
			}
			if(other.gameObject.name == "FidgetSpinner"){
				Destroy (other.gameObject);
				GC.collpic1.SetActive (true);
				GC.collimage1 = true;
			}
			if(other.gameObject.name == "KeyChain"){
				Destroy (other.gameObject);
				GC.collpic3.SetActive (true);
				GC.collimage3 = true;
			}
			if(other.gameObject.name == "Orgasmatron"){
				Destroy (other.gameObject);
				GC.collpic4.SetActive (true);
				GC.collimage4 = true;
			}
			if(other.gameObject.name == "Phone"){
				Destroy (other.gameObject);
				GC.collpic5.SetActive (true);
				GC.collimage5 = true;
			}
			if(other.gameObject.name == "Remote"){
				Destroy (other.gameObject);
				GC.collpic6.SetActive (true);
				GC.collimage6 = true;
			}
			if(other.gameObject.name == "SelfieStick"){
				Destroy (other.gameObject);
				GC.collpic7.SetActive (true);
				GC.collimage7 = true;
			}
			if(other.gameObject.name == "Battery"){
				Destroy (other.gameObject);
				GC.collpic8.SetActive (true);
				GC.collimage8 = true;
			}
			if(other.gameObject.name == "Thermometer"){
				Destroy (other.gameObject);
				GC.collpic9.SetActive (true);
				GC.collimage9 = true;
			}
			if(other.gameObject.name == "Watch"){
				Destroy (other.gameObject);
				GC.collpic10.SetActive (true);
				GC.collimage10 = true;
			}
			if (other.gameObject == GameObject.Find ("Portapotty")) {
				if (GC.CollectAll) {
					finishCanvas.enabled = true;
				}
			}
		}



	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.CompareTag ("Interactable"))
		{
			doThingCanvas.enabled = false;
			doThingButton.enabled = false;
		}
		if (other.CompareTag ("NPC")) 
		{
			tempObject.GetComponent <NPCMovement>().MoveMode = holdString;
			doThingCanvas.enabled = false;
			doThingButton.enabled = false;
		}
	}



	void PressDoThing(string what){
		if(what == "Interactable")
		{
			GC.EnableInteractCanvas (true);
			Time.timeScale = 0;
			tempObject.GetComponent<InteractTrigger> ().TriggerInteract ();
			if (tempObject.GetComponent <PickUpItem> () != null) {
				OIP.tempItem = tempObject.gameObject.GetComponent <PickUpItem> ().item;
			}
		}
		if(what == "NPC")
		{

			GC.EnableDialogueCanvas (true);
			tempObject.GetComponent <DialogueTrigger> ().TriggerDialogue ();
			Time.timeScale = 0;
		}
		doThingButton.onClick.RemoveAllListeners ();
		doThingButton.enabled = false;
		doThingCanvas.enabled = false;
	}
	void Move(bool b)
	{
		// Returns a FLOAT from -1.0 to 1.0
		// ROTATE player
		// Grab rotatiton quaternion
		Quaternion rot = transform.rotation;
		Quaternion rotJoy = transform.rotation;
		// Grab Euler z angle
		float z = rot.eulerAngles.z;
		//change the z angle based on input
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		// Recreate quaternion
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;
		// feed quaternion into our rotation
		if (mobile == true) {
			if (moveJoystick.InputDirection.magnitude == 0) {
				transform.rotation = rot;
			} else {
				float charRotation = Mathf.Atan2 (moveJoystick.InputDirection.x, moveJoystick.InputDirection.y) * Mathf.Rad2Deg;
				rotJoy = Quaternion.Euler (0, 0, -charRotation);

				transform.rotation = rotJoy;
			}
		}


		if (b) {


			// MOVE the player
			Vector3 pos = transform.position;
			//first to vertical simpler
			Vector3 velocity = new Vector3 (0, Input.GetAxis ("Vertical") * maxspeed * Time.deltaTime, 0);
			pos += rot * velocity;
			transform.position = pos;
			if (mobile == true) {
				Vector3 velocity2 = new Vector3 (0, moveJoystick.InputDirection.magnitude * maxspeed * Time.deltaTime, 0);
				pos += rot * velocity2;
				transform.position = pos;
			}


		}

	}
}

