using UnityEngine;

public class HideOnWebGL : MonoBehaviour
{
	void Start ()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			gameObject.SetActive(false);
		}
	}
}