using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveCharacter : MonoBehaviour {

	public float speed;
	public bool canUp, canDown, canLeft, canRight;

	Vector3 direction;

	protected virtual void Awake() {

	}

	void Update () {

		bool _isInput = false;

		if (JoystickReceiver.instance.up.IsPressed && canUp) {
			++direction.y;
			DirectionAnimation (true);
			_isInput = true;
		} 
		if (JoystickReceiver.instance.down.IsPressed && canDown) {
			--direction.y;
			DirectionAnimation (true);
			_isInput = true;
		}
		if (JoystickReceiver.instance.left.IsPressed && canLeft) {
			--direction.x;
			DirectionAnimation (true);
			_isInput = true;
		}
		if (JoystickReceiver.instance.right.IsPressed && canRight) {
			++direction.x;
			DirectionAnimation (true);
			_isInput = true;
		}
		
		if(!_isInput){
			direction = Vector3.zero;
			DirectionAnimation (false);
		}
	}

	protected virtual void DirectionAnimation(bool _input) {
		if (_input)
			Debug.Log ("ok");

	}

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
