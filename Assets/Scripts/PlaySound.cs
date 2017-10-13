using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioClip SoundToPlay;
	private AudioSource AS;
	// Use this for initialization
	void Start () {
		AS = GetComponent <AudioSource> ();

	}

	public void PlayASound()
	{
		AS.PlayOneShot (SoundToPlay,1f);
	}

}
