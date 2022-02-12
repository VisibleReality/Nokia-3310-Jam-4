using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private InputHandler currentInputHandler;
	[SerializeField] private Vector3 cameraPositionOffset;

	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] beeps;

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

	public void PlaySound (int soundId)
	{
		audioSource.clip = beeps[soundId];
		audioSource.Play();
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