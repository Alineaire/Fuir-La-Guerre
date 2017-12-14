using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_Detection : MonoBehaviour {

	public GameObject firePrefab;

	public enum Scene_5_ConditionEnum {left, right};
	public Scene_5_ConditionEnum screen = Scene_5_ConditionEnum.left;

	void OnTriggerEnter2D(Collider2D contact)
	{
		Debug.Log ("detected");

		Instantiate (firePrefab, contact.transform.position, Quaternion.identity);
		contact.GetComponent<Scene_5_Character> ().Die();

		/*if (screen == Scene_5_ConditionEnum.left) {
			condition.NextScreen();
		} else {
			condition.NextScene();
		}*/
	}
}
