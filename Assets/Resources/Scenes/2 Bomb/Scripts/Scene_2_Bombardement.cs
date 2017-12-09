using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_Bombardement : ConditionEcranSuivant {

	public GameObject prefabSignal;
	public float delayBeforeBomb;

	public Transform[] scenarioBombardement;

	private float cpt;
	private int etapeScenario = -1;

	void Start() {
		cpt = delayBeforeBomb;
	}

	void Update () {
		cpt += Time.deltaTime;

		if (cpt < delayBeforeBomb)
			return;

		Bombardement ();
	}

	void Bombardement() {
		cpt = 0f;

		etapeScenario++;

		if (etapeScenario >= scenarioBombardement.Length) {
			NextScreen();
			enabled = false;
			return;
		}

		Instantiate (prefabSignal, scenarioBombardement [etapeScenario].position, Quaternion.identity);

	}
}
