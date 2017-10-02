using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistent : MonoBehaviour {

	public static persistent pers;
	// Use this for initialization
	void Awake () {
		if (pers == null) 
		{
			DontDestroyOnLoad (gameObject);
			pers = this;
		}
		else if(pers !=this)
		{
			Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
