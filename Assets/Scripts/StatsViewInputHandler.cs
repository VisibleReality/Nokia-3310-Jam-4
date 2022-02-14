using UnityEngine;
using UnityEngine.UI;

public class StatsViewInputHandler : InputHandler
{
	[SerializeField] private InputHandler mainView;

	[SerializeField] private Text statsText;

	[SerializeField] private Image scrollUpIndicator;
	[SerializeField] private Image scrollDownIndicator;

	private RectTransform statsTextTransform;

	private float statsTextTopPosition;
	private float statsTextBottomPosition;

	private new void Start ()
	{
		base.Start();

		statsTextTransform = statsText.rectTransform;

		statsTextTopPosition = statsTextTransform.position.y;
		statsTextBottomPosition = statsTextTopPosition + statsTextTransform.sizeDelta.y - 29; // 29 is viewport height
	}


	private void Update ()
	{
		var statsTextVerticalPosition = statsTextTransform.position;

		scrollUpIndicator.enabled = statsTextVerticalPosition.y > statsTextTopPosition;
		scrollDownIndicator.enabled = statsTextVerticalPosition.y < statsTextBottomPosition;
	}

	private string GenerateStats ()
	{
		var statsString = "";
		
		statsString += $"Growth speed: {Utilities.GetFormattedHeightString(gameManager.GrowthSpeed)}/s\n";

		statsString += "Upgrade counts:\n";

		for (var i = 0; i < gameManager.upgrades.Length; i++)
		{
			statsString += $"{gameManager.upgrades[i].name}: {gameManager.gameData.upgradeCounts[i]}\n";
		}

		return statsString;
	}

	public override void OnFocus ()
	{
		statsText.text = GenerateStats();
		statsTextTransform.position = new Vector3(100, statsTextTopPosition, 0);
	}

	public override void OnSelect ()
	{
		gameManager.SaveGameAsync();
		cameraManager.PlaySound(1);
	}

	public override void OnUp ()
	{
		if (statsTextTransform.position.y > statsTextTopPosition)
		{
			statsTextTransform.position += new Vector3(0, -6, 0);
			cameraManager.PlaySound(0);
		}
		else
		{
			cameraManager.PlaySound(2);
		}
	}

	public override void OnDown ()
	{
		if (statsTextTransform.position.y < statsTextBottomPosition)
		{
			statsTextTransform.position += new Vector3(0, 6, 0);
			cameraManager.PlaySound(0);
		}
		else
		{
			cameraManager.PlaySound(2);
		}
	}

	public override void OnLeft ()
	{
		cameraManager.ChangeContext(mainView);
		cameraManager.PlaySound(0);
	}

	public override void OnRight ()
	{
		if (Application.platform != RuntimePlatform.WebGLPlayer)
		{
			cameraManager.PlaySound(0);
			Debug.Log("Exiting!");
			Application.Quit();
		}
	}
}