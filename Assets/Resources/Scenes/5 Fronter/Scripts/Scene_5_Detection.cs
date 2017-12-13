using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_Detection : MonoBehaviour {

	public GameObject firePrefab;

	void OnTriggerEnter2D(Collider2D contact)
	{
		Debug.Log ("detected");
	}
}
