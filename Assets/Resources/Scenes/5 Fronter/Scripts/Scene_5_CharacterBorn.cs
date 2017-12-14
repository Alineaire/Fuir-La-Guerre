using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_CharacterBorn : MonoBehaviour {

	public float delayBeforeOk;
	public float pingpongFrequency = 1f;
	SpriteRenderer _sprite;
	float timeAlpha;

	void Awake() {
		_sprite = GetComponentInChildren<SpriteRenderer> ();
	}

	void Update() {
		timeAlpha += Time.deltaTime  * pingpongFrequency;

		Color sColor = _sprite.color;
		sColor.a = Mathf.PingPong (timeAlpha, 1f);
		_sprite.color = sColor;

		if (timeAlpha >= delayBeforeOk) {
			sColor.a = 1f;
			_sprite.color = sColor;
			Destroy (this);
		}
	}
}
