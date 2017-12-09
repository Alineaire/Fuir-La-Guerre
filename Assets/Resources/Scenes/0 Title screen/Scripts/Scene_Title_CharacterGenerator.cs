using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Title_CharacterGenerator : MonoBehaviour {

	public float minDelay, maxDelay;
	public GameObject prefabToInstanciate;

	private float cpt;
	private float nextTime;

	void Start() {
		DefineNextTime ();
	}

	void Update () {
		cpt += Time.deltaTime;

		if (cpt > nextTime) {
			DefineNextTime ();
			GameObject g = Instantiate (prefabToInstanciate, transform.position, Quaternion.identity) as GameObject;
			g.transform.parent = transform;
		}
	}

	void DefineNextTime() {
		nextTime = Random.Range (minDelay, maxDelay);
	}
}
