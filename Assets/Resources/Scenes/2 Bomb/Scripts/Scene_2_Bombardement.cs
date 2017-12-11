using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_Bombardement : ConditionEcranSuivant {

	[Header("Left")]
	public GameObject leftPrefabSignal;
	public float leftDelayBeforeBomb;
	public Transform[] leftScenarioBombardement;

	[Header("Right")]
	public GameObject rightPrefabSignal;
	public float rightDelayBeforeBomb;
	public Transform[] rightScenarioBombardement;


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

			Bombardement (leftPrefabSignal, leftScenarioBombardement);

		} else {
			
			// RIGHT

			if (cpt < rightDelayBeforeBomb)
				return;

			Bombardement (rightPrefabSignal, rightScenarioBombardement);
		}
	}

	void Bombardement(GameObject _prefab, Transform[] _scen) {
		cpt = 0f;

		etapeScenario++;

		if (etapeScenario >= _scen.Length) {
			EndScreen ();
			return;
		}

		Instantiate (_prefab, _scen [etapeScenario].position, Quaternion.identity);

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
}
