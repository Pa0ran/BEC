using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

	public float maxSpeed = 1;
	public string MoveMode = "Vertical";
	string tempMode;
	float randTime;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (MoveMode == "Vertical") 
		{
			Vector3 pos = transform.position;
			Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
			pos += velocity;
			transform.position = pos;
			tempMode = "Vertical";
		}
		if (MoveMode == "Horizontal") 
		{
			Vector3 pos = transform.position;
			Vector3 velocity = new Vector3 (maxSpeed * Time.deltaTime,0, 0);
			pos += velocity;
			transform.position = pos;
			tempMode = "Horizontal";
		}
		while(MoveMode == "Wait"){
			StartCoroutine (WaitForRandomSeconds());
			MoveMode = "";
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag ("Wall"))
		{
			MoveMode = "Wait";
		}
		else
		{
			StartCoroutine (WaitForRandomSeconds());
		}
		Debug.Log (other);
	}
	IEnumerator WaitForRandomSeconds()
	{
		randTime = Random.Range (0f,5f);
		yield return new WaitForSeconds (randTime);
		MoveMode =tempMode;
		maxSpeed = -maxSpeed;
	}
}
