using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_4_MusicBox : MonoBehaviour {

	public AudioClip[] melodie;
	public int melodiePosition;
	public float frequency = 1f;
	public float delayToPlay = 0f;
	public float frequencyFactor = 1f;
	public float delayPerInput = 1f;

	private float cptFrequency;
	private AudioSource _audio;

	void Awake() {
		_audio = GetComponent<AudioSource> ();
	}

	void Update() {
		delayToPlay -= Time.deltaTime;

		if (delayToPlay <= 0f) {
			delayToPlay = 0f;
			return;
		}
			

		cptFrequency += Time.deltaTime;

		if (cptFrequency >= frequency) {
			// jouer la note

			cptFrequency = 0f;

			_audio.PlayOneShot(melodie[melodiePosition]);

			melodiePosition++;

			if (melodiePosition >= melodie.Length)
				melodiePosition = 0;
		}
	}

	public void PlayerInput() {
		frequency *= frequencyFactor;


		delayToPlay += delayPerInput;
	}

}
