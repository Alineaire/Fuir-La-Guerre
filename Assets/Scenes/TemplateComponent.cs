using UnityEngine;

public class TemplateComponent : MonoBehaviour
{
	public float speed;

	void Update()
	{
		var translation = new Vector3();

		if (JoystickReceiver.instance.up.IsPressed)
		{
			++translation.y;
		}

		if (JoystickReceiver.instance.right.IsPressed)
		{
			++translation.x;
		}

		if (JoystickReceiver.instance.down.IsPressed)
		{
			--translation.y;
		}
		if (JoystickReceiver.instance.left.IsPressed)
		{
			--translation.x;
		}

		var transform = GetComponent<RectTransform>();
		var dm = speed * Time.deltaTime;
		transform.Translate(translation * dm);
	}
}
