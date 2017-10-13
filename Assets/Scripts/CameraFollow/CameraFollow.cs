using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.4f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	Camera cam;
	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
		cam = GetComponent <Camera> ();
	}
	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = cam.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

	}


}


	
