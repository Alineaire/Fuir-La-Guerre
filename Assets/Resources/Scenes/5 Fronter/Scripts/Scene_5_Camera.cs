using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_5_Camera : MonoBehaviour {

	public enum CameraEnum
	{
		Wait,
		Watch}

	;

	public CameraEnum cameraState = CameraEnum.Wait;
	public float delayWait = 5f;
	public float delayWatch = 5f;

	private float cpt;
	private Animator _animator;

	void Awake() {
		_animator = GetComponent<Animator> ();
		cpt = Random.Range (0f, delayWait);
	}

	void Update () {
		cpt -= Time.deltaTime;

		if (cpt > 0f)
			return;

		if (cameraState == CameraEnum.Wait) {
			cpt = delayWatch;
			_animator.SetBool ("Watch", true);
			cameraState = CameraEnum.Watch;
		} else {
			cpt = delayWait;
			_animator.SetBool ("Watch", false);
			cameraState = CameraEnum.Wait;
		}

	}
}
