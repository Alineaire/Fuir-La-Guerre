using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1_InputMove : InputMoveCharacter {

	public float xMin, xMax;
	public Animator _animator;
	public string boolToPlay;

	protected override void Update () {

		bool _isInput = false;

		if (JoystickReceiver.instance.left.IsPressed && canLeft && transform.position.x > xMin) {
			--direction.x;
			DirectionAnimation (true);
			_isInput = true;
		}

		if (JoystickReceiver.instance.right.IsPressed && canRight  && transform.position.x < xMax) {
			++direction.x;
			DirectionAnimation (true);
			_isInput = true;
		}

		if(!_isInput){
			direction = Vector3.zero;
			DirectionAnimation (false);
		}
	}

	protected override void DirectionAnimation (bool _input)
	{
		base.DirectionAnimation (_input);

		if (_animator)
			_animator.SetBool (boolToPlay, _input);
	}
}