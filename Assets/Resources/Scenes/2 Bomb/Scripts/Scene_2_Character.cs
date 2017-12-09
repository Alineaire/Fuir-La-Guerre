using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_Character : MonoBehaviour {

	public float speed;

	private Vector3 direction;
	private Animator _animator;

	void Awake() {
		_animator = GetComponent<Animator> ();
	}

	void Update () {
		bool _isInput = false;

		if (JoystickReceiver.instance.left.IsPressed) {

			--direction.x;

			_animator.SetFloat ("Walk", 0f);

			_isInput = true;
		}

		if (JoystickReceiver.instance.right.IsPressed) {

			++direction.x;

			_animator.SetFloat ("Walk", 1f);

			_isInput = true;
		}

		if(!_isInput){
			direction = Vector3.zero;

			_animator.SetFloat ("Walk", 0.5f);
		}
	}

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
