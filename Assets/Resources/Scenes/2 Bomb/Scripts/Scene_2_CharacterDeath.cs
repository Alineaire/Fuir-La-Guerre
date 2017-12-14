using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_CharacterDeath : MonoBehaviour {

	public string tagTransform;

	// Use this for initialization
	void Awake () {
		Transform t = GameObject.FindGameObjectWithTag (tagTransform).transform;
		transform.parent = t;
	}
}
