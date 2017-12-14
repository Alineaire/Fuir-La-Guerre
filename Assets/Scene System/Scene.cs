using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
	public static Scene instance;

	private enum Transition
	{
		In,
		Out,
	};

	private Tween fadeTween;
	private Color color, fadeColor, gameColor;
	private List<Image> images = new List<Image>();
	private bool transitionRequested = false;

	private SceneSettings settings
	{
		get
		{
			return SceneManager.instance != null ? SceneManager.instance.settings : null;
		}
	}

	private void Awake()
	{
		instance = this;
		JoystickReceiver.Spawn(gameObject);

		if (settings != null)
		{
			fadeColor = settings.fadeColor;
			fadeColor.a = 1f;

			gameColor = settings.fadeColor;
			gameColor.a = 0f;

			color = fadeColor;

			var canvases = FindObjectsOfType<Canvas>();
			//Assert.AreEqual(2, canvases.Length, "There should be two Canvas objects, one for each display.");
			foreach (var canvas in canvases)
			{
				if (canvas.tag == "GameCanvas")
				{
					var fadeOverlay = Instantiate(settings.fadeOverlayPrefab, canvas.transform);

					var image = fadeOverlay.GetComponent<Image>();
					image.color = color;
					images.Add(image);
				}
			}
		}
	}

	private Tween Fade(Transition transition)
	{
		if (fadeTween != null)
		{
			fadeTween.Complete();
		}

		Color endColor = gameColor;
		switch (transition)
		{
			case Transition.In:
				endColor = gameColor;
				break;

			case Transition.Out:
				endColor = fadeColor;
				break;
		}

		fadeTween = DOTween.To(() => color, newColor =>
		{
			color = newColor;
			foreach (var image in images)
			{
				image.color = color;
			}
		}, endColor, settings.fadeDuration)
			.SetEase(Ease.Linear);

		if (transition == Transition.Out)
		{
			var audioSources = FindObjectsOfType<AudioSource>();
			foreach (var audioSource in audioSources)
			{
				audioSource.DOFade(0, settings.fadeDuration);
			}
		}

		return fadeTween;
	}

	private void Start()
	{
		if (settings != null)
		{
			Fade(Transition.In);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			TransitionToNextScene();
		}
	}

	public void TransitionToNextScene()
	{
		if (transitionRequested)
		{
			return;
		}

		transitionRequested = true;

		if (settings != null)
		{
			Fade(Transition.Out)
				.OnComplete(() =>
				{
					SceneManager.instance.LoadNextScene();
				});
		}
		else
		{
			Debug.Log("Transition to next scene.");
			Debug.Break();
		}
	}
}
