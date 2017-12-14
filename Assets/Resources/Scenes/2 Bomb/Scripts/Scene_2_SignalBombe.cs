using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_SignalBombe : MonoBehaviour {

	public GameObject explosionrefab;
	public float delayToExplode;

	private float cpt;

	void Update () {
		cpt += Time.deltaTime;

		if (cpt < delayToExplode)
			return;

		GameObject g = Instantiate (explosionrefab, transform.position, Quaternion.identity) as GameObject;
		g.transform.parent = transform.parent;

		Destroy (gameObject);
	}
}
