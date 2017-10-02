using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectItem : MonoBehaviour {

	Button inspectItem0;
	Button inspectItem1;
	Button inspectItem2;
	Button inspectItem3;
	Button nextItem;
	Button prevItem;
	Button exitMenu;
	public Inventory inv;
	public Text desc;
	Text name;
	//public Sprite asdasd;
	public Image itemImage;
	public Canvas canvas;
	int currentInspect;
	int nothingFound;

	// Use this for initialization
	void Start () {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		inspectItem0 = GameObject.Find ("InspectItemButton0").GetComponent<Button> ();
		inspectItem1 = GameObject.Find ("InspectItemButton1").GetComponent<Button> ();
		inspectItem2 = GameObject.Find ("InspectItemButton2").GetComponent<Button> ();
		inspectItem3 = GameObject.Find ("InspectItemButton3").GetComponent<Button> ();
		nextItem= GameObject.Find ("ButtonNextItem").GetComponent<Button> ();
		prevItem= GameObject.Find ("ButtonLastItem").GetComponent<Button> ();
		exitMenu = GameObject.Find ("ButtonInspectExit").GetComponent<Button> ();
		desc = GameObject.Find ("DescText").GetComponent<Text> ();
		name = GameObject.Find ("TextItemName").GetComponent<Text> ();
		itemImage = GameObject.Find ("DescItemImage").GetComponent<Image> ();
		canvas = GameObject.Find ("InspectCanvas").GetComponent <Canvas> ();
		exitMenu.onClick.AddListener (() => ExitInspect());






	}

	// Update is called once per frame
	void Update () {
		AddListeners ();



	}
	public void ExitInspect()
	{
		canvas.GetComponent <Canvas> ().enabled = false;
		Time.timeScale = 1;
	}
	public void Inspect(int slot) {
		canvas.GetComponent <Canvas> ().enabled = true;	
		Time.timeScale = 0;
		if (inv.GetItemFromSlot(slot) != null) 
		{
			itemImage.sprite = inv.GetItemImageFromSlot (slot).sprite;
			desc.text = inv.GetItemFromSlot(slot).GetDesc();
			name.text = inv.GetItemFromSlot (slot).name;
			currentInspect = slot;
			nextItem.onClick.RemoveAllListeners ();
			prevItem.onClick.RemoveAllListeners ();
			nextItem.onClick.AddListener (() => ItemNext(currentInspect));
			prevItem.onClick.AddListener (() => ItemPrev(currentInspect));

		}

	}
	void ItemNext(int slot)
	{
		
		if(slot ==3){
			if(inv.GetItemFromSlot (0)!=null)
			{
				Inspect (0);
			}

		}
		else if (inv.GetItemFromSlot (slot+1) != null) {
			Inspect (slot+1);

		} 

		else{
			

			do {
				
				if(slot == 3){
					slot =0;
				}
			
				else if (inv.GetItemFromSlot (3) == null) {
					slot = 0;
					Debug.Log ("Zero");
				} else {
					Debug.Log ("slot++");
					Debug.Log (slot);
					slot++;
				}
				
			} while (inv.GetItemFromSlot (slot) == null);
			Inspect (slot);


		}
	

	
	
		
	}
	void ItemPrev(int slot)
	{
		
		if(slot ==0 && inv.GetItemFromSlot (3)!=null)
			{
				Inspect (3);
			}
		else if (slot != 0) 
		{
			if (inv.GetItemFromSlot (slot - 1) != null) 
			{
				Inspect (slot - 1);
			}

		} 

		else{


			do {

				if(slot == 0){
					slot =3;
				}

				else if (inv.GetItemFromSlot (0) == null) {
					slot = 3;
					Debug.Log ("tree");
				} else {
					Debug.Log ("slot++");
					Debug.Log (slot);
					slot--;
				}

			} while (inv.GetItemFromSlot (slot) == null);
			Inspect (slot);


		}



	}
	void AddListeners()
	{
		if (inv.GetItemFromSlot (0) != null) {

			inspectItem0.onClick.AddListener (() => Inspect (0));
		}
		else 
		{
			inspectItem0.onClick.RemoveAllListeners ();
		}
		if (inv.GetItemFromSlot (1) != null) 
		{

			inspectItem1.onClick.AddListener (() => Inspect (1));
		}
		else 
		{
			inspectItem1.onClick.RemoveAllListeners ();
		}
		if (inv.GetItemFromSlot (2) != null) 
		{

			inspectItem2.onClick.AddListener (() => Inspect (2));
		}
		else 
		{
			inspectItem2.onClick.RemoveAllListeners ();
		}
		if (inv.GetItemFromSlot (3) != null) 
		{

			inspectItem3.onClick.AddListener (() => Inspect (3));
		}
		else 
		{
			inspectItem3.onClick.RemoveAllListeners ();
		}


	}


}
