using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_Fire : MonoBehaviour {

	public GameObject sound;

	void Start() {
		Instantiate (sound, transform.position, Quaternion.identity);
	}

	public void AutoDestroy() {
		Destroy (gameObject);
	}
}
