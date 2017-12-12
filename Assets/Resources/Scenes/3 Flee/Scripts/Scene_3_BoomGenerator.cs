using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_BoomGenerator : MonoBehaviour {

	public GameObject prefab;
	public float delayMin, delayMax;
	private float cpt;
	private float nextDelay;
	AudioSource _audio;

	void Awake() {
		SetNextDelay ();
		_audio = GetComponent<AudioSource> ();
	}

	void Update () {
		cpt += Time.deltaTime;

		if (cpt >= nextDelay) {
			cpt = 0f;
			Instantiate (prefab, transform.position, Quaternion.identity);
			SetNextDelay ();
			_audio.Play ();
		}
	}

	void SetNextDelay() {
		nextDelay = Random.Range (delayMin, delayMax);
	}
}
