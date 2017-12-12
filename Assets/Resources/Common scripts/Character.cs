using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed;

	protected Vector2 direction;
	protected Animator _animator;
	protected Rigidbody2D _rigidbody2D;

	protected bool isDead = false;

	protected virtual void Awake() {
		_animator = GetComponent<Animator> ();
		_rigidbody2D = GetComponent<Rigidbody2D> ();

	}

	protected virtual void Update() {
		bool _isInput = false;

		if (JoystickReceiver.instance.left.IsPressed) {
			Left ();

			_isInput = true;
		}

		if (JoystickReceiver.instance.right.IsPressed) {

			Right ();

			_isInput = true;
		}

		if (JoystickReceiver.instance.up.IsPressed) {

			Up ();

			_isInput = true;
		}

		if (JoystickReceiver.instance.down.IsPressed) {

			Down ();

			_isInput = true;
		}

		if(!_isInput){
			ReleaseInput ();
		}
	}

	protected virtual void Left(){}
	protected virtual void Right(){}
	protected virtual void Up(){}
	protected virtual void Down(){}
	protected virtual void ReleaseInput(){}
}
