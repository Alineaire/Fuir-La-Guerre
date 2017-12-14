using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_Character : Character {

	[Header("Jump")]
	public float jumpForce = 500f;
	public float delayBeforeNextJump = 0.5f; // prevent sound repetition
	private float cptNextJump;
	bool isJumping = false;
	public float jumpSecurity = 1f;
	private float cptJumpSecurity;

	[Header("Ground")]
	public Transform groundTransform;
	public LayerMask whatIsGround;
	public float groundRadius = 1f;
	public float stepDelay = 0.2f;
	public float cptStep;

	[Header("Sound")]
	public AudioClip stepClip;
	public AudioClip jumpClip;
	AudioSource _audio;

	private bool grounded = true;

	protected override void Awake() {
		base.Awake ();
		_audio = GetComponent<AudioSource> ();
	}

	void Start() {
		_animator.Play ("StandTree", 0, Random.Range (0f, 1f));
	}

	protected override void Left()
	{
		// aller a gauche
		--direction.x;

		_animator.SetFloat ("Walk", 0f);
	}

	protected override void Right()
	{
		// aller a droite
		++direction.x;

		_animator.SetFloat ("Walk", 1f);

	}

	protected override void Up() {
		// Saut
		// TODO Jump animation

		if (grounded && cptNextJump >= delayBeforeNextJump) {

			cptNextJump = 0f;
			_rigidbody2D.AddForce (new Vector2(0.5f, 1f) * jumpForce);
			grounded = false;
			_audio.PlayOneShot (jumpClip);
			isJumping = true;
			cptJumpSecurity = jumpSecurity;
		}
	}

	void StepFunction() {
		if (!grounded)
			return;
		
		cptStep += Time.deltaTime;

		if (cptStep >= stepDelay) {
			cptStep = 0f;
			_audio.PlayOneShot (stepClip);
		}
	}

	protected override void Update ()
	{
		if (isDead)
			return;

		base.Update ();

		cptNextJump += Time.deltaTime;

		if (!isJumping)
			grounded = Physics2D.OverlapCircle (groundTransform.position, groundRadius, whatIsGround);
		else {
			cptJumpSecurity -= Time.deltaTime;
			if (cptJumpSecurity <= 0f) {
				isJumping = false;
			}
		}
	}

	protected override void ReleaseInput()
	{
		direction = Vector2.zero;

		_animator.SetFloat ("Walk", 0.5f);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (groundTransform.position, groundRadius);
	}

	public void Die() {
		isDead = true;
		Destroy (this);
	}

	void FixedUpdate() {
		if(grounded)
			_rigidbody2D.velocity = new Vector2(direction.x * speed, _rigidbody2D.velocity.y);
		else
			_rigidbody2D.velocity = _rigidbody2D.velocity;
	}
}
