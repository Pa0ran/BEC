using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {


	private string name;
	private Inventory inventory;
	bool done = true;
	public Item omena;
	public Item peruna;
	public Item lockpick;
	public PlayerData () {
	
		this.name = "Dummy";
		this.inventory = new Inventory ();

	}
	void Start() {


		//inventory = FindObjectOfType<Inventory> ();
		//omena = new Item("Omena","syötävä",apple);
		//Testing the AddItem- functionality

		//Debug.Log (inventory.GetSize ());
		//inventory.AddItem(omena);
		//Debug.Log (inventory.GetSize ());
		//Debug.Log(inventory.ListItems());
		//Debug.Log (omena.GetName() + ", " + omena.GetDesc());
	}
	void Update ()
	{
		if (Time.time > 0.01f && done) {
			inventory = FindObjectOfType<Inventory> ();
			done = false;
		}


	}

	public string GetName() {
		return name;

	}

}
