using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public Quaternion doorAngle;
	public Item key;
	public Inventory inv;
	DungeonSaver DS;

	public DoorScript (Item key) {

	}

	public DoorScript() {
	}

	// Use this for initialization
	void Awake () {
		DS = FindObjectOfType<DungeonSaver> ();
		this.inv = GameObject.FindObjectOfType<Inventory>();
		this.doorAngle = GetComponent<Transform> ().rotation;

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log (coll.gameObject.tag);
		// if the object is tagged with Door, it is a door
		if (coll.gameObject.CompareTag ("Player") && gameObject.CompareTag ("Door"))  {
			if (inv.ContainsItem (key) || key == null) {
				//Door needs an anchor point in the top corner for the code below to work as planned
			//	Quaternion rot = transform.rotation;
			//	rot = Quaternion.Euler (0, 0, 90);
			//	transform.rotation = rot;
				DS.doorStatus =true;
				gameObject.SetActive (false);
				Debug.Log ("You opened the door");
			}  else {
				Debug.Log ("You need the key");
			}
		}
	}
}

