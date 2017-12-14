using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_6_TimerRight : MonoBehaviour {

	public Scene_6_Condition condition;
	public float delay = 5f;

	public GameObject uiJoystick;

	void Update() {
		delay -= Time.deltaTime;

		if (delay > 0f)
			return;

		if(!uiJoystick.activeInHierarchy) uiJoystick.SetActive (true);

		if (JoystickReceiver.instance.left.IsPressed) {
			EndTheGame ();
		}

		if (JoystickReceiver.instance.right.IsPressed) {
			EndTheGame ();
		}

		if (JoystickReceiver.instance.up.IsPressed) {
			EndTheGame ();
		}

		if (JoystickReceiver.instance.down.IsPressed) {
			EndTheGame ();
		}
	}

	void EndTheGame() {
		condition.NextScene ();
	}
}
