using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainViewInputHandler : InputHandler
{
	[SerializeField] private InputHandler upgradesView;
	[SerializeField] private InputHandler statsView;
	
	public override void OnFocus ()
	{
	}

	public override void OnSelect ()
	{
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
		cameraManager.ChangeContext(upgradesView);
	}

	public override void OnRight ()
	{
		cameraManager.ChangeContext(statsView);
	}
}