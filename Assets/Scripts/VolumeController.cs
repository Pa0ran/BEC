using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

	public Canvas OptionsCanvas;
	public Slider MasterVolume;
	float displayVolume;
	public bool Load = false;
	private PlaySound PS;
	private float SetVolume;
	Text MasterVolumeText;
	// Use this for initialization
	void Start () {
		
		MasterVolume = GameObject.Find ("MasterVolumeSlider").GetComponent <Slider> ();
		OptionsCanvas = GameObject.Find ("OptionsMenu").GetComponent <Canvas> ();
		PS = GameObject.Find ("MasterVolumeSlider").GetComponent <PlaySound> ();
		MasterVolumeText = GameObject.Find ("MasterVolumeText").GetComponent <Text> ();
		MasterVolume.onValueChanged.AddListener (delegate {
			PS.PlayASound ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		if(OptionsCanvas.isActiveAndEnabled){
			SetVolume = MasterVolume.value;
			displayVolume = SetVolume * 100;
			MasterVolumeText.text = "Master Volume: " + displayVolume.ToString ("f0");
			AdjustVolume (SetVolume);
		}
		else if(Load){
			SetVolume = MasterVolume.value;
			AdjustVolume (SetVolume);
			displayVolume = SetVolume * 100;
			MasterVolumeText.text = "Master Volume: " + displayVolume.ToString ("f0");
			Load = false;
		}

	}
	public void AdjustVolume (float newVolume){
		AudioListener.volume = newVolume;
	}
}
