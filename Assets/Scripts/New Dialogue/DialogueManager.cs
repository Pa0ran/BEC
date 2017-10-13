using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	// Use this for initialization
	public Text nameText;
	public Text dialogueText;
	public Button option1;
	public Button option2;
	public Button option3;
	public Button continueButton;
	public Text TextContinue;
	public Text choice1;
	public Text choice2;
	public Text choice3;
	public Canvas DiaCanvas;
	public Dictionary<string,string[]> ListOptions;
	private Queue<string> sentences;
	private Dialogue tempDia;
	public DialogueTrigger DT;
	public bool endIt;
	void Start () {
		ListOptions = new Dictionary<string,string[]> ();
		sentences = new Queue<string> ();
		DiaCanvas = GameObject.Find ("CanvasDialogue").GetComponent <Canvas> ();
	}
	void Update()
	{
		if(endIt == true){
			if(sentences.Count == 0){
				TextContinue.text = "Leave";
				continueButton.onClick.AddListener (() => (DisplayLastSentence ()));
				endIt = false;
			}
		}

	}
	public void StartDialogue(Dialogue dialogue)
	{
		choice1.text = dialogue.options [0];
		choice2.text = dialogue.options [1];
		choice3.text = dialogue.options [2];
		tempDia = dialogue;
		sentences.Clear ();
		nameText.text = dialogue.name;
		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue (sentence);
		}

		string firstSentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (firstSentence));
		if (sentences.Count == 0){
			EnableButtons ();
		}
	}
	
	public void DisplayNextSentence()
	{

		if(sentences.Count == 0)
		{

			EnableButtons ();
			Debug.Log ("End of conversations");
			return;
		}
		string firstSentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (firstSentence));
	

	}
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray ()) 
		{
			dialogueText.text += letter;
			yield return new WaitForSecondsRealtime(0.02f);
		}
	}

	public void DisplayLastSentence()
	{
		TextContinue.text = "Continue";
		EndDialogue ();	
		continueButton.onClick.RemoveAllListeners();
		DisableButtons ();
		endIt = false;

	}
	public void NextDialogue(int option)
	{
		DT.doneConversation = true;
		DT.optionChoice = option;
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
			endIt = true;

			DisableButtons ();
			DisplayNextSentence ();
		}
		if(option == 2)
		{
			foreach(string sentence in tempDia.sentences2)
			{
				sentences.Enqueue (sentence);
			}
			endIt = true;

			DisableButtons ();
			DisplayNextSentence ();
		}
	}

	void EnableButtons(){
		continueButton.gameObject.SetActive (false);
		option1.gameObject.SetActive (true);
		option2.gameObject.SetActive (true);
		option3.gameObject.SetActive (true);

	}
	void DisableButtons()
	{
		continueButton.gameObject.SetActive (true);
		option1.gameObject.SetActive (false);
		option2.gameObject.SetActive (false);
		option3.gameObject.SetActive (false);
	}
	void EndDialogue()
	{
		
		Debug.Log ("End of all things dia");
		DiaCanvas.enabled = false;
		Time.timeScale = 1;
	}
	/*void removeListeners(){
		option1.onClick.RemoveAllListeners ();
		option2.onClick.RemoveAllListeners ();
		option3.onClick.RemoveAllListeners ();
	}*/
}
