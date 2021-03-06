using System;
using UnityEngine;

public class MainViewInputHandler : InputHandler
{
	[SerializeField] private InputHandler upgradesView;
	[SerializeField] private InputHandler statsView;

	[SerializeField] private Transform skyTransform;

	private float skyVerticalOffset;

	private new void Start ()
	{
		base.Start();

		skyVerticalOffset = skyTransform.position.y;
	}

	private void Update ()
	{
		skyTransform.position =
			new Vector3(0,
				(float)(-(Math.Log10(gameManager.gameData.plantHeight + 10) * 31) + skyVerticalOffset + 31),
				0);
	}

	public override void OnFocus ()
	{
		gameManager.SaveGameAsync();
	}

	public override void OnSelect ()
	{
		cameraManager.PlaySound(0);
		gameManager.GrowPlant();
	}

	public override void OnUp ()
	{
	}

	public override void OnDown ()
	{
	}

	public override void OnLeft ()
	{
		cameraManager.PlaySound(0);
		cameraManager.ChangeContext(upgradesView);
	}

	public override void OnRight ()
	{
		cameraManager.PlaySound(0);
		cameraManager.ChangeContext(statsView);
	}
}