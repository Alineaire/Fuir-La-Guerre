using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1_Condition : ConditionEcranSuivant {

	public int minPass = 4;
	public int actualPass = 0;
	public Scene _scene;

	public void Pass() {
		actualPass++;

		if (actualPass >= minPass) {
			NextScreen ();
		}
	}

	public void NextScene() {
		if(_scene)
			_scene.TransitionToNextScene ();
	}
}
