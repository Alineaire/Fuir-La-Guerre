using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_Character : Character {

	public Color deadColor;
	public SpriteRenderer _sprite;
	public float forceProjection = 50f;
	Rigidbody2D _rigidBody2D;
	public float delayBeforeNext;
	Scene_5_CharacterDie characterDieComponent;
	Animator _animator;

	private float cpt;

	protected override void Awake ()
	{
		base.Awake ();
		_rigidBody2D = GetComponent<Rigidbody2D> ();
		characterDieComponent = GetComponent<Scene_5_CharacterDie> ();
		_animator = GetComponent<Animator> ();
	}

	protected override void Update ()
	{
		base.Update ();


	}

	protected override void Left()
	{
		// aller a gauche
		--direction.x;

		_animator.SetBool ("Walk", true);
	}

	protected override void Right()
	{
		// aller a droite
		++direction.x;

		_animator.SetBool ("Walk", true);

	}

	protected override void ReleaseInput()
	{
		direction = Vector2.zero;

		_animator.SetBool ("Walk", false);
	}

	void FixedUpdate() {
		_rigidbody2D.velocity = new Vector2(direction.x * speed, _rigidbody2D.velocity.y);
	}

	public void Die() {
		_sprite.color = deadColor;
		_rigidBody2D.constraints = RigidbodyConstraints2D.None;
		_rigidBody2D.AddForce (new Vector2 (forceProjection, 0f));
		characterDieComponent.enabled = true;
		enabled = false;
	}
}
