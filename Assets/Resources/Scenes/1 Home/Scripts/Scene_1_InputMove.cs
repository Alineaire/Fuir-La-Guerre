using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1_InputMove : InputMoveCharacter {

	public Animator _animator;
	public string triggerToPlay;

	protected override void DirectionAnimation (bool _input)
	{
		base.DirectionAnimation (_input);

		if (!_animator)
			_animator.SetBool (triggerToPlay, _input);
	}
}