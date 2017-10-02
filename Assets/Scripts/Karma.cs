using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Karma : MonoBehaviour
{
	public int kc;  //Current amount of Karma (KarmaCount)

	public Karma ()
	{
		//	this.kc = kc;
	}

	public int GetKarma () {
		return kc;
	}

/*		public int DialogueKarma () {
		if (choice0) { 				//Choice0 has no impact on Karma
			kc = kc;
			Debug.Log ("C0" + kc);
		} else if (choice1) {		//Choice1 has little negative impact on Karma
			kc = kc - 1;
			Debug.Log ("C1" + kc);
		} else if (choice2) {		//Choice2 has little positive impact on Karma
			kc = kc + 1;
			Debug.Log ("C2" + kc);
		} else if (choice3) {		//Choice3 has major negative impact on Karma
			kc = kc - 2;
			Debug.Log ("C3" + kc);
		} else if (choice4) {		//Choice4 has major positive impact on Karma
			kc = kc + 2;
			Debug.Log ("C4" + kc);
		}
		return kc;
	}*/
	int choiceValue; // KarmaValue of Choice
	int kMultiplier; //KarmaMultiplier
	int akValue; //ActionKarmaValue

	public int DialogueKarma (){
		if (choiceValue == 0) {
			kc = kc;
			Debug.Log ("C0" + kc);
		} else if (choiceValue == 1) {		//Choice1 has little negative impact on Karma
			kc = kc - 1*kMultiplier;
			Debug.Log ("C1" + kc);
		} else if (choiceValue == 2) {		//Choice2 has little positive impact on Karma
			kc = kc + 1*kMultiplier;
			Debug.Log ("C2" + kc);
		} else if (choiceValue == 3) {		//Choice3 has major negative impact on Karma
			kc = kc - 2*kMultiplier;
			Debug.Log ("C3" + kc);
		} else if (choiceValue == 4) {		//Choice4 has major positive impact on Karma
			kc = kc + 2*kMultiplier;
			Debug.Log ("C4" + kc);
		}
		return kc;
	}

	public int ActionKarma (){  //This will be used, if needed, to impact Karma with player's actions.
		//Somethingsomething
		if (akValue > 0) {
			kc = kc + akValue;
		} else if (akValue < 0) {
			kc = kc - akValue * kMultiplier;
		} else if (akValue == 0) {
			kc = kc;
		}
		return kc;
	}

	public void OverallKarma (){
		if (kc < 0) {
			Debug.Log (kc + "Karma very low");
		} else if (kc > 100) {
			Debug.Log (kc + "Karma very hight");
		}
	}
}