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
	public GameObject otherObject;
	public Dictionary<GameObject, Item> LinkItem;
	// Use this for initialization
	void Start () {
		GC = FindObjectOfType<GameController> ();
		npc = FindObjectOfType<NPCController> ();
		player = FindObjectOfType<PlayerData> ();
		inventory = FindObjectOfType<Inventory> ();
		dia = FindObjectOfType<DialogueList> ();
		moveJoystick = FindObjectOfType<JoyStick> ();

	}
	
	// Update is called once per frame
	void Update () {
		Move (true);

	}
	// if the dialogue collider hits the npcs dialogue trigger create options for the player.
	void OnTriggerEnter2D(Collider2D other)
	{
		
	
		if (other.CompareTag ("NPC")){
			GC.EnableDialogueCanvas (true);
			other.gameObject.GetComponent <DialogueTrigger>().TriggerDialogue ();	
				

			}
		/*if (dia.Dialogue.ContainsKey (other.name)) 
				{

				Debug.Log (other.gameObject.name);
				otherObject = other.gameObject;
				npc.GiveDialogue (other.gameObject.name);
				}*/
	}
	void OnTriggerExit2D(Collider2D other)
	{


		if (other.CompareTag ("NPC"))
		{
			GC.EnableDialogueCanvas (false);


		}
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

