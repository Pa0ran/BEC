using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueList : MonoBehaviour {

	public Dictionary <string,List<string>> Dialogue;
	public List <string> Guard;
	public List <string> Guard0;
	public List <string> Guard00;
	public List <string> Guard1;
	public List <string> Guard2;
	public List <string> Cellmate;
	public List <string> Cellmate0;
	public List <string> Cellmate00;
	public List <string> Cellmate1;
	public List <string> Cellmate2;	
	public List <string> Cellmate3;
	// Use this for initialization
	void Start () 
	{
		Dialogue = new Dictionary<string, List<string>>();
		Guard = new List<string> ();
		Guard0 = new List<string> ();
		Guard00 = new List<string> ();
		Guard1 = new List<string> ();
		Guard2 = new List<string> ();
		Cellmate0 = new List<string>();
		Cellmate00 = new List<string>();
		Cellmate = new List<string>();
		Cellmate1 = new List<string>();
		Cellmate2 = new List<string>();
		Cellmate3 = new List<string>();
		//Cellmate #1, Cabbage-Stealer
		Cellmate.Add ("Do you want to talk to your Cellmate?");
		Cellmate.Add ("Yes");
		Cellmate.Add ("No");
		Cellmate0.Add ("C 1.1 Johtaa 2.1");
		Cellmate0.Add ("C 1.2");
		Cellmate0.Add ("C 1.3");
		Cellmate0.Add ("C 1.4");
		Cellmate00.Add ("C 2.1");
		Cellmate00.Add ("C 2.2");
		Cellmate00.Add ("C 2.3");
		Cellmate00.Add ("C 2.4");
		Cellmate1.Add ("C 3.1");
		Cellmate1.Add ("C 3.2");
		Cellmate1.Add ("C 3.3");
		Cellmate1.Add ("C 3.4");
		Cellmate2.Add ("C 4.1");
		Cellmate2.Add ("C 4.2");
		Cellmate2.Add ("C 4.3");
		Cellmate2.Add ("C 4.4");
		Cellmate3.Add ("C 5.1");
		Cellmate3.Add ("C 5.2");
		Cellmate3.Add ("C 5.3");
		Cellmate3.Add ("C 5.4");

		Dialogue.Add ("Cellmate", Cellmate);
		Dialogue.Add ("Cellmate0",Cellmate0);
		Dialogue.Add ("Cellmate00", Cellmate00);
		Dialogue.Add ("Cellmate1", Cellmate1);
		Dialogue.Add ("Cellmate2", Cellmate2);
		Dialogue.Add ("Cellmate3", Cellmate3);

		//Guard #1
		Guard.Add ("G 1.1");
		Guard.Add ("G 1.2 Johtaa 2.1");
		Guard.Add ("G 1.3 Johtaa 4.1");
		Guard.Add ("G 1.4 Johtaa 5.1");
		Guard0.Add ("G 2.1");
		Guard0.Add ("G 2.2 Johtaa 3.1");
		Guard0.Add ("G 2.3");
		Guard0.Add ("G 2.4");
		Guard00.Add ("G 3.1");
		Guard00.Add ("G 3.2");
		Guard00.Add ("G 3.3");
		Guard00.Add ("G 3.4");
		Guard1.Add ("G 4.1");
		Guard1.Add ("G 4.2");
		Guard1.Add ("G 4.3");
		Guard1.Add ("G 4.4");
		Guard2.Add ("G 5.1");
		Guard2.Add ("G 5.2");
		Guard2.Add ("G 5.3");
		Guard2.Add ("G 5.4");

		Dialogue.Add ("Guard", Guard);
		Dialogue.Add ("Guard0", Guard0);
		Dialogue.Add ("Guard00", Guard00);
		Dialogue.Add ("Guard1", Guard1);
		Dialogue.Add ("Guard2", Guard2);
		//Diipadaaps

	}
}