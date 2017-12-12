using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_Character : Character {

	void Start() {
		_animator.Play ("Animation Character", 0, Random.Range (0f, 1f));
	}

	protected override void Left()
	{
		--direction.x;

		_animator.SetFloat ("Walk", 0f);
	}

	protected override void Right()
	{
		++direction.x;

		_animator.SetFloat ("Walk", 1f);
	}

	protected override void ReleaseInput()
	{
		direction = Vector3.zero;

		_animator.SetFloat ("Walk", 0.5f);
	}
		

	void FixedUpdate() {
		_rigidbody2D.velocity = direction * speed * Time.deltaTime;
	}
}
