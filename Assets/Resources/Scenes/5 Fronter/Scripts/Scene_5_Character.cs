using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_Character : Character {

	protected override void Left()
	{
		// aller a gauche
		--direction.x;

		//_animator.SetFloat ("Walk", 0f);
	}

	protected override void Right()
	{
		// aller a droite
		++direction.x;

		//_animator.SetFloat ("Walk", 1f);

	}

	protected override void ReleaseInput()
	{
		direction = Vector2.zero;

		//_animator.SetFloat ("Walk", 0.5f);
	}

	void FixedUpdate() {
		_rigidbody2D.velocity = new Vector2(direction.x * speed, _rigidbody2D.velocity.y);
	}
}
