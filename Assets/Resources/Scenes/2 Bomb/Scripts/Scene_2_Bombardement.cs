using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_Bombardement : ConditionEcranSuivant {

	[Header("Left")]
	public GameObject leftPrefabSignal;
	public float leftDelayBeforeBomb;
	public Transform[] leftScenarioBombardement;
	public Transform leftTransformParent;
	public int leftHumanAlive = 4;
	public GameObject leftJoystickUI;

	[Header("Right")]
	public GameObject rightPrefabSignal;
	public float rightDelayBeforeBomb;
	public Transform[] rightScenarioBombardement;
	public Transform rightTransformParent;
	public int rightHumanAlive = 4;
	public GameObject rightJoystickUI;

	private float cpt;
	private int etapeScenario = -1;

	public enum Scene_2_enum_scenario
	{
		left,
		right}

	;

	public Scene_2_enum_scenario scenario = Scene_2_enum_scenario.left;

	protected override void Start() {
		base.Start ();
		cpt = leftDelayBeforeBomb;
	}

	void Update () {
		
		cpt += Time.deltaTime;

		if (scenario == Scene_2_enum_scenario.left) {
			
			// LEFT

			if (cpt < leftDelayBeforeBomb)
				return;

			Bombardement (leftPrefabSignal, leftScenarioBombardement, leftTransformParent);

		} else {
			
			// RIGHT

			if (cpt < rightDelayBeforeBomb)
				return;

			Bombardement (rightPrefabSignal, rightScenarioBombardement, rightTransformParent);
		}
	}

	void Bombardement(GameObject _prefab, Transform[] _scen, Transform _t) {
		cpt = 0f;

		etapeScenario++;

		if (etapeScenario >= _scen.Length) {
			EndScreen ();
			return;
		}

		GameObject g = Instantiate (_prefab, _scen [etapeScenario].position, Quaternion.identity) as GameObject;
		g.transform.parent = _t;

	}

	void EndScreen() {
		if (scenario == Scene_2_enum_scenario.left) {
			etapeScenario = -1;
			scenario = Scene_2_enum_scenario.right;
			NextScreen ();
		} else {
			NextScene ();
		}
	}

	public void OneKill(bool _isLeftHuman) {
		if (_isLeftHuman) {
			leftHumanAlive--;

			if (leftHumanAlive <= 0)
				leftJoystickUI.SetActive (false);
		} else {
			rightHumanAlive--;

			if (rightHumanAlive <= 0)
				rightJoystickUI.SetActive (false);
		}
	}
}
