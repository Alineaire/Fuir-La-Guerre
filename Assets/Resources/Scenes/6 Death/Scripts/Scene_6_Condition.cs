using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_6_Condition : ConditionEcranSuivant {

	public int minPass = 4;
	public int actualPass = 0;

	public void Pass() {
		actualPass++;

		if (actualPass >= minPass) {
			NextScreen ();
		}
	}
}
