using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesViewInputHandler : InputHandler
{
	[SerializeField] private InputHandler mainView;

	private new void Start ()
	{
		base.Start();
	}

	public override void OnSelect ()
	{
		
	}

	public override void OnUp ()
	{
		
	}

	public override void OnDown ()
	{
		
	}

	public override void OnLeft ()
	{
		
	}

	public override void OnRight ()
	{
		cameraManager.ChangeContext(mainView);
	}
}