using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunction_PlaySound : MonoBehaviour {

	public AudioSource _audioSource;

	public void PlaySound() {
		if (_audioSource)
			_audioSource.Play ();
	}
}
