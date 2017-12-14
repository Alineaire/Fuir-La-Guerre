using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2_explosion : MonoBehaviour {

	public float radiusDestruction = 1f;
	public float radiusProjection = 2f;
	public float explosionForce = 50f;
	public string tagToDestroy = "Scene_2_Bloc";
	public string tagForPeople = "Character";
	public GameObject deadPeoplePrefab;

	void Start () {
		
		DetectEnvironment ();

		DetectHumans ();
	}

	void DetectHumans() {
		// overlap to project people

		Collider2D[] humanContacts = Physics2D.OverlapCircleAll (transform.position, radiusProjection);

		if (humanContacts.Length > 0) {



			for (int i = 0; i < humanContacts.Length; i++) {
				if (humanContacts [i].tag == tagForPeople) {
					Vector3 peoplePos = humanContacts [i].transform.position;
					humanContacts [i].GetComponent<Scene_2_Character> ().CountDead ();
					Destroy (humanContacts [i].gameObject);
					GameObject g = Instantiate (deadPeoplePrefab, peoplePos, Quaternion.identity) as GameObject;
					g.transform.parent = transform.parent;
					Vector3 _direction = g.transform.position - transform.position;
					_direction.Normalize ();

					g.GetComponent<Rigidbody2D> ().AddForceAtPosition (_direction * explosionForce, transform.position);
				}
			}
		}
	}

	void DetectEnvironment() {
		// overlap to destroy buildings

		Collider2D[] contacts = Physics2D.OverlapCircleAll (transform.position, radiusDestruction);


		if (contacts.Length > 0) {

			for (int i = 0; i < contacts.Length; i++) {
				if (contacts [i].tag == tagToDestroy) {
					Destroy (contacts [i].gameObject);
					return;
				}
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
