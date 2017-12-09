using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionEcranSuivant : MonoBehaviour {

	public GameObject leftScreenGameGroup, leftScreenDisplayGroup;
	public GameObject rightScreenGameGroup, rightScreenDisplayGroup;

	public virtual void NextScreen()
	{
		// switch screen
		leftScreenGameGroup.SetActive (false);
		leftScreenDisplayGroup.SetActive (true);

		rightScreenGameGroup.SetActive (true);
		rightScreenDisplayGroup.SetActive (false);
	}
}
