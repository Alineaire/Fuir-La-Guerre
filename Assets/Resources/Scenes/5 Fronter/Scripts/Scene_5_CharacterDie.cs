using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_CharacterDie : MonoBehaviour {

	Scene_5_Condition condition;
	public float delayReborn, delayNext;
	public bool nextChangeScene = false;
	public Scene_5_CharacterGenerator generator;

	private bool endCondition = false;
	private float cpt;

	Animator _animator;

	void Awake() {
		condition = GameObject.FindObjectOfType<Scene_5_Condition> ();
		_animator = GetComponent<Animator> ();
		enabled = false;
	}

	void Start() {
		_animator.enabled = false;
		condition.leftLive--;
		if (condition.leftLive <= 0)
			endCondition = true;
	}

	void Update () {
		cpt += Time.deltaTime;

		if (endCondition) {
			if (cpt < delayNext)
				return;

			if (nextChangeScene) {
				condition.NextScene ();
			} else {
				condition.NextScreen ();
				Destroy (this);
			}

		} else {
			if (cpt < delayReborn)
				return;

			generator.CreateCharacter ();
			Destroy (this);
		}
	}
}
