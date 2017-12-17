using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickTest : MonoBehaviour {

	public Text uiText;

	void Update () {
		uiText.text = "Left : " +
			(JoystickReceiver.instance.left.IsPressed ? "true" : "false").ToString();
	}
}
