using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Title_Input : MonoBehaviour {

	public float holdDelay = 1f;
	public RectTransform[] inputChecks;
	public int minCheckSize, maxCheckSize;
	public Sprite checkedSprite;

	private float cpt;

	private Scene _scene;

	void Awake() {
		_scene = GameObject.FindObjectOfType<Scene> () as Scene;
	}

	void Update () {
		bool _isInput = false;
		if (JoystickReceiver.instance.left.IsPressed) {
			HoldInput ();
			_isInput = true;
		}

		if (JoystickReceiver.instance.right.IsPressed) {

			HoldInput ();
			_isInput = true;
		}

		if (JoystickReceiver.instance.up.IsPressed) {

			HoldInput ();
			_isInput = true;
		}

		if (JoystickReceiver.instance.down.IsPressed) {
			HoldInput ();
			_isInput = true;
		}

		if(!_isInput){
			cpt = 0f;
			foreach (RectTransform r in inputChecks) {
				r.sizeDelta = new Vector2 (0f, 0f);
			}
		}
	}

	void HoldInput() {
		cpt += Time.deltaTime;



		if (cpt >= holdDelay) {
			
			foreach (RectTransform r in inputChecks) {
				r.GetComponent<Image> ().sprite = checkedSprite;
			}

			_scene.TransitionToNextScene ();
		} else {
			float inputNormalized = holdDelay / cpt;

			foreach (RectTransform r in inputChecks) {
				float s = Mathf.MoveTowards (maxCheckSize, minCheckSize, inputNormalized);
				r.sizeDelta = new Vector2 (s, s);
			}
		}
	}
}
