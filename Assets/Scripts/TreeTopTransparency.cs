using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopTransparency : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.CompareTag ("Player"))
		{
			Color spr = GetComponent <SpriteRenderer>().color;
			spr.a = 0.3f;
			gameObject.GetComponent <SpriteRenderer> ().color = spr;
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if(coll.gameObject.CompareTag ("Player"))
		{
			Color spr = GetComponent <SpriteRenderer>().color;
			spr.a = 1f;
			gameObject.GetComponent <SpriteRenderer> ().color = spr;
		}
	}

}
