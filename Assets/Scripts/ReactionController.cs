using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionController : MonoBehaviour {

	GameController GC;
	void Start()
	{
		GC = FindObjectOfType<GameController> ();
	}
	public void AddKarma(int karma)
	{
		GC.karma += karma;
	}
}
