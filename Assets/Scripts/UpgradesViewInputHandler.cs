using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesViewInputHandler : InputHandler
{
	[SerializeField] private InputHandler mainView;
	[SerializeField] private GameObject detailsView;

	[SerializeField] private Text upgradeTitleText;
	[SerializeField] private Text upgradeCountText;
	[SerializeField] private Text upgradeCostText;
	[SerializeField] private Text upgradeDescriptionText;
	[SerializeField] private Image upgradeIcon;

	[SerializeField] private Image scrollUpIndicator;
	[SerializeField] private Image scrollDownIndicator;

	[SerializeField] private Image buyButton;
	[SerializeField] private Image buyMaxButton;

	private Upgrade currentUpgrade;
	private int currentPage;
	private int lastPage;

	private void SetPage (int page)
	{
		currentPage = page;
		scrollUpIndicator.enabled = page != 0;
		scrollDownIndicator.enabled = page != lastPage;

		currentUpgrade = gameManager.upgrades[page];

		upgradeTitleText.text = currentUpgrade.name;
		upgradeDescriptionText.text = currentUpgrade.description;
		
		RefreshCostAndCount();
	}

	private void RefreshCostAndCount ()
	{
		var currentUpgradeCount = gameManager.gameData.upgradeCounts[currentPage];

		upgradeCountText.text = $"Owned: {currentUpgradeCount}";
		upgradeCostText.text = $"Cost: {currentUpgrade.GetCurrentCost(currentUpgradeCount)}";
	}

	private new void Start ()
	{
		lastPage = gameManager.upgrades.Length - 1;
		base.Start();
	}

	public override void OnFocus ()
	{
		SetPage(0);
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