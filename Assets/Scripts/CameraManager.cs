using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private InputHandler currentInputHandler;
	[SerializeField] private Vector3 cameraPositionOffset;

	public void ChangeContext (InputHandler inputHandler)
	{
		currentInputHandler = inputHandler;
		transform.position = inputHandler.transform.position + cameraPositionOffset;
	}

	private void OnSelect ()
	{
		currentInputHandler.OnSelect();
	}

	private void OnUp ()
	{
		currentInputHandler.OnUp();
	}

	private void OnDown ()
	{
		currentInputHandler.OnDown();
	}

	private void OnLeft ()
	{
		currentInputHandler.OnLeft();
	}

	private void OnRight ()
	{
		currentInputHandler.OnRight();
	}
}