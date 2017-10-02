using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
	public Sprite sprite;
	public string description;

	public string GetDesc() {
		return description;
	}
	public Sprite GetSprite() {
		return sprite;
	}

}
	

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	private string itemName;
	private string itemDesc;
	public Sprite sprite;

	public Item(string itemName, string itemDesc, Sprite sprite) {
		this.itemName = itemName;
		this.itemDesc = itemDesc;
		this.sprite = sprite;
	}

	public string GetName() {
		return itemName;
	}

	public string GetDesc() {
		return itemDesc;
	}

	public Sprite GetSprite() {
		return sprite;
	}

}*/
