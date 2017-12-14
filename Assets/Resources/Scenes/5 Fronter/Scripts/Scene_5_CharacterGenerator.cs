using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_CharacterGenerator : MonoBehaviour {

	public GameObject character;
	public Transform gameParent;
	public bool gameOverMeansNextScene = false;

	void Start() {
		CreateCharacter ();
	}

	public void CreateCharacter() {
		Debug.Log ("creation of new character");
		GameObject _c = Instantiate (character, transform.position, Quaternion.identity);
		_c.transform.parent = gameParent;
		Scene_5_CharacterDie _cd = _c.GetComponent<Scene_5_CharacterDie> ();
		_cd.generator = this;
		if (gameOverMeansNextScene)
			_cd.nextChangeScene = true;
	}
}
