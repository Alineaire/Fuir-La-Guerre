using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioOnFinished : MonoBehaviour {

	AudioSource _audio;

	void Awake() {
		_audio = GetComponent<AudioSource> ();
	}

	void Update () {
		if (!_audio.isPlaying)
			Destroy (gameObject);
	}
}
