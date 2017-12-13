using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_4_Character : MonoBehaviour {

	public float delayBeforeStand = 0.5f;
	private float cpt;
	//private Scene_4_CharacterManager manager;
	Rigidbody2D _rigidbody2D;
	Animator _animator;

	bool beginCountDownWalk = false;

	void Awake( ){
		_rigidbody2D = GetComponent<Rigidbody2D> ();
		_animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	/*void Start () {
		manager = GameObject.FindObjectOfType<Scene_4_CharacterManager> ();
	}*/

	void Start() {
		_animator.Play ("Stand", 0, Random.Range (0f, 1f));
	}

	void Update() {
		if (!beginCountDownWalk)
			return;

		cpt += Time.deltaTime;

		if (cpt < delayBeforeStand)
			return;

		_animator.SetBool ("Walk", false);
	}
	
	public void Move(float _speed) {
		_rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
		_animator.SetBool ("Walk", true);
		beginCountDownWalk = true;
		cpt = 0f;
	}

	public void Die() {
		_animator.SetTrigger ("Die");
	}
}
