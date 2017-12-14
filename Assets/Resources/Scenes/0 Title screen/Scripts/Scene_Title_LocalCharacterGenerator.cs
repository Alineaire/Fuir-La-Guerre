using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Title_LocalCharacterGenerator : MonoBehaviour {

	public float timer;
	public GameObject prefabToInstanciate;
	public Vector2 direction;
	public float speed;

	private float cpt;

	void Update () {
		transform.Translate (direction * Time.deltaTime * speed);

		cpt += Time.deltaTime;

		if (cpt >= timer) {
			cpt = 0f;
			GameObject g = Instantiate (prefabToInstanciate, transform.position, Quaternion.identity) as GameObject;
			//g.transform.parent = transform;
		}
	}
}