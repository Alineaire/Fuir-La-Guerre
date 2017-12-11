using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_Character : MonoBehaviour {

	public float speed;

	private Vector3 direction;
	private Animator _animator;
	private Rigidbody2D _rigidbody2D;

	void Awake() {
		_animator = GetComponent<Animator> ();
		_rigidbody2D = GetComponent<Rigidbody2D> ();

		//_animator.GetCurrentAnimatorStateInfo (0).normalizedTime = Random.Range (0f, 1f);

	}

	void Start() {
		_animator.Play ("Animation Character", 0, Random.Range (0f, 1f));
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
		//transform.Translate (direction * speed * Time.deltaTime);
		_rigidbody2D.velocity = direction * speed * Time.deltaTime;
	}
}
