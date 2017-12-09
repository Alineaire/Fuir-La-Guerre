using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1_InputBallRight : Scene_1_InputBall {

	public int minPassToBreak = 2;
	public int actualPass = 0;
	public float delayToWait = 3f;
	private float cpt;

	protected override void Update ()
	{
		if (!_condition)
			return;

		if (actualPass >= minPassToBreak) {

			cpt += Time.deltaTime;

			if (cpt >= delayToWait) {
				_condition.NextScene ();
			}

			return;
		}

		if (JoystickReceiver.instance.left.IsPressed && !left) {
			_animator.SetTrigger ("Left");
			left = true;
			Pass ();
			return;
		}

		if (JoystickReceiver.instance.right.IsPressed && left) {
			_animator.SetTrigger ("Right");
			left = false;
			Pass ();
			return;
		}


	}

	void Pass() {
		actualPass++;
		if (actualPass >= minPassToBreak)
			_animator.SetTrigger ("Boom");
	}
}
