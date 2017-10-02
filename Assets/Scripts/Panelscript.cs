using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelscript : MonoBehaviour {
	public Image myPanel;
	// Use this for initialization
	void Start () {
		myPanel.GetComponent <CanvasRenderer>().SetAlpha (255f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
