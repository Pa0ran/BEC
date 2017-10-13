using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractManager : MonoBehaviour {

	// Use this for initialization
	public Text objectText;
	public Text intDialogueText;
	public Button intOption1;
	public Button intOption2;
//	public Button option3;
	public Button intContinueButton;
	public Text continueText;
	public Text intChoice1;
	public Text intChoice2;
//	public Text choice3;
	public Canvas intCanvas;
	public Dictionary<string,string[]> ListOptions;
	private Queue<string> sentences;
	private ObjectDialogue tempDia;
	private Inventory inv;
	public InteractTrigger IT;
	public OnItemPickup OIP;
	int theOption;
	public bool endIt;
	void Start () {
		ListOptions = new Dictionary<string,string[]> ();
		sentences = new Queue<string> ();
		intCanvas = GameObject.Find ("InteractDialogue").GetComponent <Canvas> ();
		this.inv = GameObject.FindObjectOfType<Inventory> ();
		OIP = FindObjectOfType<OnItemPickup> ();
	}
	public void StartDialogue(ObjectDialogue dialogue)
	{   OIP.done = false;
		//intChoice1.text = dialogue.options [0];
		//intChoice2.text = dialogue.options [1];
//		choice3.text = dialogue.options [2];
		tempDia = dialogue;
		sentences.Clear ();
		objectText.text = dialogue.name;
		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue (sentence);
		}

		string firstSentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (firstSentence));
		//if (sentences.Count == 0){
			//EnableButtons ();
		//}
	}
	void Update()
	{
		/*if(endIt == true){
			if(sentences.Count == 0){
				continueText.text = "Leave";
				intContinueButton.onClick.AddListener (() => (DisplayLastSentence ()));
				endIt = false;
			}
		}*/

	}
	public void DisplayNextSentence()
	{
		if(IT.item != null){
			inv.AddItem (IT.item);
		}
		if(sentences.Count ==1){
			continueText.text = "Leave";
			intContinueButton.onClick.AddListener (() => (DisplayLastSentence ()));
		}
		if(sentences.Count == 0)
		{
			


			endIt = true;
			DisableButtons ();
			Debug.Log ("End of Interaction");
			return;
		}
	

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}
	IEnumerator TypeSentence (string sentence)
	{
		intDialogueText.text = "";
		foreach (char letter in sentence.ToCharArray ()) 
		{
			intDialogueText.text += letter;
			yield return new WaitForSecondsRealtime(0.02f);
		}
	}
	public void DisplayLastSentence()
	{
		continueText.text = "Continue";
		EndDialogue ();	
		intContinueButton.onClick.RemoveAllListeners();
		DisableButtons ();
		endIt = false;

	}
	/*public void NextDialogue(int option)
	{
		theOption = option;
		IT.optionChoice = option;
		sentences.Clear ();
		if(option == 0)
		{
			foreach(string sentence in tempDia.sentences0)
			{
				sentences.Enqueue (sentence);
			}
		
			DisableButtons ();
			endIt = true;
			
			DisplayNextSentence ();
		}
		if(option == 1)
		{
			foreach(string sentence in tempDia.sentences1)
			{
				sentences.Enqueue (sentence);
			}
			DisableButtons ();
			endIt = true;
		
			DisplayNextSentence ();
		}
		/*
		if(option == 2)
		{
			foreach(string sentence in tempDia.sentences2)
			{
				sentences.Enqueue (sentence);
			}
			DisableButtons ();
			if(sentences.Count == 1){
				endIt = true;
			}
			DisplayNextSentence ();
		}

	}*/

	void EnableButtons(){
		intContinueButton.gameObject.SetActive (false);
		intOption1.gameObject.SetActive (true);
		intOption2.gameObject.SetActive (true);
		//option3.gameObject.SetActive (true);

	}
	void DisableButtons()
	{
		intContinueButton.gameObject.SetActive (true);
		//intOption1.gameObject.SetActive (false);
		intOption2.gameObject.SetActive (false);
		//option3.gameObject.SetActive (false);
	}
	void EndDialogue()
	{
		if (theOption == 0) 
		{
			IT.doneConversation = true;
		}

		IT = null;
		Debug.Log ("End of all things interact");
		intCanvas.enabled = false;
		Time.timeScale = 1;
	}
	/*void removeListeners(){
		option1.onClick.RemoveAllListeners ();
		option2.onClick.RemoveAllListeners ();
		option3.onClick.RemoveAllListeners ();
	}*/
}
