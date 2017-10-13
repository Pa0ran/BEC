using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {


	// Use this for initialization


	//Dictionary for storing object + possible item to interact with
	public Item objectItem;
	private Inventory inv;
	private bool pickedUp;

	void Start () {
		this.inv = GameObject.FindObjectOfType<Inventory> ();
		this.pickedUp = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log (coll.gameObject.tag);
		// if the object is tagged with Interactable, it is interactable
		if (coll.gameObject.CompareTag ("Player"))  {
			if (gameObject.CompareTag ("Interactable") && !pickedUp) {
				pickedUp = true;
				inv.AddItem (objectItem);
			}
		}
	}
		
}
