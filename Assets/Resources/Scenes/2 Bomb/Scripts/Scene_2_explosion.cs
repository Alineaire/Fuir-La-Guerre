using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_explosion : MonoBehaviour {

	public float radiusDestruction = 1f;
	public float radiusProjection = 2f;
	public string tagToDestroy = "Scene_2_Bloc";
	public string tagForPeople = "Character";
	public GameObject deadPeoplePrefab;

	void Start () {
		
		// overlap to destroy buildings
		Collider2D[] contacts = Physics2D.OverlapCircleAll (transform.position, radiusDestruction);

		if (contacts.Length == 0)
			return;

		for (int i = 0; i < contacts.Length; i++) {
			if (contacts [i].tag == tagToDestroy) {
				Destroy (contacts [i].gameObject);
				return;
			}
		}

		// overlap to project people

		contacts = Physics2D.OverlapCircleAll (transform.position, radiusProjection);

		if (contacts.Length == 0)
			return;

		for (int i = 0; i < contacts.Length; i++) {
			if (contacts [i].tag == tagForPeople) {
				Vector3 peoplePos = contacts [i].transform.position;
				Destroy (contacts [i].gameObject);
				Instantiate (deadPeoplePrefab, peoplePos, Quaternion.identity);
			}
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, radiusDestruction);

		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere (transform.position, radiusProjection);
	}

	public void EndAnimation() {
		Destroy (gameObject);
	}
}
