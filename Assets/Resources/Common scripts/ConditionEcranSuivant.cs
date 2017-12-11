using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionEcranSuivant : MonoBehaviour {

	public GameObject leftScreenGameGroup, leftScreenDisplayGroup;
	public GameObject rightScreenGameGroup, rightScreenDisplayGroup;

	protected Scene _scene;

	void Awake() {
		_scene = GameObject.FindObjectOfType<Scene> () as Scene;
	}

	protected virtual void Start() {
		leftScreenGameGroup.SetActive (true);
		leftScreenDisplayGroup.SetActive (false);

		rightScreenGameGroup.SetActive (false);
		rightScreenDisplayGroup.SetActive (true);
	}

	public virtual void NextScreen()
	{
		// switch screen
		leftScreenGameGroup.SetActive (false);
		leftScreenDisplayGroup.SetActive (true);

		rightScreenGameGroup.SetActive (true);
		rightScreenDisplayGroup.SetActive (false);
	}

	public virtual void NextScene() {
		_scene.TransitionToNextScene ();
	}
}
