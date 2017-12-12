using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3_Condition : ConditionEcranSuivant {

	public int dead = 0;
	public int minDeadToNextScene = 3;

	public void AddDead() {
		dead++;

		if (dead >= minDeadToNextScene)
			NextScene ();
	}
}
