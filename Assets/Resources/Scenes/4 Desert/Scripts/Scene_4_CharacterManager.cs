using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_4_CharacterManager : Character {

	public enum KeyScenarioEnum {up, right, down, left};
	public enum Scene_4_ScreenEnum {left, right};

	public Scene_4_ScreenEnum screenActive = Scene_4_ScreenEnum.left;
	public KeyScenarioEnum keyToPush= KeyScenarioEnum.up;

	public Scene_4_MusicBox musicBox;

	[Header("Characters")]
	public float speedIncrementation = 1f;
	public List<Scene_4_Character> characters;
	public Transform generatorTransform;

	[Header("Condition")]
	public float speedMinToNextScene = 150f;
	// TODO : ajouter condition
	public int minPlayerInputToChangeScreen = 50;
	public int minToKill = 4;
	private int cptKill;
	private int cptInput;
	public Scene_4_Condition condition;

	public void AddCharacter(Scene_4_Character c) {
		characters.Add (c);
	}


	protected override void Left()
	{
		CheckKey (KeyScenarioEnum.left);
	}
	protected override void Right()
	{
		CheckKey (KeyScenarioEnum.right);
	}
	protected override void Up()
	{
		CheckKey (KeyScenarioEnum.up);
	}
	protected override void Down()
	{
		CheckKey (KeyScenarioEnum.down);
	}

	void CheckKey(KeyScenarioEnum _keyPushed) {
		if (_keyPushed == keyToPush) {

			if (keyToPush == KeyScenarioEnum.up) {
				keyToPush = KeyScenarioEnum.right;
			}
			else if (keyToPush == KeyScenarioEnum.right) {
				keyToPush = KeyScenarioEnum.down;
			}
			else if (keyToPush == KeyScenarioEnum.down) {
				keyToPush = KeyScenarioEnum.left;
			}
			else if (keyToPush == KeyScenarioEnum.left) {
				keyToPush = KeyScenarioEnum.up;
			}

			MoveAllCharacters ();
			speed *= speedIncrementation;
			musicBox.PlayerInput ();
			IncrementeInputForNextScreen ();

			if (screenActive == Scene_4_ScreenEnum.right)
				KillRandomCharacter ();
		}
	}

	void KillRandomCharacter() {
		cptKill++;

		if (cptKill < minToKill)
			return;

		cptKill = 0;

		int randomKilled = Random.Range (0, characters.Count);

		characters [randomKilled].Die ();
		characters.RemoveAt(randomKilled);

		if(characters.Count <= 0)
			condition.NextScene ();
	}

	void IncrementeInputForNextScreen() {
		cptInput++;

		if (cptInput >= minPlayerInputToChangeScreen) {
			if (screenActive == Scene_4_ScreenEnum.left) {
				condition.NextScreen ();
			}
		}
	}

	void MoveAllCharacters() {
		foreach (Scene_4_Character c in characters) {
			c.Move (speed);
		}
	}

	public void DestroyCharacter(Scene_4_Character c)
	{
		//characters.Remove (c);
		//Destroy (c.gameObject);
		Teleportation (c.transform);
	}

	void Teleportation(Transform t) {
		t.position = generatorTransform.position;
	}
}
