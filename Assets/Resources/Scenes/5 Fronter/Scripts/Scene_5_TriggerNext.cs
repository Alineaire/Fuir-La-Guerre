using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_TriggerNext : MonoBehaviour {

	public Scene_5_Condition condition;
	public bool isLeftScreen = true;

	void OnTriggerEnter2D() {
		if (isLeftScreen)
			condition.NextScreen ();
		if (!isLeftScreen)
			condition.NextScene ();
	}
}
