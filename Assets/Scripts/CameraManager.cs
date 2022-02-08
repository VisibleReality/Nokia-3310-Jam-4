using JetBrains.Annotations;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private InputHandler currentInputHandler;
	[SerializeField] private Vector3 cameraPositionOffset;

	public void ChangeContext (InputHandler inputHandler)
	{
		currentInputHandler = inputHandler;
		transform.position = inputHandler.transform.position + cameraPositionOffset;
		inputHandler.OnFocus();
	}

	public void MoveCameraToObject (GameObject target)
	{
		transform.position = target.transform.position + cameraPositionOffset;
	}

	[UsedImplicitly]
	private void OnSelect ()
	{
		currentInputHandler.OnSelect();
	}

	[UsedImplicitly]
	private void OnUp ()
	{
		currentInputHandler.OnUp();
	}

	[UsedImplicitly]
	private void OnDown ()
	{
		currentInputHandler.OnDown();
	}

	[UsedImplicitly]
	private void OnLeft ()
	{
		currentInputHandler.OnLeft();
	}

	[UsedImplicitly]
	private void OnRight ()
	{
		currentInputHandler.OnRight();
	}
}