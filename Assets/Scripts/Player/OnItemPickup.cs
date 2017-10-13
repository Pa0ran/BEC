using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemPickup : MonoBehaviour {
	Inventory inv;
	InteractManager IM;
	public Item tempItem;
	public bool done;

	void Start(){
		inv = FindObjectOfType<Inventory> ();
		IM = FindObjectOfType<InteractManager> ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// if the object is tagged with PickUp it will be pick uppable
		if (coll.gameObject.CompareTag ("PickUp"))  {
			inv.AddItem (coll.gameObject.GetComponent <PickUpItem>().item);
			coll.gameObject.SetActive (false);

		}
	}
	void Update(){
		
	}

}
