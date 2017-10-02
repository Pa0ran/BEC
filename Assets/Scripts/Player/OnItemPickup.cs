using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemPickup : MonoBehaviour {
	Inventory inv;
	void Start(){
		inv = FindObjectOfType<Inventory> ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log (coll.gameObject.tag);
		// if the object is tagged with PickUp it will be pick uppable
		if (coll.gameObject.CompareTag ("PickUp"))  {
			inv.AddItem (coll.gameObject.GetComponent <PickUpItem>().item);
			Destroy (coll.gameObject);

		}
	}
}
