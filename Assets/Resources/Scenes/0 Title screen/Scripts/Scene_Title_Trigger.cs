using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Title_Trigger : MonoBehaviour {

	public float newXpos;

	void OnTriggerEnter2D(Collider2D contact) {
		Vector3 pos = transform.position;
		pos.x = newXpos;
		pos.y = contact.transform.position.y;
		pos.z = contact.transform.position.z;

		contact.transform.position = pos;
	}
}
