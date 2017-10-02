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
	public Text choice1;
	public Text choice2;
	public Text choice3;
	public Canvas DiaCanvas;
	public Dictionary<string,string[]> ListOptions;
	private Queue<string> sentences;
	private Dialogue tempDia;
	void Start () {
		ListOptions = new Dictionary<string,string[]> ();
		sentences = new Queue<string> ();
		DiaCanvas = GameObject.Find ("CanvasDialogue").GetComponent <Canvas> ();
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

		DisplayNextSentence ();
	}
	
	public void DisplayNextSentence()
	{

		if(sentences.Count == 0)
		{
			EnableButtons ();
			Debug.Log ("End of conversations");
			//EndDialogue ();
			return;
		}
		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
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
	public void NextDialogue(int option)
	{
		sentences.Clear ();
		if(option == 0)
		{
			foreach(string sentence in tempDia.sentences0)
			{
				sentences.Enqueue (sentence);
			}
			DisplayNextSentence ();
		}
		if(option == 1)
		{
			foreach(string sentence in tempDia.sentences1)
			{
				sentences.Enqueue (sentence);
			}
			DisplayNextSentence ();
		}
		if(option == 2)
		{
			foreach(string sentence in tempDia.sentences2)
			{
				sentences.Enqueue (sentence);
			}
			DisplayNextSentence ();
		}
	}

	void EnableButtons(){
		continueButton.gameObject.SetActive (false);
		option1.gameObject.SetActive (true);
		option2.gameObject.SetActive (true);
		option3.gameObject.SetActive (true);

	}
	void EndDialogue()
	{
		
		Debug.Log ("End of conversations");
		DiaCanvas.enabled = false;
	}
	/*void removeListeners(){
		option1.onClick.RemoveAllListeners ();
		option2.onClick.RemoveAllListeners ();
		option3.onClick.RemoveAllListeners ();
	}*/
}
