using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	private string name;
	//private List<Item> inventory;

	// Use this for initialization
	void Start () {
		this.name = "Dummy";
		//this.inventory = new List<Item> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetName() {
		return name;

	}
	public string GetInventory() {
		return "inv";
	}
}
