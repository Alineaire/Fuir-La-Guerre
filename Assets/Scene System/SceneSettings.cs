using UnityEngine;

[CreateAssetMenu()]
public class SceneSettings : ScriptableObject
{
	public int titleSceneIndex;

	public GameObject fadeOverlayPrefab;
	public float fadeDuration;
	public Color fadeColor;
}
