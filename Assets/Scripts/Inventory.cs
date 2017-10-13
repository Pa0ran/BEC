﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public GameObject Sound;
	public static Inventory inv;
	public Image[] itemImages = new Image[itemSlots];
	public Item[] items = new Item[itemSlots];
	public const int itemSlots = 4;
	GameController GC;
	PlaySound PS;
	void Start()
	{
		GC = FindObjectOfType<GameController> ();
		PS = gameObject.GetComponent <PlaySound> ();
	}

	public void AddItem(Item itemToAdd)
	{
		Debug.Log (itemToAdd);
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i] == null && !ContainsItem(itemToAdd))
			{
				items[i] = itemToAdd;
				itemImages[i].sprite = itemToAdd.sprite;
				itemImages[i].enabled = true;
				PS.PlayASound ();
				return;
			}
		}
	}
	public void RemoveItem (Item itemToRemove)
	{
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i] == itemToRemove)
			{
				items[i] = null;
				itemImages[i].sprite = null;
				itemImages[i].enabled = false;
				return;
			}
		}
	}

	public Item GetItemFromSlot(int slot) {
		return items [slot];
	}

	public Image GetItemImageFromSlot(int slot) {
		return itemImages [slot];
	}

	public bool ContainsItem(Item i) {
		for (int index = 0; index < 4; index++) {
			if (items [index] == i) {
				return true;
			}
		}
		return false;
	}

	/*public int GetSize() {
		int sum = 0;
		for (int i = 0; i < 4; i++) {
			if (items [i] != null) {
				sum++;
				//Debug.Log (i);
			}
		}
		return sum;
	}

	public string ListItems() {
		string temp = "Items: ";

		for (int i = 0; i < itemSlots; i++) {
			if (items [i] != null) {
				temp += items [i].GetName() + "\n";
			}
		}
		return temp;
	} */
}

