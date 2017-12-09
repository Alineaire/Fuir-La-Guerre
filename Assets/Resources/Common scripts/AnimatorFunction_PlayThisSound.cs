using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunction_PlayThisSound : MonoBehaviour {

	public AudioSource _audioSource;
	public AudioClip _clip;

	public void PlayThisSound() {
		if (_audioSource)
			_audioSource.PlayOneShot (_clip);
	}
}
