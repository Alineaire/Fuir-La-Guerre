using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Title_LocalCharacterGenerator : MonoBehaviour {

	public float timer;
	public GameObject prefabToInstanciate;

	private float cpt;

	void Update () {
		if (cpt < 0f) {
			cpt = timer;
			Instantiate (prefabToInstanciate, transform.position, Quaternion.identity);
		}
	}
}
