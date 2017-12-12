using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_splash : MonoBehaviour {

	public void DestroySplash() {
		Destroy (transform.parent.gameObject);
	}
}
