using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_TriggerEnd : MonoBehaviour {

	public Scene_3_Condition condition;
	public enum S3enumTrigger {Left, right, water};
	public GameObject splashPrefab;
	public Transform splashTransform;
	AudioSource _audio;

	void Awake() {
		_audio = GetComponent<AudioSource> ();
	}

	public S3enumTrigger trigState = S3enumTrigger.Left;

	void OnTriggerEnter2D(Collider2D other) {
		if (trigState == S3enumTrigger.Left) {
			condition.NextScreen ();
		} else if (trigState == S3enumTrigger.right) {
			condition.NextScene ();
		} else if (trigState == S3enumTrigger.water) {
			// TODO SPLASH !
			other.GetComponent<Scene_3_Character>().Die();
			Instantiate (splashPrefab, splashTransform.position, Quaternion.identity);
			_audio.Play ();
			condition.AddDead ();
		}
	}
}
