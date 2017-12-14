using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_6_Family : MonoBehaviour {

	public Animator _animator;
	public Scene_6_Condition _condition;

	public bool left = true;

	protected virtual void Update () {
		if (!_condition)
			return;

		if (JoystickReceiver.instance.left.IsPressed && !left) {
			_animator.SetTrigger ("Left");
			left = true;
			_condition.Pass ();
			return;
		}

		if (JoystickReceiver.instance.right.IsPressed && left) {
			_animator.SetTrigger ("Right");
			left = false;
			_condition.Pass ();
			return;
		}
	}
}
