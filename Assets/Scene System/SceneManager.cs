using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneManager : MonoBehaviour
{
	public static SceneManager instance;

	public SceneSettings settings;
	private int sceneIndex;

	private void Awake()
	{
		Assert.IsTrue(UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings > 1);

		instance = this;
		JoystickReceiver.Spawn(gameObject);

		if (Display.displays.Length > 1)
		{
			Display.displays[1].Activate();
		}
	}

	private void Start()
	{
		sceneIndex = 0;
		LoadNextScene();
	}

	public void LoadNextScene()
	{
		StartCoroutine(LoadNextSceneAsync());
	}

	private IEnumerator LoadNextSceneAsync()
	{
		if (sceneIndex > 0)
		{
			var unloadAsync = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex);
			yield return new WaitUntil(() => unloadAsync.isDone);
		}

		++sceneIndex;

		if (sceneIndex >= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
		{
			sceneIndex = settings.titleSceneIndex;
		}

		var loadAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, UnityEngine.SceneManagement.LoadSceneMode.Additive);
		yield return new WaitUntil(() => loadAsync.isDone);
	}
}
