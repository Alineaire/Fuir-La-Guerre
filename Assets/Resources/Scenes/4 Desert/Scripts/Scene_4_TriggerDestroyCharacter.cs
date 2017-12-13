using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_4_TriggerDestroyCharacter : MonoBehaviour {

	public Scene_4_CharacterManager manager;

	void OnTriggerEnter2D(Collider2D contact)
	{
		Debug.Log ("contact");
		manager.DestroyCharacter (contact.GetComponent<Scene_4_Character> ());
	}
}
